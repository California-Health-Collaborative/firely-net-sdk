﻿/* 
 * Copyright (c) 2014, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/firely-net-sdk/master/LICENSE
 */

using Hl7.Fhir.Model;
using Hl7.Fhir.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Validator = System.ComponentModel.DataAnnotations.Validator;

namespace Hl7.Fhir.Tests.Validation
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void TestIdValidation()
        {
            Id id = new("az23");

            DotNetAttributeValidation.Validate(id);
            DotNetAttributeValidation.Validate(id, true);        // recursive checking shouldnt matter

            id = new Id("!notgood!");
            validateErrorOrFail(id);

            id = new Id("NotGood!");
            validateErrorOrFail(id);

            id = new Id("123456789012345678901234567890123456745290123456745290123456745290123456745290");
            validateErrorOrFail(id);
        }

        [TestMethod]
        public void IdIsNowAString()
        {
            HumanName hn = HumanName.ForFamily("Kramer");
            hn.ElementId = "This/may:contain.all$kinds%of@characters_now";

            DotNetAttributeValidation.Validate(hn);
        }

        [TestMethod]
        public void ValidatesResourceTag()
        {
            var p = new Patient
            {
                Meta = new Meta()
                {
                }
            };

            p.Meta.Tag.Add(new Coding("http://system", "  illegal    _  code "));

            Assert.IsFalse(DotNetAttributeValidation.TryValidate(p, recurse: true));
        }

        private static void validateErrorOrFail(Base instance, bool recurse = false, string membername = null)
        {
            try
            {
                // should throw error
                DotNetAttributeValidation.Validate(instance, recurse);
                Assert.Fail();
            }
            catch (ValidationException ve)
            {
                if (membername != null)
                    Assert.IsTrue(ve.ValidationResult.MemberNames.Contains(membername));
            }
        }

        [TestMethod]
        public void OIDandUUIDUrls()
        {
            var oidUrl = "urn:oid:1.2.3";
            var illOidUrl = "urn:oid:datmagdusniet";
            var uuidUrl = "urn:uuid:a5afddf4-e880-459b-876e-e4591b0acc11";
            var illUuidUrl = "urn:uuid:ooknietgoed";
            var oidWithZero = "urn:oid:1.2.0.3.4";

            FhirUri uri = new(oidUrl);
            Validator.ValidateObject(uri, new ValidationContext(uri), true);

            uri = new FhirUri(illOidUrl);
            validateErrorOrFail(uri);

            uri = new FhirUri(uuidUrl);
            Validator.ValidateObject(uri, new ValidationContext(uri), true);

            uri = new FhirUri(illUuidUrl);
            validateErrorOrFail(uri);

            uri = new FhirUri(oidWithZero);
            Validator.ValidateObject(uri, new ValidationContext(uri), true);

            Assert.IsTrue(Uri.Equals(new Uri("http://nu.nl"), new Uri("http://nu.nl")));
        }



        [TestMethod]
        public void TestAllowedChoices()
        {
            Patient p = new()
            {
                Deceased = new FhirBoolean(true)
            };
            DotNetAttributeValidation.Validate(p);

            // Deceased can either be boolean or dateTime, not FhirUri
            p.Deceased = new FhirUri();
            validateErrorOrFail(p);
        }


        [TestMethod]
        public void TestCardinality()
        {
            OperationOutcome oo = new();
            validateErrorOrFail(oo, true);

            oo.Issue = new List<OperationOutcome.IssueComponent>();
            validateErrorOrFail(oo, true);

            var issue = new OperationOutcome.IssueComponent();

            oo.Issue.Add(issue);
            validateErrorOrFail(oo, true);

            issue.Severity = OperationOutcome.IssueSeverity.Information;
            validateErrorOrFail(oo, true);

            issue.Code = OperationOutcome.IssueType.Forbidden;

            DotNetAttributeValidation.Validate(oo, true);
        }

        [TestMethod]
        public void TestEmptyCollectionValidation()
        {
            var p = new Patient
            {
                Identifier = new List<Identifier>()
            };
            p.Identifier.Add(null);

            validateErrorOrFail(p);
        }

        [TestMethod]
        public void ContainedResourcesAreValidatedToo()
        {
            Patient p = new()
            {
                // Deceased can either be boolean or dateTime, not FhirUri
                Deceased = new FhirUri()
            };

            var pr = new Patient
            {
                Contained = new List<Resource> { p }
            };

            validateErrorOrFail(pr, true);
            DotNetAttributeValidation.Validate(pr);
        }

        [TestMethod]
        public void TestContainedConstraints()
        {
            var pat = new Patient();
            var patn = new Patient();
            pat.Contained = new List<Resource> { patn };
            patn.Contained = new List<Resource> { new Patient() };

            // Contained resources should not themselves contain resources
            validateErrorOrFail(pat);
        }

        [TestMethod]
        public void ValidateResourceWithIncorrectChildElement()
        {
            // First create an incomplete Observation (status and code not supplied)
            var obs = new Observation();
            validateErrorOrFail(obs, membername: "StatusElement");
            validateErrorOrFail(obs, true);  // recursive checking shouldn't matter

            obs.Status = ObservationStatus.Final;
            obs.Code = new CodeableConcept("http://snomed.info/sct", "27113001", "Body weight");

            // Now, it should work
            DotNetAttributeValidation.Validate(obs);
            DotNetAttributeValidation.Validate(obs, true);  // recursive checking shouldnt matter

            // Hide an incorrect datetime deep into the Observation
            FhirDateTime dt = new()
            {
                Value = "Ewout Kramer"  // clearly, a wrong datetime
            };

            obs.Effective = new Period() { StartElement = dt };

            // When we do not validate recursively, we should still be ok
            DotNetAttributeValidation.Validate(obs);

            // When we recurse, this should fail
            validateErrorOrFail(obs, true, membername: "Value");
        }

#if !NETSTANDARD1_6
        [TestMethod]    // XHtml validation not available in portable library
        public void TestXhtmlValidation()
        {
            var p = new Patient
            {
                Text = new Narrative() { Div = "<div xmlns='http://www.w3.org/1999/xhtml'><p>should be valid</p></div>", Status = Narrative.NarrativeStatus.Generated }
            };
            DotNetAttributeValidation.Validate(p, true);

            p.Text.Div = "<div xmlns='http://www.w3.org/1999/xhtml'><p>should not be valid<p></div>";
            validateErrorOrFail(p, true);

            p.Text.Div = "<div xmlns='http://www.w3.org/1999/xhtml'><img onmouseover='bigImg(this)' src='smiley.gif' alt='Smiley' /></div>";
            validateErrorOrFail(p, true);
        }
#endif
    }
}
