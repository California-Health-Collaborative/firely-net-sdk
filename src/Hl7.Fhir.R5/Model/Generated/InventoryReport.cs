// <auto-generated/>
// Contents of: hl7.fhir.r5.core version: 5.0.0

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
  /// A report of inventory or stock items
  /// </summary>
  [Serializable]
  [DataContract]
  [FhirType("InventoryReport","http://hl7.org/fhir/StructureDefinition/InventoryReport", IsResource=true)]
  public partial class InventoryReport : Hl7.Fhir.Model.DomainResource
  {
    /// <summary>
    /// FHIR Type Name
    /// </summary>
    public override string TypeName { get { return "InventoryReport"; } }

    /// <summary>
    /// The status of the InventoryReport.
    /// (url: http://hl7.org/fhir/ValueSet/inventoryreport-status)
    /// (system: http://hl7.org/fhir/inventoryreport-status)
    /// </summary>
    [FhirEnumeration("InventoryReportStatus", "http://hl7.org/fhir/ValueSet/inventoryreport-status", "http://hl7.org/fhir/inventoryreport-status")]
    public enum InventoryReportStatus
    {
      /// <summary>
      /// The existence of the report is registered, but it is still without content or only some preliminary content.
      /// (system: http://hl7.org/fhir/inventoryreport-status)
      /// </summary>
      [EnumLiteral("draft"), Description("Draft")]
      Draft,
      /// <summary>
      /// The inventory report has been requested but there is no data available.
      /// (system: http://hl7.org/fhir/inventoryreport-status)
      /// </summary>
      [EnumLiteral("requested"), Description("Requested")]
      Requested,
      /// <summary>
      /// This report is submitted as current.
      /// (system: http://hl7.org/fhir/inventoryreport-status)
      /// </summary>
      [EnumLiteral("active"), Description("Active")]
      Active,
      /// <summary>
      /// The report has been withdrawn following a previous final release.  This electronic record should never have existed, though it is possible that real-world decisions were based on it.
      /// (system: http://hl7.org/fhir/inventoryreport-status)
      /// </summary>
      [EnumLiteral("entered-in-error"), Description("Entered in Error")]
      EnteredInError,
    }

    /// <summary>
    /// The type of count.
    /// (url: http://hl7.org/fhir/ValueSet/inventoryreport-counttype)
    /// (system: http://hl7.org/fhir/inventoryreport-counttype)
    /// </summary>
    [FhirEnumeration("InventoryCountType", "http://hl7.org/fhir/ValueSet/inventoryreport-counttype", "http://hl7.org/fhir/inventoryreport-counttype")]
    public enum InventoryCountType
    {
      /// <summary>
      /// The inventory report is a current absolute snapshot, i.e. it represents the quantities at hand.
      /// (system: http://hl7.org/fhir/inventoryreport-counttype)
      /// </summary>
      [EnumLiteral("snapshot"), Description("Snapshot")]
      Snapshot,
      /// <summary>
      /// The inventory report is about the difference between a previous count and a current count, i.e. it represents the items that have been added/subtracted from inventory.
      /// (system: http://hl7.org/fhir/inventoryreport-counttype)
      /// </summary>
      [EnumLiteral("difference"), Description("Difference")]
      Difference,
    }

    /// <summary>
    /// An inventory listing section (grouped by any of the attributes)
    /// </summary>
    [Serializable]
    [DataContract]
    [FhirType("InventoryReport#InventoryListing", IsNestedType=true)]
    [BackboneType("InventoryReport.inventoryListing")]
    public partial class InventoryListingComponent : Hl7.Fhir.Model.BackboneElement
    {
      /// <summary>
      /// FHIR Type Name
      /// </summary>
      public override string TypeName { get { return "InventoryReport#InventoryListing"; } }

      /// <summary>
      /// Location of the inventory items
      /// </summary>
      [FhirElement("location", Order=40)]
      [CLSCompliant(false)]
      [References("Location")]
      [DataMember]
      public Hl7.Fhir.Model.ResourceReference Location
      {
        get { return _Location; }
        set { _Location = value; OnPropertyChanged("Location"); }
      }

      private Hl7.Fhir.Model.ResourceReference _Location;

      /// <summary>
      /// The status of the items that are being reported
      /// </summary>
      [FhirElement("itemStatus", InSummary=true, Order=50)]
      [DataMember]
      public Hl7.Fhir.Model.CodeableConcept ItemStatus
      {
        get { return _ItemStatus; }
        set { _ItemStatus = value; OnPropertyChanged("ItemStatus"); }
      }

      private Hl7.Fhir.Model.CodeableConcept _ItemStatus;

      /// <summary>
      /// The date and time when the items were counted
      /// </summary>
      [FhirElement("countingDateTime", Order=60)]
      [DataMember]
      public Hl7.Fhir.Model.FhirDateTime CountingDateTimeElement
      {
        get { return _CountingDateTimeElement; }
        set { _CountingDateTimeElement = value; OnPropertyChanged("CountingDateTimeElement"); }
      }

      private Hl7.Fhir.Model.FhirDateTime _CountingDateTimeElement;

      /// <summary>
      /// The date and time when the items were counted
      /// </summary>
      /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
      [IgnoreDataMember]
      public string CountingDateTime
      {
        get { return CountingDateTimeElement != null ? CountingDateTimeElement.Value : null; }
        set
        {
          if (value == null)
            CountingDateTimeElement = null;
          else
            CountingDateTimeElement = new Hl7.Fhir.Model.FhirDateTime(value);
          OnPropertyChanged("CountingDateTime");
        }
      }

      /// <summary>
      /// The item or items in this listing
      /// </summary>
      [FhirElement("item", InSummary=true, Order=70)]
      [Cardinality(Min=0,Max=-1)]
      [DataMember]
      public List<Hl7.Fhir.Model.InventoryReport.ItemComponent> Item
      {
        get { if(_Item==null) _Item = new List<Hl7.Fhir.Model.InventoryReport.ItemComponent>(); return _Item; }
        set { _Item = value; OnPropertyChanged("Item"); }
      }

      private List<Hl7.Fhir.Model.InventoryReport.ItemComponent> _Item;

      public override IDeepCopyable CopyTo(IDeepCopyable other)
      {
        var dest = other as InventoryListingComponent;

        if (dest == null)
        {
          throw new ArgumentException("Can only copy to an object of the same type", "other");
        }

        base.CopyTo(dest);
        if(Location != null) dest.Location = (Hl7.Fhir.Model.ResourceReference)Location.DeepCopy();
        if(ItemStatus != null) dest.ItemStatus = (Hl7.Fhir.Model.CodeableConcept)ItemStatus.DeepCopy();
        if(CountingDateTimeElement != null) dest.CountingDateTimeElement = (Hl7.Fhir.Model.FhirDateTime)CountingDateTimeElement.DeepCopy();
        if(Item != null) dest.Item = new List<Hl7.Fhir.Model.InventoryReport.ItemComponent>(Item.DeepCopy());
        return dest;
      }

      public override IDeepCopyable DeepCopy()
      {
        return CopyTo(new InventoryListingComponent());
      }

      ///<inheritdoc />
      public override bool Matches(IDeepComparable other)
      {
        var otherT = other as InventoryListingComponent;
        if(otherT == null) return false;

        if(!base.Matches(otherT)) return false;
        if( !DeepComparable.Matches(Location, otherT.Location)) return false;
        if( !DeepComparable.Matches(ItemStatus, otherT.ItemStatus)) return false;
        if( !DeepComparable.Matches(CountingDateTimeElement, otherT.CountingDateTimeElement)) return false;
        if( !DeepComparable.Matches(Item, otherT.Item)) return false;

        return true;
      }

      public override bool IsExactly(IDeepComparable other)
      {
        var otherT = other as InventoryListingComponent;
        if(otherT == null) return false;

        if(!base.IsExactly(otherT)) return false;
        if( !DeepComparable.IsExactly(Location, otherT.Location)) return false;
        if( !DeepComparable.IsExactly(ItemStatus, otherT.ItemStatus)) return false;
        if( !DeepComparable.IsExactly(CountingDateTimeElement, otherT.CountingDateTimeElement)) return false;
        if( !DeepComparable.IsExactly(Item, otherT.Item)) return false;

        return true;
      }

      [IgnoreDataMember]
      public override IEnumerable<Base> Children
      {
        get
        {
          foreach (var item in base.Children) yield return item;
          if (Location != null) yield return Location;
          if (ItemStatus != null) yield return ItemStatus;
          if (CountingDateTimeElement != null) yield return CountingDateTimeElement;
          foreach (var elem in Item) { if (elem != null) yield return elem; }
        }
      }

      [IgnoreDataMember]
      public override IEnumerable<ElementValue> NamedChildren
      {
        get
        {
          foreach (var item in base.NamedChildren) yield return item;
          if (Location != null) yield return new ElementValue("location", Location);
          if (ItemStatus != null) yield return new ElementValue("itemStatus", ItemStatus);
          if (CountingDateTimeElement != null) yield return new ElementValue("countingDateTime", CountingDateTimeElement);
          foreach (var elem in Item) { if (elem != null) yield return new ElementValue("item", elem); }
        }
      }

      protected override bool TryGetValue(string key, out object value)
      {
        switch (key)
        {
          case "location":
            value = Location;
            return Location is not null;
          case "itemStatus":
            value = ItemStatus;
            return ItemStatus is not null;
          case "countingDateTime":
            value = CountingDateTimeElement;
            return CountingDateTimeElement is not null;
          case "item":
            value = Item;
            return Item?.Any() == true;
          default:
            return base.TryGetValue(key, out value);
        }

      }

      protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
      {
        foreach (var kvp in base.GetElementPairs()) yield return kvp;
        if (Location is not null) yield return new KeyValuePair<string,object>("location",Location);
        if (ItemStatus is not null) yield return new KeyValuePair<string,object>("itemStatus",ItemStatus);
        if (CountingDateTimeElement is not null) yield return new KeyValuePair<string,object>("countingDateTime",CountingDateTimeElement);
        if (Item?.Any() == true) yield return new KeyValuePair<string,object>("item",Item);
      }

    }

    /// <summary>
    /// The item or items in this listing
    /// </summary>
    [Serializable]
    [DataContract]
    [FhirType("InventoryReport#Item", IsNestedType=true)]
    [BackboneType("InventoryReport.inventoryListing.item")]
    public partial class ItemComponent : Hl7.Fhir.Model.BackboneElement
    {
      /// <summary>
      /// FHIR Type Name
      /// </summary>
      public override string TypeName { get { return "InventoryReport#Item"; } }

      /// <summary>
      /// The inventory category or classification of the items being reported
      /// </summary>
      [FhirElement("category", InSummary=true, Order=40)]
      [DataMember]
      public Hl7.Fhir.Model.CodeableConcept Category
      {
        get { return _Category; }
        set { _Category = value; OnPropertyChanged("Category"); }
      }

      private Hl7.Fhir.Model.CodeableConcept _Category;

      /// <summary>
      /// The quantity of the item or items being reported
      /// </summary>
      [FhirElement("quantity", InSummary=true, Order=50)]
      [Cardinality(Min=1,Max=1)]
      [DataMember]
      public Hl7.Fhir.Model.Quantity Quantity
      {
        get { return _Quantity; }
        set { _Quantity = value; OnPropertyChanged("Quantity"); }
      }

      private Hl7.Fhir.Model.Quantity _Quantity;

      /// <summary>
      /// The code or reference to the item type
      /// </summary>
      [FhirElement("item", InSummary=true, Order=60)]
      [Cardinality(Min=1,Max=1)]
      [DataMember]
      public Hl7.Fhir.Model.CodeableReference Item
      {
        get { return _Item; }
        set { _Item = value; OnPropertyChanged("Item"); }
      }

      private Hl7.Fhir.Model.CodeableReference _Item;

      public override IDeepCopyable CopyTo(IDeepCopyable other)
      {
        var dest = other as ItemComponent;

        if (dest == null)
        {
          throw new ArgumentException("Can only copy to an object of the same type", "other");
        }

        base.CopyTo(dest);
        if(Category != null) dest.Category = (Hl7.Fhir.Model.CodeableConcept)Category.DeepCopy();
        if(Quantity != null) dest.Quantity = (Hl7.Fhir.Model.Quantity)Quantity.DeepCopy();
        if(Item != null) dest.Item = (Hl7.Fhir.Model.CodeableReference)Item.DeepCopy();
        return dest;
      }

      public override IDeepCopyable DeepCopy()
      {
        return CopyTo(new ItemComponent());
      }

      ///<inheritdoc />
      public override bool Matches(IDeepComparable other)
      {
        var otherT = other as ItemComponent;
        if(otherT == null) return false;

        if(!base.Matches(otherT)) return false;
        if( !DeepComparable.Matches(Category, otherT.Category)) return false;
        if( !DeepComparable.Matches(Quantity, otherT.Quantity)) return false;
        if( !DeepComparable.Matches(Item, otherT.Item)) return false;

        return true;
      }

      public override bool IsExactly(IDeepComparable other)
      {
        var otherT = other as ItemComponent;
        if(otherT == null) return false;

        if(!base.IsExactly(otherT)) return false;
        if( !DeepComparable.IsExactly(Category, otherT.Category)) return false;
        if( !DeepComparable.IsExactly(Quantity, otherT.Quantity)) return false;
        if( !DeepComparable.IsExactly(Item, otherT.Item)) return false;

        return true;
      }

      [IgnoreDataMember]
      public override IEnumerable<Base> Children
      {
        get
        {
          foreach (var item in base.Children) yield return item;
          if (Category != null) yield return Category;
          if (Quantity != null) yield return Quantity;
          if (Item != null) yield return Item;
        }
      }

      [IgnoreDataMember]
      public override IEnumerable<ElementValue> NamedChildren
      {
        get
        {
          foreach (var item in base.NamedChildren) yield return item;
          if (Category != null) yield return new ElementValue("category", Category);
          if (Quantity != null) yield return new ElementValue("quantity", Quantity);
          if (Item != null) yield return new ElementValue("item", Item);
        }
      }

      protected override bool TryGetValue(string key, out object value)
      {
        switch (key)
        {
          case "category":
            value = Category;
            return Category is not null;
          case "quantity":
            value = Quantity;
            return Quantity is not null;
          case "item":
            value = Item;
            return Item is not null;
          default:
            return base.TryGetValue(key, out value);
        }

      }

      protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
      {
        foreach (var kvp in base.GetElementPairs()) yield return kvp;
        if (Category is not null) yield return new KeyValuePair<string,object>("category",Category);
        if (Quantity is not null) yield return new KeyValuePair<string,object>("quantity",Quantity);
        if (Item is not null) yield return new KeyValuePair<string,object>("item",Item);
      }

    }

    /// <summary>
    /// Business identifier for the report
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
    /// draft | requested | active | entered-in-error
    /// </summary>
    [FhirElement("status", InSummary=true, IsModifier=true, Order=100, FiveWs="FiveWs.status")]
    [DeclaredType(Type = typeof(Code))]
    [Binding("InventoryReportStatus")]
    [Cardinality(Min=1,Max=1)]
    [DataMember]
    public Code<Hl7.Fhir.Model.InventoryReport.InventoryReportStatus> StatusElement
    {
      get { return _StatusElement; }
      set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
    }

    private Code<Hl7.Fhir.Model.InventoryReport.InventoryReportStatus> _StatusElement;

    /// <summary>
    /// draft | requested | active | entered-in-error
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.InventoryReport.InventoryReportStatus? Status
    {
      get { return StatusElement != null ? StatusElement.Value : null; }
      set
      {
        if (value == null)
          StatusElement = null;
        else
          StatusElement = new Code<Hl7.Fhir.Model.InventoryReport.InventoryReportStatus>(value);
        OnPropertyChanged("Status");
      }
    }

    /// <summary>
    /// snapshot | difference
    /// </summary>
    [FhirElement("countType", InSummary=true, IsModifier=true, Order=110)]
    [DeclaredType(Type = typeof(Code))]
    [Binding("InventoryCountType")]
    [Cardinality(Min=1,Max=1)]
    [DataMember]
    public Code<Hl7.Fhir.Model.InventoryReport.InventoryCountType> CountTypeElement
    {
      get { return _CountTypeElement; }
      set { _CountTypeElement = value; OnPropertyChanged("CountTypeElement"); }
    }

    private Code<Hl7.Fhir.Model.InventoryReport.InventoryCountType> _CountTypeElement;

    /// <summary>
    /// snapshot | difference
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public Hl7.Fhir.Model.InventoryReport.InventoryCountType? CountType
    {
      get { return CountTypeElement != null ? CountTypeElement.Value : null; }
      set
      {
        if (value == null)
          CountTypeElement = null;
        else
          CountTypeElement = new Code<Hl7.Fhir.Model.InventoryReport.InventoryCountType>(value);
        OnPropertyChanged("CountType");
      }
    }

    /// <summary>
    /// addition | subtraction
    /// </summary>
    [FhirElement("operationType", InSummary=true, Order=120)]
    [DataMember]
    public Hl7.Fhir.Model.CodeableConcept OperationType
    {
      get { return _OperationType; }
      set { _OperationType = value; OnPropertyChanged("OperationType"); }
    }

    private Hl7.Fhir.Model.CodeableConcept _OperationType;

    /// <summary>
    /// The reason for this count - regular count, ad-hoc count, new arrivals, etc
    /// </summary>
    [FhirElement("operationTypeReason", InSummary=true, Order=130)]
    [DataMember]
    public Hl7.Fhir.Model.CodeableConcept OperationTypeReason
    {
      get { return _OperationTypeReason; }
      set { _OperationTypeReason = value; OnPropertyChanged("OperationTypeReason"); }
    }

    private Hl7.Fhir.Model.CodeableConcept _OperationTypeReason;

    /// <summary>
    /// When the report has been submitted
    /// </summary>
    [FhirElement("reportedDateTime", InSummary=true, Order=140)]
    [Cardinality(Min=1,Max=1)]
    [DataMember]
    public Hl7.Fhir.Model.FhirDateTime ReportedDateTimeElement
    {
      get { return _ReportedDateTimeElement; }
      set { _ReportedDateTimeElement = value; OnPropertyChanged("ReportedDateTimeElement"); }
    }

    private Hl7.Fhir.Model.FhirDateTime _ReportedDateTimeElement;

    /// <summary>
    /// When the report has been submitted
    /// </summary>
    /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
    [IgnoreDataMember]
    public string ReportedDateTime
    {
      get { return ReportedDateTimeElement != null ? ReportedDateTimeElement.Value : null; }
      set
      {
        if (value == null)
          ReportedDateTimeElement = null;
        else
          ReportedDateTimeElement = new Hl7.Fhir.Model.FhirDateTime(value);
        OnPropertyChanged("ReportedDateTime");
      }
    }

    /// <summary>
    /// Who submits the report
    /// </summary>
    [FhirElement("reporter", Order=150)]
    [CLSCompliant(false)]
    [References("Practitioner","Patient","RelatedPerson","Device")]
    [DataMember]
    public Hl7.Fhir.Model.ResourceReference Reporter
    {
      get { return _Reporter; }
      set { _Reporter = value; OnPropertyChanged("Reporter"); }
    }

    private Hl7.Fhir.Model.ResourceReference _Reporter;

    /// <summary>
    /// The period the report refers to
    /// </summary>
    [FhirElement("reportingPeriod", Order=160)]
    [DataMember]
    public Hl7.Fhir.Model.Period ReportingPeriod
    {
      get { return _ReportingPeriod; }
      set { _ReportingPeriod = value; OnPropertyChanged("ReportingPeriod"); }
    }

    private Hl7.Fhir.Model.Period _ReportingPeriod;

    /// <summary>
    /// An inventory listing section (grouped by any of the attributes)
    /// </summary>
    [FhirElement("inventoryListing", InSummary=true, Order=170)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.InventoryReport.InventoryListingComponent> InventoryListing
    {
      get { if(_InventoryListing==null) _InventoryListing = new List<Hl7.Fhir.Model.InventoryReport.InventoryListingComponent>(); return _InventoryListing; }
      set { _InventoryListing = value; OnPropertyChanged("InventoryListing"); }
    }

    private List<Hl7.Fhir.Model.InventoryReport.InventoryListingComponent> _InventoryListing;

    /// <summary>
    /// A note associated with the InventoryReport
    /// </summary>
    [FhirElement("note", Order=180)]
    [Cardinality(Min=0,Max=-1)]
    [DataMember]
    public List<Hl7.Fhir.Model.Annotation> Note
    {
      get { if(_Note==null) _Note = new List<Hl7.Fhir.Model.Annotation>(); return _Note; }
      set { _Note = value; OnPropertyChanged("Note"); }
    }

    private List<Hl7.Fhir.Model.Annotation> _Note;

    public override IDeepCopyable CopyTo(IDeepCopyable other)
    {
      var dest = other as InventoryReport;

      if (dest == null)
      {
        throw new ArgumentException("Can only copy to an object of the same type", "other");
      }

      base.CopyTo(dest);
      if(Identifier != null) dest.Identifier = new List<Hl7.Fhir.Model.Identifier>(Identifier.DeepCopy());
      if(StatusElement != null) dest.StatusElement = (Code<Hl7.Fhir.Model.InventoryReport.InventoryReportStatus>)StatusElement.DeepCopy();
      if(CountTypeElement != null) dest.CountTypeElement = (Code<Hl7.Fhir.Model.InventoryReport.InventoryCountType>)CountTypeElement.DeepCopy();
      if(OperationType != null) dest.OperationType = (Hl7.Fhir.Model.CodeableConcept)OperationType.DeepCopy();
      if(OperationTypeReason != null) dest.OperationTypeReason = (Hl7.Fhir.Model.CodeableConcept)OperationTypeReason.DeepCopy();
      if(ReportedDateTimeElement != null) dest.ReportedDateTimeElement = (Hl7.Fhir.Model.FhirDateTime)ReportedDateTimeElement.DeepCopy();
      if(Reporter != null) dest.Reporter = (Hl7.Fhir.Model.ResourceReference)Reporter.DeepCopy();
      if(ReportingPeriod != null) dest.ReportingPeriod = (Hl7.Fhir.Model.Period)ReportingPeriod.DeepCopy();
      if(InventoryListing != null) dest.InventoryListing = new List<Hl7.Fhir.Model.InventoryReport.InventoryListingComponent>(InventoryListing.DeepCopy());
      if(Note != null) dest.Note = new List<Hl7.Fhir.Model.Annotation>(Note.DeepCopy());
      return dest;
    }

    public override IDeepCopyable DeepCopy()
    {
      return CopyTo(new InventoryReport());
    }

    ///<inheritdoc />
    public override bool Matches(IDeepComparable other)
    {
      var otherT = other as InventoryReport;
      if(otherT == null) return false;

      if(!base.Matches(otherT)) return false;
      if( !DeepComparable.Matches(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.Matches(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.Matches(CountTypeElement, otherT.CountTypeElement)) return false;
      if( !DeepComparable.Matches(OperationType, otherT.OperationType)) return false;
      if( !DeepComparable.Matches(OperationTypeReason, otherT.OperationTypeReason)) return false;
      if( !DeepComparable.Matches(ReportedDateTimeElement, otherT.ReportedDateTimeElement)) return false;
      if( !DeepComparable.Matches(Reporter, otherT.Reporter)) return false;
      if( !DeepComparable.Matches(ReportingPeriod, otherT.ReportingPeriod)) return false;
      if( !DeepComparable.Matches(InventoryListing, otherT.InventoryListing)) return false;
      if( !DeepComparable.Matches(Note, otherT.Note)) return false;

      return true;
    }

    public override bool IsExactly(IDeepComparable other)
    {
      var otherT = other as InventoryReport;
      if(otherT == null) return false;

      if(!base.IsExactly(otherT)) return false;
      if( !DeepComparable.IsExactly(Identifier, otherT.Identifier)) return false;
      if( !DeepComparable.IsExactly(StatusElement, otherT.StatusElement)) return false;
      if( !DeepComparable.IsExactly(CountTypeElement, otherT.CountTypeElement)) return false;
      if( !DeepComparable.IsExactly(OperationType, otherT.OperationType)) return false;
      if( !DeepComparable.IsExactly(OperationTypeReason, otherT.OperationTypeReason)) return false;
      if( !DeepComparable.IsExactly(ReportedDateTimeElement, otherT.ReportedDateTimeElement)) return false;
      if( !DeepComparable.IsExactly(Reporter, otherT.Reporter)) return false;
      if( !DeepComparable.IsExactly(ReportingPeriod, otherT.ReportingPeriod)) return false;
      if( !DeepComparable.IsExactly(InventoryListing, otherT.InventoryListing)) return false;
      if( !DeepComparable.IsExactly(Note, otherT.Note)) return false;

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
        if (CountTypeElement != null) yield return CountTypeElement;
        if (OperationType != null) yield return OperationType;
        if (OperationTypeReason != null) yield return OperationTypeReason;
        if (ReportedDateTimeElement != null) yield return ReportedDateTimeElement;
        if (Reporter != null) yield return Reporter;
        if (ReportingPeriod != null) yield return ReportingPeriod;
        foreach (var elem in InventoryListing) { if (elem != null) yield return elem; }
        foreach (var elem in Note) { if (elem != null) yield return elem; }
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
        if (CountTypeElement != null) yield return new ElementValue("countType", CountTypeElement);
        if (OperationType != null) yield return new ElementValue("operationType", OperationType);
        if (OperationTypeReason != null) yield return new ElementValue("operationTypeReason", OperationTypeReason);
        if (ReportedDateTimeElement != null) yield return new ElementValue("reportedDateTime", ReportedDateTimeElement);
        if (Reporter != null) yield return new ElementValue("reporter", Reporter);
        if (ReportingPeriod != null) yield return new ElementValue("reportingPeriod", ReportingPeriod);
        foreach (var elem in InventoryListing) { if (elem != null) yield return new ElementValue("inventoryListing", elem); }
        foreach (var elem in Note) { if (elem != null) yield return new ElementValue("note", elem); }
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
        case "countType":
          value = CountTypeElement;
          return CountTypeElement is not null;
        case "operationType":
          value = OperationType;
          return OperationType is not null;
        case "operationTypeReason":
          value = OperationTypeReason;
          return OperationTypeReason is not null;
        case "reportedDateTime":
          value = ReportedDateTimeElement;
          return ReportedDateTimeElement is not null;
        case "reporter":
          value = Reporter;
          return Reporter is not null;
        case "reportingPeriod":
          value = ReportingPeriod;
          return ReportingPeriod is not null;
        case "inventoryListing":
          value = InventoryListing;
          return InventoryListing?.Any() == true;
        case "note":
          value = Note;
          return Note?.Any() == true;
        default:
          return base.TryGetValue(key, out value);
      }

    }

    protected override IEnumerable<KeyValuePair<string, object>> GetElementPairs()
    {
      foreach (var kvp in base.GetElementPairs()) yield return kvp;
      if (Identifier?.Any() == true) yield return new KeyValuePair<string,object>("identifier",Identifier);
      if (StatusElement is not null) yield return new KeyValuePair<string,object>("status",StatusElement);
      if (CountTypeElement is not null) yield return new KeyValuePair<string,object>("countType",CountTypeElement);
      if (OperationType is not null) yield return new KeyValuePair<string,object>("operationType",OperationType);
      if (OperationTypeReason is not null) yield return new KeyValuePair<string,object>("operationTypeReason",OperationTypeReason);
      if (ReportedDateTimeElement is not null) yield return new KeyValuePair<string,object>("reportedDateTime",ReportedDateTimeElement);
      if (Reporter is not null) yield return new KeyValuePair<string,object>("reporter",Reporter);
      if (ReportingPeriod is not null) yield return new KeyValuePair<string,object>("reportingPeriod",ReportingPeriod);
      if (InventoryListing?.Any() == true) yield return new KeyValuePair<string,object>("inventoryListing",InventoryListing);
      if (Note?.Any() == true) yield return new KeyValuePair<string,object>("note",Note);
    }

  }

}

// end of file
