﻿using Hl7.Fhir.ElementModel;
using Hl7.Fhir.FhirPath;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Utility;
using Hl7.FhirPath;
using Hl7.FhirPath.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using P = Hl7.Fhir.ElementModel.Types;

namespace Hl7.Fhir
{
    [TestClass]
    public class FhirPathPerformanceTests
    {
        [TestMethod]
        public void QuestionnaireResponseFhirpathPocoTest()
        {
            var xml = File.ReadAllText(@"TestData\Large-QuestionnaireResponse.xml");

            var qr = (new FhirXmlParser()).Parse<QuestionnaireResponse>(xml);

            FhirPathExtensions.GetSymbols().Add("dateadd",
                (P.Date f, string field, long amount) =>
                {
                    DateTimeOffset dto = f.ToDateTimeOffset(0, 0, 0, TimeSpan.Zero).ToUniversalTime();
                    int value = (int)amount;

                    // Need to convert the amount and field to compensate for partials
                    //TimeSpan ts = new TimeSpan();

                    switch (field)
                    {
                        case "yy": dto = dto.AddYears(value); break;
                        case "mm": dto = dto.AddMonths(value); break;
                        case "dd": dto = dto.AddDays(value); break;
                            //case "hh": dto = dto.AddHours(value); break;
                            //case "mi": dto = dto.AddMinutes(value); break;
                            //case "ss": dto = dto.AddSeconds(value); break;
                    }
                    P.Date changedDate = P.Date.Parse(P.Date.FromDateTimeOffset(dto).ToString().Substring(0, f.ToString().Length));
                    return changedDate;
                });

            var v4 = qr.ToTypedElement();
            var v5 = v4.Select("item.where(linkId = 'Section-A').item.where(linkId = 'WorkerGivenNames').answer.value").FirstOrDefault();
            //TODO: We need to add that CommonPath stuff back - but it is soo specific, this should be done
            //by writing a custom ITypedNode implementation on top of this. Left as an exercise for Brian ;-)
            //Assert.AreEqual("QuestionnaireResponse.item.where(linkId='Section-A').item.where(linkId='WorkerGivenNames').answer[0].value", v5.CommonPath);
            var spGenerator = v5.Annotation<IShortPathGenerator>();
            Assert.AreEqual("QuestionnaireResponse.item[0].item[5].answer[0].value", spGenerator.ShortPath);
            Assert.AreEqual("QuestionnaireResponse.item[0].item[5].answer[0].value[0]", v5.Location);

            // Now perform some FHIRpath operations on it
            string bigValidationExpression = "(item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberPrefix').answer" +
                ".value.toString().length() <= 8).trace('A001a') and(item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberSuffix')." +
                "answer.value.toString().length() <= 2).trace('A001b') and((QuestionnaireResponse.item.where(linkId = 'Section-A')." +
                "item.where(linkId = 'ClaimNumberPrefix').answer.value.empty() and QuestionnaireResponse.item.where(linkId = 'Section-A')." +
                "item.where(linkId = 'ClaimNumberSuffix').answer.value.empty()) or(QuestionnaireResponse.item.where(linkId = 'Section-A')." +
                "item.where(linkId = 'ClaimNumberPrefix').answer.value.empty().not() and QuestionnaireResponse.item.where(linkId = 'Section-A')." +
                "item.where(linkId = 'ClaimNumberSuffix').answer.value.empty().not())).trace('A001c') and " +
                "((QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberPrefix').answer.value.empty() and " +
                "QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberSuffix').answer.value.empty() and " +
                "QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimReference').answer.value.toString().length() = 0) or " +
                " ((QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberPrefix').answer.value.empty().not() " +
                " or QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberSuffix').answer.value.empty().not()) " +
                " xor QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimReference').answer.value.toString().length() > 0 ))" +
                ".trace('A001d') and(item.where(linkId = 'Section-A').item.where(linkId = 'ClaimReference').answer.value.toString().length() <= 40)" +
                ".trace('A001e') and(item.where(linkId = 'Section-A').item.where(linkId = 'WorkerDateOfBirth').answer.where(value < @2017-04-10).exists())" +
                ".trace('A001f') and(QuestionnaireResponse.item.where(linkId = 'Section-B').item.where(linkId = 'ExaminationDate').answer.value.empty().not() " +
                "and QuestionnaireResponse.item.where(linkId = 'Section-B').item.where(linkId = 'DateOfInjury').answer.value.empty().not() and " +
                "QuestionnaireResponse.item.where(linkId = 'Section-B').item.where(linkId = 'ExaminationDate').answer.value >= " +
                "QuestionnaireResponse.item.where(linkId = 'Section-B').item.where(linkId = 'DateOfInjury').answer.value).trace('B001') and " +
                "(item.where(linkId = 'Section-B').item.where(linkId = 'ExaminationDate').answer.where(value <= @2017-04-10).exists()).trace('B001') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-B').item.where(linkId = 'DateOfInjury').answer.value.empty().not() " +
                "and QuestionnaireResponse.item.where(linkId = 'Section-B').item.where(linkId = 'DateOfInjury').answer.value > " +
                "QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'WorkerDateOfBirth').answer.value).trace('B003') and " +
                "(item.where(linkId = 'Section-B').item.where(linkId = 'DateOfInjury').answer.where(value <= @2017-04-10).exists()).trace('B002') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.value or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.value).trace('C008') and " +
                "((QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item." +
                "where(linkId = 'DateReturnToNormalDuties').answer.empty() or QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item.where(linkId = 'SuitableDutiesFrom').answer.empty() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item." +
                "where(linkId = 'SuitableDutiesTo').answer.value.empty() or QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item.where(linkId = 'DateReturnToNormalDuties').answer.value > " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item." +
                "where(linkId = 'SuitableDutiesTo').answer.value or QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1')." +
                "answer.item.where(linkId = 'C1fields').item.where(linkId = 'DateReturnToNormalDuties').answer.value < " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item." +
                "where(linkId = 'SuitableDutiesFrom').answer.value) and(QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C1').answer.value.not() or QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7')." +
                "answer.value.not() or QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item." +
                "where(linkId = 'C1fields').item.where(linkId = 'DateReturnToNormalDuties').answer.empty() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields')." +
                "item.where(linkId = 'UnfitSuitableDutiesFrom').answer.empty() or QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesTo').answer.empty() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item." +
                "where(linkId = 'DateReturnToNormalDuties').answer.value > QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesTo').answer.value or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item." +
                "where(linkId = 'DateReturnToNormalDuties').answer.value < QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesFrom').answer.value) and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item." +
                "where(linkId = 'SuitableDutiesFrom').answer.empty() or QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item.where(linkId = 'SuitableDutiesTo').answer.empty() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields')." +
                "item.where(linkId = 'UnfitSuitableDutiesFrom').answer.empty() or QuestionnaireResponse.item.where(linkId = 'Section-C')." +
                "item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesTo').answer.empty() " +
                "or QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields')." +
                "item.where(linkId = 'SuitableDutiesFrom').answer.value > QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesTo').answer.value or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item." +
                "where(linkId = 'SuitableDutiesTo').answer.value < QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesFrom').answer.value))." +
                "trace('C009') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item." +
                "where(linkId = 'DateReturnToNormalDuties').answer.value >= QuestionnaireResponse.item.where(linkId = 'Section-B').item." +
                "where(linkId = 'ExaminationDate').answer.value or QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item.where(linkId = 'DateReturnToNormalDuties').answer.value." +
                "toString().length() = 0).trace('C001') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1')." +
                "answer.value.not() or QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item." +
                "where(linkId = 'DateReturnToNormalDuties').answer.empty() or QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item.where(linkId = 'SuitableDutiesTo').answer.empty() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item." +
                "where(linkId = 'DateReturnToNormalDuties').answer.value > QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item.where(linkId = 'SuitableDutiesTo').answer.value)." +
                "trace('C002') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item." +
                "where(linkId = 'DateReturnToNormalDuties').answer.empty() or QuestionnaireResponse.item.where(linkId = 'Section-C').item." +
                "where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesTo').answer.empty() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item" +
                ".where(linkId = 'DateReturnToNormalDuties').answer.value > QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesTo').answer.value)" +
                ".trace('C003') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.value.not() or" +
                " QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C1').answer.item.where(linkId = 'C1fields').item" +
                ".where(linkId = 'DateReturnToNormalDuties').answer.value.toString().length() = 10).trace('DateReturnToNormalDutiesMandatory') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value.not() or QuestionnaireResponse" +
                ".item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item" +
                ".where(linkId = 'SuitableDutiesFrom').answer.value.toString().length() = 10).trace('SuitableDutiesFromMandatory') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item" +
                ".where(linkId = 'SuitableDutiesTo').answer.value.toString().length() = 10).trace('SuitableDutiesToMandatory') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value.not() or " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item" +
                ".where(linkId = 'SuitableDutiesFrom').answer.value <= QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item.where(linkId = 'SuitableDutiesTo').answer.value) or " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item" +
                ".where(linkId = 'SuitableDutiesFrom').answer.value.toString().length() = 0  or QuestionnaireResponse.item" +
                ".where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item" +
                ".where(linkId = 'SuitableDutiesTo').answer.value.toString().length() = 0)).trace('GN006') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.value.not() or " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item" +
                ".where(linkId = 'SuitableDutiesFrom').answer.value >= QuestionnaireResponse.item.where(linkId = 'Section-B').item" +
                ".where(linkId = 'ExaminationDate').answer.value) or(QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C4').answer.item.where(linkId = 'C4fields').item" +
                ".where(linkId = 'SuitableDutiesFrom').answer.value.toString().length() = 0)).trace('C004') and " +
                "(item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'UnfitSuitableDutiesFrom').answer.value.toString().length() = 10).trace('UnfitSuitableDutiesFromMandatory') and " +
                "(item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'UnfitSuitableDutiesTo').answer.value.toString().length() = 10).trace('UnfitSuitableDutiesToMandatory') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'UnfitSuitableDutiesFrom').answer.value >= QuestionnaireResponse.item.where(linkId = 'Section-B').item" +
                ".where(linkId = 'DateOfInjury').answer.value or QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'UnfitSuitableDutiesFrom').answer.value.toString().length() = 0).trace('C005') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.value.not() or " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'UnfitSuitableDutiesFrom').answer.value <= QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'UnfitSuitableDutiesTo').answer.value) or " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'UnfitSuitableDutiesFrom').answer.value.toString().length() = 0 or QuestionnaireResponse.item" +
                ".where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'UnfitSuitableDutiesTo').answer.value.toString().length() = 0)).trace('GN006') and" +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.value.not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'C11').answer.value.not() or QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item" +
                ".where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWDays').answer.value.empty().not() or " +
                "QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWWeeks').answer.value.empty().not() " +
                "or QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item" +
                ".where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item" +
                ".where(linkId = 'CapacityRTWUncertain').answer.value).trace('C010') and (QuestionnaireResponse.item" +
                ".where(linkId = 'Section-C').item.where(linkId = 'C7').answer.value.not() or QuestionnaireResponse.item" +
                ".where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'C11').answer.value.not() or(QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item" +
                ".where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWDays').answer.value.empty() and QuestionnaireResponse.item" +
                ".where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWWeeks').answer.value.empty() " +
                "and QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item" +
                ".where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item" +
                ".where(linkId = 'CapacityRTWUncertain').answer.value.not()) or(QuestionnaireResponse.item.where(linkId = 'Section-C').item" +
                ".where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item" +
                ".where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWDays').answer.count() + QuestionnaireResponse.item" +
                ".where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWWeeks')" +
                ".answer.count() + QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item" +
                ".where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item" +
                ".where(linkId = 'CapacityRTWUncertain').answer.where(valueBoolean = true).count() < 2)).trace('C010') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item" +
                ".where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item" +
                ".where(linkId = 'CapacityRTWDays').answer.value.toString().length() <= 2).trace('CapacityRTWDaysMaxLength') and " +
                "(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item" +
                ".where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWWeeks').answer.value.toString().length() <= 2).trace('CapacityRTWWeeksMaxLength') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWDays').answer.value.toInteger().all($this >= 0 and $this <= 31)).trace('GN007') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'C7').answer.item.where(linkId = 'C7fields').item.where(linkId = 'C11').answer.item.where(linkId = 'C11fields').item.where(linkId = 'CapacityRTWWeeks').answer.value.toInteger().all($this >= 0 and $this <= 52)).trace('GN007') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'ReviewDate').answer.value > @2017-04-10).trace('C006') and(QuestionnaireResponse.item.where(linkId = 'Section-C').item.where(linkId = 'ReviewDate').answer.value <= @2017-04-10.dateadd('yy', 1)).trace('C007') and(((QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D2').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D2').answer.item.where(linkId = 'D2fields').item.answer.value.toString().length() > 0) or(QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D2').answer.value = false) )).trace('GN009') and(((QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D4').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D4').answer.item.where(linkId = 'D4fields').item.answer.value.toString().length() > 0) or(QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D4').answer.value = false) )).trace('GN009') and(((QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D6').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D6').answer.item.where(linkId = 'D6fields').item.answer.value.toString().length() > 0) or(QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D6').answer.value = false) )).trace('GN009') and(((QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D8').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D8').answer.item.where(linkId = 'D8fields').item.answer.value.toString().length() > 0) or(QuestionnaireResponse.item.where(linkId = 'Section-D').item.where(linkId = '1557925D-117A-4066-80B6-4688AC1BB285').item.where(linkId = 'D8').answer.value = false) )).trace('GN009') and(((QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = 'E17').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = 'E17').answer.item.where(linkId = 'E17fields').item.answer.value.toString().length() > 0) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = 'E17').answer.value = false) )).trace('E005') and(((QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = 'E15').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = 'E15').answer.item.where(linkId = 'E15fields').item.answer.value.toString().length() > 0) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = 'E15').answer.value = false) )).trace('E003') and(((QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseOverWeeks').answer.value.empty().not() and QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursFrom').answer.value.empty().not()) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.value = false) )).trace('E001') and((QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursFrom').answer.value.toDecimal() >= 0.0 and QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursFrom').answer.value.toDecimal() <= 24.0) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursFrom').answer.value.empty())).trace('E004') and((QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursTo').answer.value.toDecimal() >= 0.0 and QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursTo').answer.value.toDecimal() <= 24.0) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursTo').answer.value.empty())).trace('E004') and(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseOverWeeks').answer.value.toInteger().all($this >= 1 and $this <= 52)).trace('E001') and(((QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.value = true and QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursFrom').answer.value.toDecimal() <= QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursTo').answer.value.toDecimal()) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.value = false) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursFrom').answer.value.empty() or QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E19').answer.item.where(linkId = 'E19fields').item.where(linkId = 'GraduatedIncreaseHoursTo').answer.value.empty()))).trace('E006') and(((QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E23').answer.value = true and(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E23').answer.item.where(linkId = 'E23fields').item.where(linkId = 'NonConsecutiveDays').answer.value.empty().not() or QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E23').answer.item.where(linkId = 'E23fields').item.where(linkId = 'NonConsecutiveWeeks').answer.value.empty().not())) or(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E23').answer.value = false) )).trace('GN007') and(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E23').answer.item.where(linkId = 'E23fields').item.where(linkId = 'NonConsecutiveDays').answer.value.toInteger().all($this >= 1 and $this <= 31)).trace('GN007') and(QuestionnaireResponse.item.where(linkId = 'Section-E').item.where(linkId = '9488b6e9-619a-470d-b6d6-e30ca1c2b99e').item.where(linkId = 'E23').answer.item.where(linkId = 'E23fields').item.where(linkId = 'NonConsecutiveWeeks').answer.value.toInteger().all($this >= 1 and $this <= 52)).trace('GN008') and((QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = 'CaseManagerToContact').answer.value = false and QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = 'EmployerToContact').answer.value = false) or((QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = 'CaseManagerToContact').answer.value = true or QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = 'EmployerToContact').answer.value = true) and(QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = '0B432B1B-18E6-4659-B0ED-713E54F5EFA5').item.where(linkId = 'PreferredContactPhone').answer.value = true or QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = '0B432B1B-18E6-4659-B0ED-713E54F5EFA5').item.where(linkId = 'PreferredContactEmail').answer.value = true or QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = '0B432B1B-18E6-4659-B0ED-713E54F5EFA5').item.where(linkId = 'PreferredContactFax').answer.value = true or QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = '0B432B1B-18E6-4659-B0ED-713E54F5EFA5').item.where(linkId = 'PreferredContactWriting').answer.value = true or QuestionnaireResponse.item.where(linkId = 'Section-F').item.where(linkId = '0B432B1B-18E6-4659-B0ED-713E54F5EFA5').item.where(linkId = 'PreferredContactVisit').answer.value = true))).trace('F001') and(item.where(linkId = 'Section-G').item.where(linkId = 'CompletionDate').answer.value <= @2017-04-10).trace('G001') and(item.where(linkId = 'Section-G').item.where(linkId = 'ProviderMedicareNo').answer.value.matches('^[0-9]{6}[A-Za-z]{2}$|^[0-9]{7}[A-Za-z]{1}$')).trace('G002')";
            string mediumValidationExpression = "(item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberPrefix').answer.value" +
                ".toString().length() <= 8).trace('A001a') and(item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberSuffix')" +
                ".answer.value.toString().length() <= 2).trace('A001b') and((QuestionnaireResponse.item.where(linkId = 'Section-A').item" +
                ".where(linkId = 'ClaimNumberPrefix').answer.value.empty() and QuestionnaireResponse.item.where(linkId = 'Section-A').item" +
                ".where(linkId = 'ClaimNumberSuffix').answer.value.empty()) or(QuestionnaireResponse.item.where(linkId = 'Section-A').item" +
                ".where(linkId = 'ClaimNumberPrefix').answer.value.empty().not() and QuestionnaireResponse.item.where(linkId = 'Section-A').item" +
                ".where(linkId = 'ClaimNumberSuffix').answer.value.empty().not())).trace('A001c') and " +
                "((QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberPrefix').answer.value.empty()" +
                " and QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberSuffix').answer.value.empty()" +
                " and QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimReference').answer.value.toString().length() = 0)" +
                " or((QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberPrefix').answer.value.empty().not()" +
                " or QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimNumberSuffix').answer.value.empty().not())" +
                " xor QuestionnaireResponse.item.where(linkId = 'Section-A').item.where(linkId = 'ClaimReference').answer.value.toString().length() > 0))" +
                ".trace('A001d') and " +
                "(item.where(linkId = 'Section-A').item.where(linkId = 'ClaimReference').answer.value.toString().length() <= 40).trace('A001e') and " +
                "(item.where(linkId = 'Section-A').item.where(linkId = 'WorkerDateOfBirth').answer.where(value < @2017-04-10).exists())" +
                ".trace('A001f')";

            for (int n = 0; n < 100; n++)
            {
                bool result = qr.Predicate(mediumValidationExpression);
                Assert.IsTrue(result, "This weird validation should have passed");
            }

            bool resultBig = qr.Predicate(bigValidationExpression);
            Assert.IsTrue(resultBig, "This weird big validation should have passed");
        }
    }

}
