// <auto-generated/>
// Contents of: hl7.fhir.r4b.core version: 4.3.0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Serialization;
using Hl7.Fhir.Specification;
using Hl7.Fhir.Utility;
using Hl7.Fhir.Validation;

/*
  Copyright (c) 2011+, HL7, Inc.
  All rights reserved.
  
  Redistribution and use in source and binary forms, with or without modification, 
  are permitted provided that the following conditions are met:
  
   * Redistributions of source code must retain the above copyright notice, this 
     list of conditions and the following disclaimer.
   * Redistributions in binary form must reproduce the above copyright notice, 
     this list of conditions and the following disclaimer in the documentation 
     and/or other materials provided with the distribution.
   * Neither the name of HL7 nor the names of its contributors may be used to 
     endorse or promote products derived from this software without specific 
     prior written permission.
  
  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
  ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
  WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
  IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
  INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
  NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
  WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
  ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
  POSSIBILITY OF SUCH DAMAGE.
  
*/

namespace Hl7.Fhir.Model
{
  /// <summary>
  /// EnrollmentResponse resource
  /// </summary>
  [Serializable]
  [DataContract]
  [FhirType("EnrollmentResponse","http://hl7.org/fhir/StructureDefinition/EnrollmentResponse", IsResource=true)]
  public partial class EnrollmentResponse : Hl7.Fhir.Model.DomainResource
  {
    /// <summary>
    /// FHIR Type Name
    /// </summary>
    public override string TypeName { get { return "EnrollmentResponse"; } }

    /// <summary>
    /// Business Identifier
    /// </summary>
    [FhirElement("identifier", Order=90)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Identifier> Identifier
    {
      get { if(_Identifier==null) _Identifier = new List<Hl7.Fhir.Model.Identifier>(); return _Identifier; }
      set { _Identifier = value; OnPropertyChanged("Identifier"); }
    }

    private List<Hl7.Fhir.Model.Identifier> _Identifier;

    /// <summary>
    /// active | cancelled | draft | entered-in-error
    /// </summary>
    [FhirElement("status", InSummary=true, IsModifier=true, Order=100)]
    [DeclaredType(Type = typeof(Code))]
    [DataMember]
    public Code<Hl7.Fhir.Model.FinancialResourceStatusCodes> StatusElement
    {
      get { return _StatusElement; }
      set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
    }

    private Code<Hl7.Fhir.Model.FinancialResourceStatusCodes> _StatusElement;

    /// <summary>
    /// active | cancelled | draft | entered-in-error
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.FinancialResourceStatusCodes? Status
    {
      get { return StatusElement != null ? StatusElement.Value : null; }
      set
      {
        if (value == null)
          StatusElement = null;
        else
          StatusElement = new Code<Hl7.Fhir.Model.FinancialResourceStatusCodes>(value);
        OnPropertyChanged("Status");
      }
    }

    /// <summary>
    /// Claim reference
    /// </summary>
    [FhirElement("request", Order=110)]
    [CLSCompliant(false)]
    [References("EnrollmentRequest")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Request
    {
      get { return _Request; }
      set { _Request = value; OnPropertyChanged("Request"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Request;

    /// <summary>
    /// queued | complete | error | partial
    /// </summary>
    [FhirElement("outcome", Order=120)]
    [DeclaredType(Type = typeof(Code))]
    [DataMember]
    public Code<Hl7.Fhir.Model.RemittanceOutcome> OutcomeElement
    {
      get { return _OutcomeElement; }
      set { _OutcomeElement = value; OnPropertyChanged("OutcomeElement"); }
    }

    private Code<Hl7.Fhir.Model.RemittanceOutcome> _OutcomeElement;

    /// <summary>
    /// queued | complete | error | partial
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.RemittanceOutcome? Outcome
    {
      get { return OutcomeElement != null ? OutcomeElement.Value : null; }
      set
      {
        if (value == null)
          OutcomeElement = null;
        else
          OutcomeElement = new Code<Hl7.Fhir.Model.RemittanceOutcome>(value);
        OnPropertyChanged("Outcome");
      }
    }

    /// <summary>
    /// Disposition Message
    /// </summary>
    [FhirElement("disposition", Order=130)]
    [DataMember]
    public Hl7.Fhir.Model.FhirString DispositionElement
    {
      get { return _DispositionElement; }
      set { _DispositionElement = value; OnPropertyChanged("DispositionElement"); }
    }

    private Hl7.Fhir.Model.FhirString _DispositionElement;

    /// <summary>
    /// Disposition Message
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public string Disposition
    {
      get { return DispositionElement != null ? DispositionElement.Value : null; }
      set
      {
        if (value == null)
          DispositionElement = null;
        else
          DispositionElement = new Hl7.Fhir.Model.FhirString(value);
        OnPropertyChanged("Disposition");
      }
    }

    /// <summary>
    /// Creation date
    /// </summary>
    [FhirElement("created", Order=140)]
    [DataMember]
    public Hl7.Fhir.Model.FhirDateTime CreatedElement
    {
      get { return _CreatedElement; }
      set { _CreatedElement = value; OnPropertyChanged("CreatedElement"); }
    }

    private Hl7.Fhir.Model.FhirDateTime _CreatedElement;

    /// <summary>
    /// Creation date
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public string Created
    {
      get { return CreatedElement != null ? CreatedElement.Value : null; }
      set
      {
        if (value == null)
          CreatedElement = null;
        else
          CreatedElement = new Hl7.Fhir.Model.FhirDateTime(value);
        OnPropertyChanged("Created");
      }
    }

    /// <summary>
    /// Insurer
    /// </summary>
    [FhirElement("organization", Order=150, FiveWs="FiveWs.actor")]
    [CLSCompliant(false)]
    [References("Organization")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Organization
    {
      get { return _Organization; }
      set { _Organization = value; OnPropertyChanged("Organization"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Organization;

    /// <summary>
    /// Responsible practitioner
    /// </summary>
    [FhirElement("requestProvider", Order=160)]
    [CLSCompliant(false)]
    [References("Practitioner","PractitionerRole","Organization")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference RequestProvider
    {
      get { return _RequestProvider; }
      set { _RequestProvider = value; OnPropertyChanged("RequestProvider"); }
    }

    private Hl7.Fhir.Model.ResourceReference _RequestProvider;

    public override IDeepCopyable CopyTo(IDeepCopyable other)
    {
      var dest = other as EnrollmentResponse;

      if (dest == null)
      {
        throw new ArgumentException("Can only copy to an object of the same type", "other");
      }

      base.CopyTo(dest);
      if(Identifier != null) dest.Identifier = new List<Hl7.Fhir.Model.Identifier>(Identifier.DeepCopy());
      if(StatusElement != null) dest.StatusElement = (Code<Hl7.Fhir.Model.FinancialResourceStatusCodes>)StatusElement.DeepCopy();
      if(Request != null) dest.Request = (Hl7.Fhir.Model.ResourceReference)Request.DeepCopy();
      if(OutcomeElement != null) dest.OutcomeElement = (Code<Hl7.Fhir.Model.RemittanceOutcome>)OutcomeElement.DeepCopy();
      if(DispositionElement != null) dest.DispositionElement = (Hl7.Fhir.Model.FhirString)DispositionElement.DeepCopy();
      if(CreatedElement != null) dest.CreatedElement = (Hl7.Fhir.Model.FhirDateTime)CreatedElement.DeepCopy();
      if(Organization != null) dest.Organization = (Hl7.Fhir.Model.ResourceReference)Organization.DeepCopy();
      if(RequestProvider != null) dest.RequestProvider = (Hl7.Fhir.Model.ResourceReference)RequestProvider.DeepCopy();
      return dest;
    }

    public override IDeepCopyable DeepCopy()
    {
      return CopyTo(new EnrollmentResponse());
    }

    ///<inheritdoc />
    public override bool Matches(IDeepComparable other)
    {
      var otherT = other as EnrollmentResponse;
      if(otherT == null) return false;

      if(!base.Matches(otherT)) return false;
      if( !DeepComparable.Matches(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.Matches(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.Matches(Request, otherT.Request)) return false;
      if( !DeepComparable.Matches(OutcomeElement, otherT.OutcomeElement)) return false;
      if( !DeepComparable.Matches(DispositionElement, otherT.DispositionElement)) return false;
      if( !DeepComparable.Matches(CreatedElement, otherT.CreatedElement)) return false;
      if( !DeepComparable.Matches(Organization, otherT.Organization)) return false;
      if( !DeepComparable.Matches(RequestProvider, otherT.RequestProvider)) return false;

      return true;
    }

    public override bool IsExactly(IDeepComparable other)
    {
      var otherT = other as EnrollmentResponse;
      if(otherT == null) return false;

      if(!base.IsExactly(otherT)) return false;
      if( !DeepComparable.IsExactly(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.IsExactly(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.IsExactly(Request, otherT.Request)) return false;
      if( !DeepComparable.IsExactly(OutcomeElement, otherT.OutcomeElement)) return false;
      if( !DeepComparable.IsExactly(DispositionElement, otherT.DispositionElement)) return false;
      if( !DeepComparable.IsExactly(CreatedElement, otherT.CreatedElement)) return false;
      if( !DeepComparable.IsExactly(Organization, otherT.Organization)) return false;
      if( !DeepComparable.IsExactly(RequestProvider, otherT.RequestProvider)) return false;

      return true;
    }

    [IgnoreDataMember]
    public override IEnumerable<Base> Children
    {
      get
      {
        foreach (var item in base.Children) yield return item;
        foreach (var elem in Identifier) { if (elem != null) yield return elem; }
        if (StatusElement != null) yield return StatusElement;
        if (Request != null) yield return Request;
        if (OutcomeElement != null) yield return OutcomeElement;
        if (DispositionElement != null) yield return DispositionElement;
        if (CreatedElement != null) yield return CreatedElement;
        if (Organization != null) yield return Organization;
        if (RequestProvider != null) yield return RequestProvider;
      }
    }

    [IgnoreDataMember]
    public override IEnumerable<ElementValue> NamedChildren
    {
      get
      {
        foreach (var item in base.NamedChildren) yield return item;
        foreach (var elem in Identifier) { if (elem != null) yield return new ElementValue("identifier", elem); }
        if (StatusElement != null) yield return new ElementValue("status", StatusElement);
        if (Request != null) yield return new ElementValue("request", Request);
        if (OutcomeElement != null) yield return new ElementValue("outcome", OutcomeElement);
        if (DispositionElement != null) yield return new ElementValue("disposition", DispositionElement);
        if (CreatedElement != null) yield return new ElementValue("created", CreatedElement);
        if (Organization != null) yield return new ElementValue("organization", Organization);
        if (RequestProvider != null) yield return new ElementValue("requestProvider", RequestProvider);
      }
    }

    protected override bool TryGetValue(string key, out object value)
    {
      switch (key)
      {
        case "identifier":
          value = Identifier;
          return Identifier?.Any() == true;
        case "status":
          value = StatusElement;
          return StatusElement is not null;
        case "request":
          value = Request;
          return Request is not null;
        case "outcome":
          value = OutcomeElement;
          return OutcomeElement is not null;
        case "disposition":
          value = DispositionElement;
          return DispositionElement is not null;
        case "created":
          value = CreatedElement;
          return CreatedElement is not null;
        case "organization":
          value = Organization;
          return Organization is not null;
        case "requestProvider":
          value = RequestProvider;
          return RequestProvider is not null;
        default:
          return base.TryGetValue(key, out value);
      };

    }

    protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
    {
      foreach (var kvp in base.GetElementPairs()) yield return kvp;
      if (Identifier?.Any() == true) yield return new KeyValuePair<string,object>("identifier",Identifier);
      if (StatusElement is not null) yield return new KeyValuePair<string,object>("status",StatusElement);
      if (Request is not null) yield return new KeyValuePair<string,object>("request",Request);
      if (OutcomeElement is not null) yield return new KeyValuePair<string,object>("outcome",OutcomeElement);
      if (DispositionElement is not null) yield return new KeyValuePair<string,object>("disposition",DispositionElement);
      if (CreatedElement is not null) yield return new KeyValuePair<string,object>("created",CreatedElement);
      if (Organization is not null) yield return new KeyValuePair<string,object>("organization",Organization);
      if (RequestProvider is not null) yield return new KeyValuePair<string,object>("requestProvider",RequestProvider);
    }

  }

}

// end of file
