// <auto-generated/>
// Contents of: hl7.fhir.r4.core version: 4.0.1

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
  /// Request for a medication, substance or device
  /// </summary>
  [Serializable]
  [DataContract]
  [FhirType("SupplyRequest","http://hl7.org/fhir/StructureDefinition/SupplyRequest", IsResource=true)]
  public partial class SupplyRequest : Hl7.Fhir.Model.DomainResource, IIdentifiable<List<Identifier>>, ICoded<Hl7.Fhir.Model.CodeableConcept>
  {
    /// <summary>
    /// FHIR Type Name
    /// </summary>
    public override string TypeName { get { return "SupplyRequest"; } }

    /// <summary>
    /// Status of the supply request.
    /// (url: http://hl7.org/fhir/ValueSet/supplyrequest-status)
    /// (system: http://hl7.org/fhir/supplyrequest-status)
    /// </summary>
    [FhirEnumeration("SupplyRequestStatus", "http://hl7.org/fhir/ValueSet/supplyrequest-status", "http://hl7.org/fhir/supplyrequest-status")]
    public enum SupplyRequestStatus
    {
      /// <summary>
      /// The request has been created but is not yet complete or ready for action.
      /// (system: http://hl7.org/fhir/supplyrequest-status)
      /// </summary>
      [EnumLiteral("draft"), Description("Draft")]
      Draft,
      /// <summary>
      /// The request is ready to be acted upon.
      /// (system: http://hl7.org/fhir/supplyrequest-status)
      /// </summary>
      [EnumLiteral("active"), Description("Active")]
      Active,
      /// <summary>
      /// The authorization/request to act has been temporarily withdrawn but is expected to resume in the future.
      /// (system: http://hl7.org/fhir/supplyrequest-status)
      /// </summary>
      [EnumLiteral("suspended"), Description("Suspended")]
      Suspended,
      /// <summary>
      /// The authorization/request to act has been terminated prior to the full completion of the intended actions.  No further activity should occur.
      /// (system: http://hl7.org/fhir/supplyrequest-status)
      /// </summary>
      [EnumLiteral("cancelled"), Description("Cancelled")]
      Cancelled,
      /// <summary>
      /// Activity against the request has been sufficiently completed to the satisfaction of the requester.
      /// (system: http://hl7.org/fhir/supplyrequest-status)
      /// </summary>
      [EnumLiteral("completed"), Description("Completed")]
      Completed,
      /// <summary>
      /// This electronic record should never have existed, though it is possible that real-world decisions were based on it.  (If real-world activity has occurred, the status should be "cancelled" rather than "entered-in-error".).
      /// (system: http://hl7.org/fhir/supplyrequest-status)
      /// </summary>
      [EnumLiteral("entered-in-error"), Description("Entered in Error")]
      EnteredInError,
      /// <summary>
      /// The authoring/source system does not know which of the status values currently applies for this observation. Note: This concept is not to be used for "other" - one of the listed statuses is presumed to apply, but the authoring/source system does not know which.
      /// (system: http://hl7.org/fhir/supplyrequest-status)
      /// </summary>
      [EnumLiteral("unknown"), Description("Unknown")]
      Unknown,
    }

    /// <summary>
    /// Ordered item details
    /// </summary>
    [Serializable]
    [DataContract]
    [FhirType("SupplyRequest#Parameter", IsNestedType=true)]
    [BackboneType("SupplyRequest.parameter")]
    public partial class ParameterComponent : Hl7.Fhir.Model.BackboneElement
    {
      /// <summary>
      /// FHIR Type Name
      /// </summary>
      public override string TypeName { get { return "SupplyRequest#Parameter"; } }

      /// <summary>
      /// Item detail
      /// </summary>
      [FhirElement("code", Order=40, FiveWs="FiveWs.what[x]")]
      [DataMember]
      public Hl7.Fhir.Model.CodeableConcept Code
      {
        get { return _Code; }
        set { _Code = value; OnPropertyChanged("Code"); }
      }

      private Hl7.Fhir.Model.CodeableConcept _Code;

      /// <summary>
      /// Value of detail
      /// </summary>
      [FhirElement("value", Order=50, Choice=ChoiceType.DatatypeChoice, FiveWs="FiveWs.what[x]")]
      [CLSCompliant(false)]
      [AllowedTypes(typeof(Hl7.Fhir.Model.CodeableConcept),typeof(Hl7.Fhir.Model.Quantity),typeof(Hl7.Fhir.Model.Range),typeof(Hl7.Fhir.Model.FhirBoolean))]
      [DataMember]
      public Hl7.Fhir.Model.DataType Value
      {
        get { return _Value; }
        set { _Value = value; OnPropertyChanged("Value"); }
      }

      private Hl7.Fhir.Model.DataType _Value;

      public override IDeepCopyable CopyTo(IDeepCopyable other)
      {
        var dest = other as ParameterComponent;

        if (dest == null)
        {
          throw new ArgumentException("Can only copy to an object of the same type", "other");
        }

        base.CopyTo(dest);
        if(Code != null) dest.Code = (Hl7.Fhir.Model.CodeableConcept)Code.DeepCopy();
        if(Value != null) dest.Value = (Hl7.Fhir.Model.DataType)Value.DeepCopy();
        return dest;
      }

      public override IDeepCopyable DeepCopy()
      {
        return CopyTo(new ParameterComponent());
      }

      ///<inheritdoc />
      public override bool Matches(IDeepComparable other)
      {
        var otherT = other as ParameterComponent;
        if(otherT == null) return false;

        if(!base.Matches(otherT)) return false;
        if( !DeepComparable.Matches(Code, otherT.Code)) return false;
        if( !DeepComparable.Matches(Value, otherT.Value)) return false;

        return true;
      }

      public override bool IsExactly(IDeepComparable other)
      {
        var otherT = other as ParameterComponent;
        if(otherT == null) return false;

        if(!base.IsExactly(otherT)) return false;
        if( !DeepComparable.IsExactly(Code, otherT.Code)) return false;
        if( !DeepComparable.IsExactly(Value, otherT.Value)) return false;

        return true;
      }

      [IgnoreDataMember]
      public override IEnumerable<Base> Children
      {
        get
        {
          foreach (var item in base.Children) yield return item;
          if (Code != null) yield return Code;
          if (Value != null) yield return Value;
        }
      }

      [IgnoreDataMember]
      public override IEnumerable<ElementValue> NamedChildren
      {
        get
        {
          foreach (var item in base.NamedChildren) yield return item;
          if (Code != null) yield return new ElementValue("code", Code);
          if (Value != null) yield return new ElementValue("value", Value);
        }
      }

      protected override bool TryGetValue(string key, out object value)
      {
        switch (key)
        {
          case "code":
            value = Code;
            return Code is not null;
          case "value":
            value = Value;
            return Value is not null;
          default:
            return base.TryGetValue(key, out value);
        }

      }

      protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
      {
        foreach (var kvp in base.GetElementPairs()) yield return kvp;
        if (Code is not null) yield return new KeyValuePair<string,object>("code",Code);
        if (Value is not null) yield return new KeyValuePair<string,object>("value",Value);
      }

    }

    /// <summary>
    /// Business Identifier for SupplyRequest
    /// </summary>
    [FhirElement("identifier", InSummary=true, Order=90, FiveWs="FiveWs.identifier")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Identifier> Identifier
    {
      get { if(_Identifier==null) _Identifier = new List<Hl7.Fhir.Model.Identifier>(); return _Identifier; }
      set { _Identifier = value; OnPropertyChanged("Identifier"); }
    }

    private List<Hl7.Fhir.Model.Identifier> _Identifier;

    /// <summary>
    /// draft | active | suspended +
    /// </summary>
    [FhirElement("status", InSummary=true, IsModifier=true, Order=100, FiveWs="FiveWs.status")]
    [DeclaredType(Type = typeof(Code))]
    [Binding("SupplyRequestStatus")]
    [DataMember]
    public Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus> StatusElement
    {
      get { return _StatusElement; }
      set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
    }

    private Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus> _StatusElement;

    /// <summary>
    /// draft | active | suspended +
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus? Status
    {
      get { return StatusElement != null ? StatusElement.Value : null; }
      set
      {
        if (value == null)
          StatusElement = null;
        else
          StatusElement = new Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus>(value);
        OnPropertyChanged("Status");
      }
    }

    /// <summary>
    /// The kind of supply (central, non-stock, etc.)
    /// </summary>
    [FhirElement("category", InSummary=true, Order=110, FiveWs="FiveWs.class")]
    [DataMember]
    public Hl7.Fhir.Model.CodeableConcept Category
    {
      get { return _Category; }
      set { _Category = value; OnPropertyChanged("Category"); }
    }

    private Hl7.Fhir.Model.CodeableConcept _Category;

    /// <summary>
    /// routine | urgent | asap | stat
    /// </summary>
    [FhirElement("priority", InSummary=true, Order=120, FiveWs="FiveWs.grade")]
    [DeclaredType(Type = typeof(Code))]
    [Binding("RequestPriority")]
    [DataMember]
    public Code<Hl7.Fhir.Model.RequestPriority> PriorityElement
    {
      get { return _PriorityElement; }
      set { _PriorityElement = value; OnPropertyChanged("PriorityElement"); }
    }

    private Code<Hl7.Fhir.Model.RequestPriority> _PriorityElement;

    /// <summary>
    /// routine | urgent | asap | stat
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.RequestPriority? Priority
    {
      get { return PriorityElement != null ? PriorityElement.Value : null; }
      set
      {
        if (value == null)
          PriorityElement = null;
        else
          PriorityElement = new Code<Hl7.Fhir.Model.RequestPriority>(value);
        OnPropertyChanged("Priority");
      }
    }

    /// <summary>
    /// Medication, Substance, or Device requested to be supplied
    /// </summary>
    [FhirElement("item", InSummary=true, Order=130, Choice=ChoiceType.DatatypeChoice)]
    [CLSCompliant(false)]
    [References("Medication","Substance","Device")]
    [AllowedTypes(typeof(Hl7.Fhir.Model.CodeableConcept),typeof(Hl7.Fhir.Model.ResourceReference))]
    [Cardinality(Min=1,Max=1)]
    [DataMember]
    public Hl7.Fhir.Model.DataType Item
    {
      get { return _Item; }
      set { _Item = value; OnPropertyChanged("Item"); }
    }

    private Hl7.Fhir.Model.DataType _Item;

    /// <summary>
    /// The requested amount of the item indicated
    /// </summary>
    [FhirElement("quantity", InSummary=true, Order=140)]
    [Cardinality(Min=1,Max=1)]
    [DataMember]
    public Hl7.Fhir.Model.Quantity Quantity
    {
      get { return _Quantity; }
      set { _Quantity = value; OnPropertyChanged("Quantity"); }
    }

    private Hl7.Fhir.Model.Quantity _Quantity;

    /// <summary>
    /// Ordered item details
    /// </summary>
    [FhirElement("parameter", Order=150, FiveWs="FiveWs.what[x]")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.SupplyRequest.ParameterComponent> Parameter
    {
      get { if(_Parameter==null) _Parameter = new List<Hl7.Fhir.Model.SupplyRequest.ParameterComponent>(); return _Parameter; }
      set { _Parameter = value; OnPropertyChanged("Parameter"); }
    }

    private List<Hl7.Fhir.Model.SupplyRequest.ParameterComponent> _Parameter;

    /// <summary>
    /// When the request should be fulfilled
    /// </summary>
    [FhirElement("occurrence", InSummary=true, Order=160, Choice=ChoiceType.DatatypeChoice, FiveWs="FiveWs.planned")]
    [CLSCompliant(false)]
    [AllowedTypes(typeof(Hl7.Fhir.Model.FhirDateTime),typeof(Hl7.Fhir.Model.Period),typeof(Hl7.Fhir.Model.Timing))]
    [DataMember]
    public Hl7.Fhir.Model.DataType Occurrence
    {
      get { return _Occurrence; }
      set { _Occurrence = value; OnPropertyChanged("Occurrence"); }
    }

    private Hl7.Fhir.Model.DataType _Occurrence;

    /// <summary>
    /// When the request was made
    /// </summary>
    [FhirElement("authoredOn", InSummary=true, Order=170, FiveWs="FiveWs.recorded")]
    [DataMember]
    public Hl7.Fhir.Model.FhirDateTime AuthoredOnElement
    {
      get { return _AuthoredOnElement; }
      set { _AuthoredOnElement = value; OnPropertyChanged("AuthoredOnElement"); }
    }

    private Hl7.Fhir.Model.FhirDateTime _AuthoredOnElement;

    /// <summary>
    /// When the request was made
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public string AuthoredOn
    {
      get { return AuthoredOnElement != null ? AuthoredOnElement.Value : null; }
      set
      {
        if (value == null)
          AuthoredOnElement = null;
        else
          AuthoredOnElement = new Hl7.Fhir.Model.FhirDateTime(value);
        OnPropertyChanged("AuthoredOn");
      }
    }

    /// <summary>
    /// Individual making the request
    /// </summary>
    [FhirElement("requester", InSummary=true, Order=180, FiveWs="FiveWs.author")]
    [CLSCompliant(false)]
    [References("Practitioner","PractitionerRole","Organization","Patient","RelatedPerson","Device")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Requester
    {
      get { return _Requester; }
      set { _Requester = value; OnPropertyChanged("Requester"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Requester;

    /// <summary>
    /// Who is intended to fulfill the request
    /// </summary>
    [FhirElement("supplier", InSummary=true, Order=190, FiveWs="FiveWs.actor")]
    [CLSCompliant(false)]
    [References("Organization","HealthcareService")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.ResourceReference> Supplier
    {
      get { if(_Supplier==null) _Supplier = new List<Hl7.Fhir.Model.ResourceReference>(); return _Supplier; }
      set { _Supplier = value; OnPropertyChanged("Supplier"); }
    }

    private List<Hl7.Fhir.Model.ResourceReference> _Supplier;

    /// <summary>
    /// The reason why the supply item was requested
    /// </summary>
    [FhirElement("reasonCode", Order=200, FiveWs="FiveWs.why[x]")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.CodeableConcept> ReasonCode
    {
      get { if(_ReasonCode==null) _ReasonCode = new List<Hl7.Fhir.Model.CodeableConcept>(); return _ReasonCode; }
      set { _ReasonCode = value; OnPropertyChanged("ReasonCode"); }
    }

    private List<Hl7.Fhir.Model.CodeableConcept> _ReasonCode;

    /// <summary>
    /// The reason why the supply item was requested
    /// </summary>
    [FhirElement("reasonReference", Order=210, FiveWs="FiveWs.why[x]")]
    [CLSCompliant(false)]
    [References("Condition","Observation","DiagnosticReport","DocumentReference")]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.ResourceReference> ReasonReference
    {
      get { if(_ReasonReference==null) _ReasonReference = new List<Hl7.Fhir.Model.ResourceReference>(); return _ReasonReference; }
      set { _ReasonReference = value; OnPropertyChanged("ReasonReference"); }
    }

    private List<Hl7.Fhir.Model.ResourceReference> _ReasonReference;

    /// <summary>
    /// The origin of the supply
    /// </summary>
    [FhirElement("deliverFrom", Order=220)]
    [CLSCompliant(false)]
    [References("Organization","Location")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference DeliverFrom
    {
      get { return _DeliverFrom; }
      set { _DeliverFrom = value; OnPropertyChanged("DeliverFrom"); }
    }

    private Hl7.Fhir.Model.ResourceReference _DeliverFrom;

    /// <summary>
    /// The destination of the supply
    /// </summary>
    [FhirElement("deliverTo", Order=230)]
    [CLSCompliant(false)]
    [References("Organization","Location","Patient")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference DeliverTo
    {
      get { return _DeliverTo; }
      set { _DeliverTo = value; OnPropertyChanged("DeliverTo"); }
    }

    private Hl7.Fhir.Model.ResourceReference _DeliverTo;

    List<Identifier> IIdentifiable<List<Identifier>>.Identifier { get => Identifier; set => Identifier = value; }

    Hl7.Fhir.Model.CodeableConcept ICoded<Hl7.Fhir.Model.CodeableConcept>.Code { get => Category; set => Category = value; }

    public override IDeepCopyable CopyTo(IDeepCopyable other)
    {
      var dest = other as SupplyRequest;

      if (dest == null)
      {
        throw new ArgumentException("Can only copy to an object of the same type", "other");
      }

      base.CopyTo(dest);
      if(Identifier != null) dest.Identifier = new List<Hl7.Fhir.Model.Identifier>(Identifier.DeepCopy());
      if(StatusElement != null) dest.StatusElement = (Code<Hl7.Fhir.Model.SupplyRequest.SupplyRequestStatus>)StatusElement.DeepCopy();
      if(Category != null) dest.Category = (Hl7.Fhir.Model.CodeableConcept)Category.DeepCopy();
      if(PriorityElement != null) dest.PriorityElement = (Code<Hl7.Fhir.Model.RequestPriority>)PriorityElement.DeepCopy();
      if(Item != null) dest.Item = (Hl7.Fhir.Model.DataType)Item.DeepCopy();
      if(Quantity != null) dest.Quantity = (Hl7.Fhir.Model.Quantity)Quantity.DeepCopy();
      if(Parameter != null) dest.Parameter = new List<Hl7.Fhir.Model.SupplyRequest.ParameterComponent>(Parameter.DeepCopy());
      if(Occurrence != null) dest.Occurrence = (Hl7.Fhir.Model.DataType)Occurrence.DeepCopy();
      if(AuthoredOnElement != null) dest.AuthoredOnElement = (Hl7.Fhir.Model.FhirDateTime)AuthoredOnElement.DeepCopy();
      if(Requester != null) dest.Requester = (Hl7.Fhir.Model.ResourceReference)Requester.DeepCopy();
      if(Supplier != null) dest.Supplier = new List<Hl7.Fhir.Model.ResourceReference>(Supplier.DeepCopy());
      if(ReasonCode != null) dest.ReasonCode = new List<Hl7.Fhir.Model.CodeableConcept>(ReasonCode.DeepCopy());
      if(ReasonReference != null) dest.ReasonReference = new List<Hl7.Fhir.Model.ResourceReference>(ReasonReference.DeepCopy());
      if(DeliverFrom != null) dest.DeliverFrom = (Hl7.Fhir.Model.ResourceReference)DeliverFrom.DeepCopy();
      if(DeliverTo != null) dest.DeliverTo = (Hl7.Fhir.Model.ResourceReference)DeliverTo.DeepCopy();
      return dest;
    }

    public override IDeepCopyable DeepCopy()
    {
      return CopyTo(new SupplyRequest());
    }

    ///<inheritdoc />
    public override bool Matches(IDeepComparable other)
    {
      var otherT = other as SupplyRequest;
      if(otherT == null) return false;

      if(!base.Matches(otherT)) return false;
      if( !DeepComparable.Matches(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.Matches(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.Matches(Category, otherT.Category)) return false;
      if( !DeepComparable.Matches(PriorityElement, otherT.PriorityElement)) return false;
      if( !DeepComparable.Matches(Item, otherT.Item)) return false;
      if( !DeepComparable.Matches(Quantity, otherT.Quantity)) return false;
      if( !DeepComparable.Matches(Parameter, otherT.Parameter)) return false;
      if( !DeepComparable.Matches(Occurrence, otherT.Occurrence)) return false;
      if( !DeepComparable.Matches(AuthoredOnElement, otherT.AuthoredOnElement)) return false;
      if( !DeepComparable.Matches(Requester, otherT.Requester)) return false;
      if( !DeepComparable.Matches(Supplier, otherT.Supplier)) return false;
      if( !DeepComparable.Matches(ReasonCode, otherT.ReasonCode)) return false;
      if( !DeepComparable.Matches(ReasonReference, otherT.ReasonReference)) return false;
      if( !DeepComparable.Matches(DeliverFrom, otherT.DeliverFrom)) return false;
      if( !DeepComparable.Matches(DeliverTo, otherT.DeliverTo)) return false;

      return true;
    }

    public override bool IsExactly(IDeepComparable other)
    {
      var otherT = other as SupplyRequest;
      if(otherT == null) return false;

      if(!base.IsExactly(otherT)) return false;
      if( !DeepComparable.IsExactly(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.IsExactly(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.IsExactly(Category, otherT.Category)) return false;
      if( !DeepComparable.IsExactly(PriorityElement, otherT.PriorityElement)) return false;
      if( !DeepComparable.IsExactly(Item, otherT.Item)) return false;
      if( !DeepComparable.IsExactly(Quantity, otherT.Quantity)) return false;
      if( !DeepComparable.IsExactly(Parameter, otherT.Parameter)) return false;
      if( !DeepComparable.IsExactly(Occurrence, otherT.Occurrence)) return false;
      if( !DeepComparable.IsExactly(AuthoredOnElement, otherT.AuthoredOnElement)) return false;
      if( !DeepComparable.IsExactly(Requester, otherT.Requester)) return false;
      if( !DeepComparable.IsExactly(Supplier, otherT.Supplier)) return false;
      if( !DeepComparable.IsExactly(ReasonCode, otherT.ReasonCode)) return false;
      if( !DeepComparable.IsExactly(ReasonReference, otherT.ReasonReference)) return false;
      if( !DeepComparable.IsExactly(DeliverFrom, otherT.DeliverFrom)) return false;
      if( !DeepComparable.IsExactly(DeliverTo, otherT.DeliverTo)) return false;

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
        if (Category != null) yield return Category;
        if (PriorityElement != null) yield return PriorityElement;
        if (Item != null) yield return Item;
        if (Quantity != null) yield return Quantity;
        foreach (var elem in Parameter) { if (elem != null) yield return elem; }
        if (Occurrence != null) yield return Occurrence;
        if (AuthoredOnElement != null) yield return AuthoredOnElement;
        if (Requester != null) yield return Requester;
        foreach (var elem in Supplier) { if (elem != null) yield return elem; }
        foreach (var elem in ReasonCode) { if (elem != null) yield return elem; }
        foreach (var elem in ReasonReference) { if (elem != null) yield return elem; }
        if (DeliverFrom != null) yield return DeliverFrom;
        if (DeliverTo != null) yield return DeliverTo;
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
        if (Category != null) yield return new ElementValue("category", Category);
        if (PriorityElement != null) yield return new ElementValue("priority", PriorityElement);
        if (Item != null) yield return new ElementValue("item", Item);
        if (Quantity != null) yield return new ElementValue("quantity", Quantity);
        foreach (var elem in Parameter) { if (elem != null) yield return new ElementValue("parameter", elem); }
        if (Occurrence != null) yield return new ElementValue("occurrence", Occurrence);
        if (AuthoredOnElement != null) yield return new ElementValue("authoredOn", AuthoredOnElement);
        if (Requester != null) yield return new ElementValue("requester", Requester);
        foreach (var elem in Supplier) { if (elem != null) yield return new ElementValue("supplier", elem); }
        foreach (var elem in ReasonCode) { if (elem != null) yield return new ElementValue("reasonCode", elem); }
        foreach (var elem in ReasonReference) { if (elem != null) yield return new ElementValue("reasonReference", elem); }
        if (DeliverFrom != null) yield return new ElementValue("deliverFrom", DeliverFrom);
        if (DeliverTo != null) yield return new ElementValue("deliverTo", DeliverTo);
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
        case "category":
          value = Category;
          return Category is not null;
        case "priority":
          value = PriorityElement;
          return PriorityElement is not null;
        case "item":
          value = Item;
          return Item is not null;
        case "quantity":
          value = Quantity;
          return Quantity is not null;
        case "parameter":
          value = Parameter;
          return Parameter?.Any() == true;
        case "occurrence":
          value = Occurrence;
          return Occurrence is not null;
        case "authoredOn":
          value = AuthoredOnElement;
          return AuthoredOnElement is not null;
        case "requester":
          value = Requester;
          return Requester is not null;
        case "supplier":
          value = Supplier;
          return Supplier?.Any() == true;
        case "reasonCode":
          value = ReasonCode;
          return ReasonCode?.Any() == true;
        case "reasonReference":
          value = ReasonReference;
          return ReasonReference?.Any() == true;
        case "deliverFrom":
          value = DeliverFrom;
          return DeliverFrom is not null;
        case "deliverTo":
          value = DeliverTo;
          return DeliverTo is not null;
        default:
          return base.TryGetValue(key, out value);
      }

    }

    protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
    {
      foreach (var kvp in base.GetElementPairs()) yield return kvp;
      if (Identifier?.Any() == true) yield return new KeyValuePair<string,object>("identifier",Identifier);
      if (StatusElement is not null) yield return new KeyValuePair<string,object>("status",StatusElement);
      if (Category is not null) yield return new KeyValuePair<string,object>("category",Category);
      if (PriorityElement is not null) yield return new KeyValuePair<string,object>("priority",PriorityElement);
      if (Item is not null) yield return new KeyValuePair<string,object>("item",Item);
      if (Quantity is not null) yield return new KeyValuePair<string,object>("quantity",Quantity);
      if (Parameter?.Any() == true) yield return new KeyValuePair<string,object>("parameter",Parameter);
      if (Occurrence is not null) yield return new KeyValuePair<string,object>("occurrence",Occurrence);
      if (AuthoredOnElement is not null) yield return new KeyValuePair<string,object>("authoredOn",AuthoredOnElement);
      if (Requester is not null) yield return new KeyValuePair<string,object>("requester",Requester);
      if (Supplier?.Any() == true) yield return new KeyValuePair<string,object>("supplier",Supplier);
      if (ReasonCode?.Any() == true) yield return new KeyValuePair<string,object>("reasonCode",ReasonCode);
      if (ReasonReference?.Any() == true) yield return new KeyValuePair<string,object>("reasonReference",ReasonReference);
      if (DeliverFrom is not null) yield return new KeyValuePair<string,object>("deliverFrom",DeliverFrom);
      if (DeliverTo is not null) yield return new KeyValuePair<string,object>("deliverTo",DeliverTo);
    }

  }

}

// end of file
