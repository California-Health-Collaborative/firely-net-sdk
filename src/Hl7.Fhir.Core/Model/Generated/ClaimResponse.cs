﻿using System;
using System.Collections.Generic;
using Hl7.Fhir.Introspection;
using Hl7.Fhir.Validation;
using System.Linq;
using System.Runtime.Serialization;

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

//
// Generated on Fri, Dec 5, 2014 10:08+0100 for FHIR v0.3.0
//
namespace Hl7.Fhir.Model
{
    /// <summary>
    /// Remittance resource
    /// </summary>
    [FhirType("ClaimResponse", IsResource=true)]
    [DataContract]
    public partial class ClaimResponse : Hl7.Fhir.Model.DomainResource, System.ComponentModel.INotifyPropertyChanged
    {
        public override ResourceType ResourceType { get { return ResourceType.ClaimResponse; } }
        public override string TypeName { get { return "ClaimResponse"; } }
        
        /// <summary>
        /// The outcome of the processing.
        /// </summary>
        [FhirEnumeration("RemittanceOutcome")]
        public enum RemittanceOutcome
        {
            /// <summary>
            /// The processing completed without errors.
            /// </summary>
            [EnumLiteral("complete")]
            Complete,
            /// <summary>
            /// The processing identified with errors.
            /// </summary>
            [EnumLiteral("error")]
            Error,
        }
        
        /// <summary>
        /// The presentation types of notes
        /// </summary>
        [FhirEnumeration("NoteType")]
        public enum NoteType
        {
            /// <summary>
            /// Display the note.
            /// </summary>
            [EnumLiteral("display")]
            Display,
            /// <summary>
            /// Print the note on the form.
            /// </summary>
            [EnumLiteral("print")]
            Print,
            /// <summary>
            /// Print the note for the operator.
            /// </summary>
            [EnumLiteral("printoper")]
            Printoper,
        }
        
        [FhirType("NotesComponent")]
        [DataContract]
        public partial class NotesComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "NotesComponent"; } }
            
            /// <summary>
            /// Note Number for this note
            /// </summary>
            [FhirElement("number", InSummary=true, Order=20)]
            [DataMember]
            public Hl7.Fhir.Model.Integer NumberElement
            {
                get { return _NumberElement; }
                set { _NumberElement = value; OnPropertyChanged("NumberElement"); }
            }
            private Hl7.Fhir.Model.Integer _NumberElement;
            
            /// <summary>
            /// Note Number for this note
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public int? Number
            {
                get { return NumberElement != null ? NumberElement.Value : null; }
                set
                {
                    if(value == null)
                      NumberElement = null; 
                    else
                      NumberElement = new Hl7.Fhir.Model.Integer(value);
                    OnPropertyChanged("Number");
                }
            }
            
            /// <summary>
            /// display | print | printoper
            /// </summary>
            [FhirElement("type", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Type
            {
                get { return _Type; }
                set { _Type = value; OnPropertyChanged("Type"); }
            }
            private Hl7.Fhir.Model.Coding _Type;
            
            /// <summary>
            /// Note explanitory text
            /// </summary>
            [FhirElement("text", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.FhirString TextElement
            {
                get { return _TextElement; }
                set { _TextElement = value; OnPropertyChanged("TextElement"); }
            }
            private Hl7.Fhir.Model.FhirString _TextElement;
            
            /// <summary>
            /// Note explanitory text
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public string Text
            {
                get { return TextElement != null ? TextElement.Value : null; }
                set
                {
                    if(value == null)
                      TextElement = null; 
                    else
                      TextElement = new Hl7.Fhir.Model.FhirString(value);
                    OnPropertyChanged("Text");
                }
            }
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as NotesComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(NumberElement != null) dest.NumberElement = (Hl7.Fhir.Model.Integer)NumberElement.DeepCopy();
                    if(Type != null) dest.Type = (Hl7.Fhir.Model.Coding)Type.DeepCopy();
                    if(TextElement != null) dest.TextElement = (Hl7.Fhir.Model.FhirString)TextElement.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new NotesComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as NotesComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(NumberElement, otherT.NumberElement)) return false;
                if( !DeepComparable.Matches(Type, otherT.Type)) return false;
                if( !DeepComparable.Matches(TextElement, otherT.TextElement)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as NotesComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(NumberElement, otherT.NumberElement)) return false;
                if( !DeepComparable.IsExactly(Type, otherT.Type)) return false;
                if( !DeepComparable.IsExactly(TextElement, otherT.TextElement)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("ItemsComponent")]
        [DataContract]
        public partial class ItemsComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "ItemsComponent"; } }
            
            /// <summary>
            /// Service instance
            /// </summary>
            [FhirElement("sequenceLinkId", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Integer SequenceLinkIdElement
            {
                get { return _SequenceLinkIdElement; }
                set { _SequenceLinkIdElement = value; OnPropertyChanged("SequenceLinkIdElement"); }
            }
            private Hl7.Fhir.Model.Integer _SequenceLinkIdElement;
            
            /// <summary>
            /// Service instance
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public int? SequenceLinkId
            {
                get { return SequenceLinkIdElement != null ? SequenceLinkIdElement.Value : null; }
                set
                {
                    if(value == null)
                      SequenceLinkIdElement = null; 
                    else
                      SequenceLinkIdElement = new Hl7.Fhir.Model.Integer(value);
                    OnPropertyChanged("SequenceLinkId");
                }
            }
            
            /// <summary>
            /// List of note numbers which apply
            /// </summary>
            [FhirElement("noteNumber", InSummary=true, Order=30)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.Integer> NoteNumberElement
            {
                get { if(_NoteNumberElement==null) _NoteNumberElement = new List<Hl7.Fhir.Model.Integer>(); return _NoteNumberElement; }
                set { _NoteNumberElement = value; OnPropertyChanged("NoteNumberElement"); }
            }
            private List<Hl7.Fhir.Model.Integer> _NoteNumberElement;
            
            /// <summary>
            /// List of note numbers which apply
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public IEnumerable<int?> NoteNumber
            {
                get { return NoteNumberElement != null ? NoteNumberElement.Select(elem => elem.Value) : null; }
                set
                {
                    if(value == null)
                      NoteNumberElement = null; 
                    else
                      NoteNumberElement = new List<Hl7.Fhir.Model.Integer>(value.Select(elem=>new Hl7.Fhir.Model.Integer(elem)));
                    OnPropertyChanged("NoteNumber");
                }
            }
            
            /// <summary>
            /// Adjudication details
            /// </summary>
            [FhirElement("adjudication", InSummary=true, Order=40)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.ItemAdjudicationComponent> Adjudication
            {
                get { if(_Adjudication==null) _Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.ItemAdjudicationComponent>(); return _Adjudication; }
                set { _Adjudication = value; OnPropertyChanged("Adjudication"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.ItemAdjudicationComponent> _Adjudication;
            
            /// <summary>
            /// Detail line items
            /// </summary>
            [FhirElement("detail", InSummary=true, Order=50)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.ItemDetailComponent> Detail
            {
                get { if(_Detail==null) _Detail = new List<Hl7.Fhir.Model.ClaimResponse.ItemDetailComponent>(); return _Detail; }
                set { _Detail = value; OnPropertyChanged("Detail"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.ItemDetailComponent> _Detail;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as ItemsComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(SequenceLinkIdElement != null) dest.SequenceLinkIdElement = (Hl7.Fhir.Model.Integer)SequenceLinkIdElement.DeepCopy();
                    if(NoteNumberElement != null) dest.NoteNumberElement = new List<Hl7.Fhir.Model.Integer>(NoteNumberElement.DeepCopy());
                    if(Adjudication != null) dest.Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.ItemAdjudicationComponent>(Adjudication.DeepCopy());
                    if(Detail != null) dest.Detail = new List<Hl7.Fhir.Model.ClaimResponse.ItemDetailComponent>(Detail.DeepCopy());
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new ItemsComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as ItemsComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.Matches(NoteNumberElement, otherT.NoteNumberElement)) return false;
                if( !DeepComparable.Matches(Adjudication, otherT.Adjudication)) return false;
                if( !DeepComparable.Matches(Detail, otherT.Detail)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as ItemsComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(NoteNumberElement, otherT.NoteNumberElement)) return false;
                if( !DeepComparable.IsExactly(Adjudication, otherT.Adjudication)) return false;
                if( !DeepComparable.IsExactly(Detail, otherT.Detail)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("ItemSubdetailComponent")]
        [DataContract]
        public partial class ItemSubdetailComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "ItemSubdetailComponent"; } }
            
            /// <summary>
            /// Service instance
            /// </summary>
            [FhirElement("sequenceLinkId", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Integer SequenceLinkIdElement
            {
                get { return _SequenceLinkIdElement; }
                set { _SequenceLinkIdElement = value; OnPropertyChanged("SequenceLinkIdElement"); }
            }
            private Hl7.Fhir.Model.Integer _SequenceLinkIdElement;
            
            /// <summary>
            /// Service instance
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public int? SequenceLinkId
            {
                get { return SequenceLinkIdElement != null ? SequenceLinkIdElement.Value : null; }
                set
                {
                    if(value == null)
                      SequenceLinkIdElement = null; 
                    else
                      SequenceLinkIdElement = new Hl7.Fhir.Model.Integer(value);
                    OnPropertyChanged("SequenceLinkId");
                }
            }
            
            /// <summary>
            /// Subdetail adjudication
            /// </summary>
            [FhirElement("adjudication", InSummary=true, Order=30)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.SubdetailAdjudicationComponent> Adjudication
            {
                get { if(_Adjudication==null) _Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.SubdetailAdjudicationComponent>(); return _Adjudication; }
                set { _Adjudication = value; OnPropertyChanged("Adjudication"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.SubdetailAdjudicationComponent> _Adjudication;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as ItemSubdetailComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(SequenceLinkIdElement != null) dest.SequenceLinkIdElement = (Hl7.Fhir.Model.Integer)SequenceLinkIdElement.DeepCopy();
                    if(Adjudication != null) dest.Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.SubdetailAdjudicationComponent>(Adjudication.DeepCopy());
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new ItemSubdetailComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as ItemSubdetailComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.Matches(Adjudication, otherT.Adjudication)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as ItemSubdetailComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(Adjudication, otherT.Adjudication)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("AddedItemDetailAdjudicationComponent")]
        [DataContract]
        public partial class AddedItemDetailAdjudicationComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "AddedItemDetailAdjudicationComponent"; } }
            
            /// <summary>
            /// Adjudication category such as co-pay, eligible, benefit, etc.
            /// </summary>
            [FhirElement("code", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Code
            {
                get { return _Code; }
                set { _Code = value; OnPropertyChanged("Code"); }
            }
            private Hl7.Fhir.Model.Coding _Code;
            
            /// <summary>
            /// Monitary amount
            /// </summary>
            [FhirElement("amount", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Money Amount
            {
                get { return _Amount; }
                set { _Amount = value; OnPropertyChanged("Amount"); }
            }
            private Hl7.Fhir.Model.Money _Amount;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            [FhirElement("value", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.FhirDecimal ValueElement
            {
                get { return _ValueElement; }
                set { _ValueElement = value; OnPropertyChanged("ValueElement"); }
            }
            private Hl7.Fhir.Model.FhirDecimal _ValueElement;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public decimal? Value
            {
                get { return ValueElement != null ? ValueElement.Value : null; }
                set
                {
                    if(value == null)
                      ValueElement = null; 
                    else
                      ValueElement = new Hl7.Fhir.Model.FhirDecimal(value);
                    OnPropertyChanged("Value");
                }
            }
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as AddedItemDetailAdjudicationComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(Code != null) dest.Code = (Hl7.Fhir.Model.Coding)Code.DeepCopy();
                    if(Amount != null) dest.Amount = (Hl7.Fhir.Model.Money)Amount.DeepCopy();
                    if(ValueElement != null) dest.ValueElement = (Hl7.Fhir.Model.FhirDecimal)ValueElement.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new AddedItemDetailAdjudicationComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as AddedItemDetailAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(Code, otherT.Code)) return false;
                if( !DeepComparable.Matches(Amount, otherT.Amount)) return false;
                if( !DeepComparable.Matches(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as AddedItemDetailAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(Code, otherT.Code)) return false;
                if( !DeepComparable.IsExactly(Amount, otherT.Amount)) return false;
                if( !DeepComparable.IsExactly(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("AddedItemAdjudicationComponent")]
        [DataContract]
        public partial class AddedItemAdjudicationComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "AddedItemAdjudicationComponent"; } }
            
            /// <summary>
            /// Adjudication category such as co-pay, eligible, benefit, etc.
            /// </summary>
            [FhirElement("code", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Code
            {
                get { return _Code; }
                set { _Code = value; OnPropertyChanged("Code"); }
            }
            private Hl7.Fhir.Model.Coding _Code;
            
            /// <summary>
            /// Monitary amount
            /// </summary>
            [FhirElement("amount", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Money Amount
            {
                get { return _Amount; }
                set { _Amount = value; OnPropertyChanged("Amount"); }
            }
            private Hl7.Fhir.Model.Money _Amount;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            [FhirElement("value", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.FhirDecimal ValueElement
            {
                get { return _ValueElement; }
                set { _ValueElement = value; OnPropertyChanged("ValueElement"); }
            }
            private Hl7.Fhir.Model.FhirDecimal _ValueElement;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public decimal? Value
            {
                get { return ValueElement != null ? ValueElement.Value : null; }
                set
                {
                    if(value == null)
                      ValueElement = null; 
                    else
                      ValueElement = new Hl7.Fhir.Model.FhirDecimal(value);
                    OnPropertyChanged("Value");
                }
            }
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as AddedItemAdjudicationComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(Code != null) dest.Code = (Hl7.Fhir.Model.Coding)Code.DeepCopy();
                    if(Amount != null) dest.Amount = (Hl7.Fhir.Model.Money)Amount.DeepCopy();
                    if(ValueElement != null) dest.ValueElement = (Hl7.Fhir.Model.FhirDecimal)ValueElement.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new AddedItemAdjudicationComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as AddedItemAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(Code, otherT.Code)) return false;
                if( !DeepComparable.Matches(Amount, otherT.Amount)) return false;
                if( !DeepComparable.Matches(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as AddedItemAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(Code, otherT.Code)) return false;
                if( !DeepComparable.IsExactly(Amount, otherT.Amount)) return false;
                if( !DeepComparable.IsExactly(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("DetailAdjudicationComponent")]
        [DataContract]
        public partial class DetailAdjudicationComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "DetailAdjudicationComponent"; } }
            
            /// <summary>
            /// Adjudication category such as co-pay, eligible, benefit, etc.
            /// </summary>
            [FhirElement("code", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Code
            {
                get { return _Code; }
                set { _Code = value; OnPropertyChanged("Code"); }
            }
            private Hl7.Fhir.Model.Coding _Code;
            
            /// <summary>
            /// Monitary amount
            /// </summary>
            [FhirElement("amount", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Money Amount
            {
                get { return _Amount; }
                set { _Amount = value; OnPropertyChanged("Amount"); }
            }
            private Hl7.Fhir.Model.Money _Amount;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            [FhirElement("value", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.FhirDecimal ValueElement
            {
                get { return _ValueElement; }
                set { _ValueElement = value; OnPropertyChanged("ValueElement"); }
            }
            private Hl7.Fhir.Model.FhirDecimal _ValueElement;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public decimal? Value
            {
                get { return ValueElement != null ? ValueElement.Value : null; }
                set
                {
                    if(value == null)
                      ValueElement = null; 
                    else
                      ValueElement = new Hl7.Fhir.Model.FhirDecimal(value);
                    OnPropertyChanged("Value");
                }
            }
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as DetailAdjudicationComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(Code != null) dest.Code = (Hl7.Fhir.Model.Coding)Code.DeepCopy();
                    if(Amount != null) dest.Amount = (Hl7.Fhir.Model.Money)Amount.DeepCopy();
                    if(ValueElement != null) dest.ValueElement = (Hl7.Fhir.Model.FhirDecimal)ValueElement.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new DetailAdjudicationComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as DetailAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(Code, otherT.Code)) return false;
                if( !DeepComparable.Matches(Amount, otherT.Amount)) return false;
                if( !DeepComparable.Matches(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as DetailAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(Code, otherT.Code)) return false;
                if( !DeepComparable.IsExactly(Amount, otherT.Amount)) return false;
                if( !DeepComparable.IsExactly(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("ErrorsComponent")]
        [DataContract]
        public partial class ErrorsComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "ErrorsComponent"; } }
            
            /// <summary>
            /// Item sequence number
            /// </summary>
            [FhirElement("sequenceLinkId", InSummary=true, Order=20)]
            [DataMember]
            public Hl7.Fhir.Model.Integer SequenceLinkIdElement
            {
                get { return _SequenceLinkIdElement; }
                set { _SequenceLinkIdElement = value; OnPropertyChanged("SequenceLinkIdElement"); }
            }
            private Hl7.Fhir.Model.Integer _SequenceLinkIdElement;
            
            /// <summary>
            /// Item sequence number
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public int? SequenceLinkId
            {
                get { return SequenceLinkIdElement != null ? SequenceLinkIdElement.Value : null; }
                set
                {
                    if(value == null)
                      SequenceLinkIdElement = null; 
                    else
                      SequenceLinkIdElement = new Hl7.Fhir.Model.Integer(value);
                    OnPropertyChanged("SequenceLinkId");
                }
            }
            
            /// <summary>
            /// Detail sequence number
            /// </summary>
            [FhirElement("detailSequenceLinkId", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Integer DetailSequenceLinkIdElement
            {
                get { return _DetailSequenceLinkIdElement; }
                set { _DetailSequenceLinkIdElement = value; OnPropertyChanged("DetailSequenceLinkIdElement"); }
            }
            private Hl7.Fhir.Model.Integer _DetailSequenceLinkIdElement;
            
            /// <summary>
            /// Detail sequence number
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public int? DetailSequenceLinkId
            {
                get { return DetailSequenceLinkIdElement != null ? DetailSequenceLinkIdElement.Value : null; }
                set
                {
                    if(value == null)
                      DetailSequenceLinkIdElement = null; 
                    else
                      DetailSequenceLinkIdElement = new Hl7.Fhir.Model.Integer(value);
                    OnPropertyChanged("DetailSequenceLinkId");
                }
            }
            
            /// <summary>
            /// Subdetail sequence number
            /// </summary>
            [FhirElement("subdetailSequenceLinkId", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.Integer SubdetailSequenceLinkIdElement
            {
                get { return _SubdetailSequenceLinkIdElement; }
                set { _SubdetailSequenceLinkIdElement = value; OnPropertyChanged("SubdetailSequenceLinkIdElement"); }
            }
            private Hl7.Fhir.Model.Integer _SubdetailSequenceLinkIdElement;
            
            /// <summary>
            /// Subdetail sequence number
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public int? SubdetailSequenceLinkId
            {
                get { return SubdetailSequenceLinkIdElement != null ? SubdetailSequenceLinkIdElement.Value : null; }
                set
                {
                    if(value == null)
                      SubdetailSequenceLinkIdElement = null; 
                    else
                      SubdetailSequenceLinkIdElement = new Hl7.Fhir.Model.Integer(value);
                    OnPropertyChanged("SubdetailSequenceLinkId");
                }
            }
            
            /// <summary>
            /// Error code detailing processing issues
            /// </summary>
            [FhirElement("code", InSummary=true, Order=50)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Code
            {
                get { return _Code; }
                set { _Code = value; OnPropertyChanged("Code"); }
            }
            private Hl7.Fhir.Model.Coding _Code;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as ErrorsComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(SequenceLinkIdElement != null) dest.SequenceLinkIdElement = (Hl7.Fhir.Model.Integer)SequenceLinkIdElement.DeepCopy();
                    if(DetailSequenceLinkIdElement != null) dest.DetailSequenceLinkIdElement = (Hl7.Fhir.Model.Integer)DetailSequenceLinkIdElement.DeepCopy();
                    if(SubdetailSequenceLinkIdElement != null) dest.SubdetailSequenceLinkIdElement = (Hl7.Fhir.Model.Integer)SubdetailSequenceLinkIdElement.DeepCopy();
                    if(Code != null) dest.Code = (Hl7.Fhir.Model.Coding)Code.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new ErrorsComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as ErrorsComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.Matches(DetailSequenceLinkIdElement, otherT.DetailSequenceLinkIdElement)) return false;
                if( !DeepComparable.Matches(SubdetailSequenceLinkIdElement, otherT.SubdetailSequenceLinkIdElement)) return false;
                if( !DeepComparable.Matches(Code, otherT.Code)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as ErrorsComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(DetailSequenceLinkIdElement, otherT.DetailSequenceLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(SubdetailSequenceLinkIdElement, otherT.SubdetailSequenceLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(Code, otherT.Code)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("AddedItemComponent")]
        [DataContract]
        public partial class AddedItemComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "AddedItemComponent"; } }
            
            /// <summary>
            /// Service instances
            /// </summary>
            [FhirElement("sequenceLinkId", InSummary=true, Order=20)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.Integer> SequenceLinkIdElement
            {
                get { if(_SequenceLinkIdElement==null) _SequenceLinkIdElement = new List<Hl7.Fhir.Model.Integer>(); return _SequenceLinkIdElement; }
                set { _SequenceLinkIdElement = value; OnPropertyChanged("SequenceLinkIdElement"); }
            }
            private List<Hl7.Fhir.Model.Integer> _SequenceLinkIdElement;
            
            /// <summary>
            /// Service instances
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public IEnumerable<int?> SequenceLinkId
            {
                get { return SequenceLinkIdElement != null ? SequenceLinkIdElement.Select(elem => elem.Value) : null; }
                set
                {
                    if(value == null)
                      SequenceLinkIdElement = null; 
                    else
                      SequenceLinkIdElement = new List<Hl7.Fhir.Model.Integer>(value.Select(elem=>new Hl7.Fhir.Model.Integer(elem)));
                    OnPropertyChanged("SequenceLinkId");
                }
            }
            
            /// <summary>
            /// Group, Service or Product
            /// </summary>
            [FhirElement("service", InSummary=true, Order=30)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Service
            {
                get { return _Service; }
                set { _Service = value; OnPropertyChanged("Service"); }
            }
            private Hl7.Fhir.Model.Coding _Service;
            
            /// <summary>
            /// Professional fee or Product charge
            /// </summary>
            [FhirElement("fee", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.Money Fee
            {
                get { return _Fee; }
                set { _Fee = value; OnPropertyChanged("Fee"); }
            }
            private Hl7.Fhir.Model.Money _Fee;
            
            /// <summary>
            /// List of note numbers which apply
            /// </summary>
            [FhirElement("noteNumberLinkId", InSummary=true, Order=50)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.Integer> NoteNumberLinkIdElement
            {
                get { if(_NoteNumberLinkIdElement==null) _NoteNumberLinkIdElement = new List<Hl7.Fhir.Model.Integer>(); return _NoteNumberLinkIdElement; }
                set { _NoteNumberLinkIdElement = value; OnPropertyChanged("NoteNumberLinkIdElement"); }
            }
            private List<Hl7.Fhir.Model.Integer> _NoteNumberLinkIdElement;
            
            /// <summary>
            /// List of note numbers which apply
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public IEnumerable<int?> NoteNumberLinkId
            {
                get { return NoteNumberLinkIdElement != null ? NoteNumberLinkIdElement.Select(elem => elem.Value) : null; }
                set
                {
                    if(value == null)
                      NoteNumberLinkIdElement = null; 
                    else
                      NoteNumberLinkIdElement = new List<Hl7.Fhir.Model.Integer>(value.Select(elem=>new Hl7.Fhir.Model.Integer(elem)));
                    OnPropertyChanged("NoteNumberLinkId");
                }
            }
            
            /// <summary>
            /// Added items adjudication
            /// </summary>
            [FhirElement("adjudication", InSummary=true, Order=60)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.AddedItemAdjudicationComponent> Adjudication
            {
                get { if(_Adjudication==null) _Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemAdjudicationComponent>(); return _Adjudication; }
                set { _Adjudication = value; OnPropertyChanged("Adjudication"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.AddedItemAdjudicationComponent> _Adjudication;
            
            /// <summary>
            /// Added items details
            /// </summary>
            [FhirElement("detail", InSummary=true, Order=70)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.AddedItemsDetailComponent> Detail
            {
                get { if(_Detail==null) _Detail = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemsDetailComponent>(); return _Detail; }
                set { _Detail = value; OnPropertyChanged("Detail"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.AddedItemsDetailComponent> _Detail;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as AddedItemComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(SequenceLinkIdElement != null) dest.SequenceLinkIdElement = new List<Hl7.Fhir.Model.Integer>(SequenceLinkIdElement.DeepCopy());
                    if(Service != null) dest.Service = (Hl7.Fhir.Model.Coding)Service.DeepCopy();
                    if(Fee != null) dest.Fee = (Hl7.Fhir.Model.Money)Fee.DeepCopy();
                    if(NoteNumberLinkIdElement != null) dest.NoteNumberLinkIdElement = new List<Hl7.Fhir.Model.Integer>(NoteNumberLinkIdElement.DeepCopy());
                    if(Adjudication != null) dest.Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemAdjudicationComponent>(Adjudication.DeepCopy());
                    if(Detail != null) dest.Detail = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemsDetailComponent>(Detail.DeepCopy());
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new AddedItemComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as AddedItemComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.Matches(Service, otherT.Service)) return false;
                if( !DeepComparable.Matches(Fee, otherT.Fee)) return false;
                if( !DeepComparable.Matches(NoteNumberLinkIdElement, otherT.NoteNumberLinkIdElement)) return false;
                if( !DeepComparable.Matches(Adjudication, otherT.Adjudication)) return false;
                if( !DeepComparable.Matches(Detail, otherT.Detail)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as AddedItemComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(Service, otherT.Service)) return false;
                if( !DeepComparable.IsExactly(Fee, otherT.Fee)) return false;
                if( !DeepComparable.IsExactly(NoteNumberLinkIdElement, otherT.NoteNumberLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(Adjudication, otherT.Adjudication)) return false;
                if( !DeepComparable.IsExactly(Detail, otherT.Detail)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("ItemAdjudicationComponent")]
        [DataContract]
        public partial class ItemAdjudicationComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "ItemAdjudicationComponent"; } }
            
            /// <summary>
            /// Adjudication category such as co-pay, eligible, benefit, etc.
            /// </summary>
            [FhirElement("code", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Code
            {
                get { return _Code; }
                set { _Code = value; OnPropertyChanged("Code"); }
            }
            private Hl7.Fhir.Model.Coding _Code;
            
            /// <summary>
            /// Monitary amount
            /// </summary>
            [FhirElement("amount", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Money Amount
            {
                get { return _Amount; }
                set { _Amount = value; OnPropertyChanged("Amount"); }
            }
            private Hl7.Fhir.Model.Money _Amount;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            [FhirElement("value", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.FhirDecimal ValueElement
            {
                get { return _ValueElement; }
                set { _ValueElement = value; OnPropertyChanged("ValueElement"); }
            }
            private Hl7.Fhir.Model.FhirDecimal _ValueElement;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public decimal? Value
            {
                get { return ValueElement != null ? ValueElement.Value : null; }
                set
                {
                    if(value == null)
                      ValueElement = null; 
                    else
                      ValueElement = new Hl7.Fhir.Model.FhirDecimal(value);
                    OnPropertyChanged("Value");
                }
            }
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as ItemAdjudicationComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(Code != null) dest.Code = (Hl7.Fhir.Model.Coding)Code.DeepCopy();
                    if(Amount != null) dest.Amount = (Hl7.Fhir.Model.Money)Amount.DeepCopy();
                    if(ValueElement != null) dest.ValueElement = (Hl7.Fhir.Model.FhirDecimal)ValueElement.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new ItemAdjudicationComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as ItemAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(Code, otherT.Code)) return false;
                if( !DeepComparable.Matches(Amount, otherT.Amount)) return false;
                if( !DeepComparable.Matches(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as ItemAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(Code, otherT.Code)) return false;
                if( !DeepComparable.IsExactly(Amount, otherT.Amount)) return false;
                if( !DeepComparable.IsExactly(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("AddedItemsDetailComponent")]
        [DataContract]
        public partial class AddedItemsDetailComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "AddedItemsDetailComponent"; } }
            
            /// <summary>
            /// Service or Product
            /// </summary>
            [FhirElement("service", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Service
            {
                get { return _Service; }
                set { _Service = value; OnPropertyChanged("Service"); }
            }
            private Hl7.Fhir.Model.Coding _Service;
            
            /// <summary>
            /// Professional fee or Product charge
            /// </summary>
            [FhirElement("fee", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Money Fee
            {
                get { return _Fee; }
                set { _Fee = value; OnPropertyChanged("Fee"); }
            }
            private Hl7.Fhir.Model.Money _Fee;
            
            /// <summary>
            /// Added items detail adjudication
            /// </summary>
            [FhirElement("adjudication", InSummary=true, Order=40)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.AddedItemDetailAdjudicationComponent> Adjudication
            {
                get { if(_Adjudication==null) _Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemDetailAdjudicationComponent>(); return _Adjudication; }
                set { _Adjudication = value; OnPropertyChanged("Adjudication"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.AddedItemDetailAdjudicationComponent> _Adjudication;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as AddedItemsDetailComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(Service != null) dest.Service = (Hl7.Fhir.Model.Coding)Service.DeepCopy();
                    if(Fee != null) dest.Fee = (Hl7.Fhir.Model.Money)Fee.DeepCopy();
                    if(Adjudication != null) dest.Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemDetailAdjudicationComponent>(Adjudication.DeepCopy());
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new AddedItemsDetailComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as AddedItemsDetailComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(Service, otherT.Service)) return false;
                if( !DeepComparable.Matches(Fee, otherT.Fee)) return false;
                if( !DeepComparable.Matches(Adjudication, otherT.Adjudication)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as AddedItemsDetailComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(Service, otherT.Service)) return false;
                if( !DeepComparable.IsExactly(Fee, otherT.Fee)) return false;
                if( !DeepComparable.IsExactly(Adjudication, otherT.Adjudication)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("SubdetailAdjudicationComponent")]
        [DataContract]
        public partial class SubdetailAdjudicationComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "SubdetailAdjudicationComponent"; } }
            
            /// <summary>
            /// Adjudication category such as co-pay, eligible, benefit, etc.
            /// </summary>
            [FhirElement("code", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Coding Code
            {
                get { return _Code; }
                set { _Code = value; OnPropertyChanged("Code"); }
            }
            private Hl7.Fhir.Model.Coding _Code;
            
            /// <summary>
            /// Monitary amount
            /// </summary>
            [FhirElement("amount", InSummary=true, Order=30)]
            [DataMember]
            public Hl7.Fhir.Model.Money Amount
            {
                get { return _Amount; }
                set { _Amount = value; OnPropertyChanged("Amount"); }
            }
            private Hl7.Fhir.Model.Money _Amount;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            [FhirElement("value", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.FhirDecimal ValueElement
            {
                get { return _ValueElement; }
                set { _ValueElement = value; OnPropertyChanged("ValueElement"); }
            }
            private Hl7.Fhir.Model.FhirDecimal _ValueElement;
            
            /// <summary>
            /// Non-monitory value
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public decimal? Value
            {
                get { return ValueElement != null ? ValueElement.Value : null; }
                set
                {
                    if(value == null)
                      ValueElement = null; 
                    else
                      ValueElement = new Hl7.Fhir.Model.FhirDecimal(value);
                    OnPropertyChanged("Value");
                }
            }
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as SubdetailAdjudicationComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(Code != null) dest.Code = (Hl7.Fhir.Model.Coding)Code.DeepCopy();
                    if(Amount != null) dest.Amount = (Hl7.Fhir.Model.Money)Amount.DeepCopy();
                    if(ValueElement != null) dest.ValueElement = (Hl7.Fhir.Model.FhirDecimal)ValueElement.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new SubdetailAdjudicationComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as SubdetailAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(Code, otherT.Code)) return false;
                if( !DeepComparable.Matches(Amount, otherT.Amount)) return false;
                if( !DeepComparable.Matches(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as SubdetailAdjudicationComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(Code, otherT.Code)) return false;
                if( !DeepComparable.IsExactly(Amount, otherT.Amount)) return false;
                if( !DeepComparable.IsExactly(ValueElement, otherT.ValueElement)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("ItemDetailComponent")]
        [DataContract]
        public partial class ItemDetailComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            public override string TypeName { get { return "ItemDetailComponent"; } }
            
            /// <summary>
            /// Service instance
            /// </summary>
            [FhirElement("sequenceLinkId", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Integer SequenceLinkIdElement
            {
                get { return _SequenceLinkIdElement; }
                set { _SequenceLinkIdElement = value; OnPropertyChanged("SequenceLinkIdElement"); }
            }
            private Hl7.Fhir.Model.Integer _SequenceLinkIdElement;
            
            /// <summary>
            /// Service instance
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public int? SequenceLinkId
            {
                get { return SequenceLinkIdElement != null ? SequenceLinkIdElement.Value : null; }
                set
                {
                    if(value == null)
                      SequenceLinkIdElement = null; 
                    else
                      SequenceLinkIdElement = new Hl7.Fhir.Model.Integer(value);
                    OnPropertyChanged("SequenceLinkId");
                }
            }
            
            /// <summary>
            /// Detail adjudication
            /// </summary>
            [FhirElement("adjudication", InSummary=true, Order=30)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.DetailAdjudicationComponent> Adjudication
            {
                get { if(_Adjudication==null) _Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.DetailAdjudicationComponent>(); return _Adjudication; }
                set { _Adjudication = value; OnPropertyChanged("Adjudication"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.DetailAdjudicationComponent> _Adjudication;
            
            /// <summary>
            /// Subdetail line items
            /// </summary>
            [FhirElement("subdetail", InSummary=true, Order=40)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.ClaimResponse.ItemSubdetailComponent> Subdetail
            {
                get { if(_Subdetail==null) _Subdetail = new List<Hl7.Fhir.Model.ClaimResponse.ItemSubdetailComponent>(); return _Subdetail; }
                set { _Subdetail = value; OnPropertyChanged("Subdetail"); }
            }
            private List<Hl7.Fhir.Model.ClaimResponse.ItemSubdetailComponent> _Subdetail;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as ItemDetailComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(SequenceLinkIdElement != null) dest.SequenceLinkIdElement = (Hl7.Fhir.Model.Integer)SequenceLinkIdElement.DeepCopy();
                    if(Adjudication != null) dest.Adjudication = new List<Hl7.Fhir.Model.ClaimResponse.DetailAdjudicationComponent>(Adjudication.DeepCopy());
                    if(Subdetail != null) dest.Subdetail = new List<Hl7.Fhir.Model.ClaimResponse.ItemSubdetailComponent>(Subdetail.DeepCopy());
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new ItemDetailComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as ItemDetailComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.Matches(Adjudication, otherT.Adjudication)) return false;
                if( !DeepComparable.Matches(Subdetail, otherT.Subdetail)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as ItemDetailComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(SequenceLinkIdElement, otherT.SequenceLinkIdElement)) return false;
                if( !DeepComparable.IsExactly(Adjudication, otherT.Adjudication)) return false;
                if( !DeepComparable.IsExactly(Subdetail, otherT.Subdetail)) return false;
                
                return true;
            }
            
        }
        
        
        /// <summary>
        /// Response  number
        /// </summary>
        [FhirElement("identifier", Order=50)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.Identifier> Identifier
        {
            get { if(_Identifier==null) _Identifier = new List<Hl7.Fhir.Model.Identifier>(); return _Identifier; }
            set { _Identifier = value; OnPropertyChanged("Identifier"); }
        }
        private List<Hl7.Fhir.Model.Identifier> _Identifier;
        
        /// <summary>
        /// Id of resource triggering adjudication
        /// </summary>
        [FhirElement("request", Order=60)]
        [References("OralHealthClaim")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Request
        {
            get { return _Request; }
            set { _Request = value; OnPropertyChanged("Request"); }
        }
        private Hl7.Fhir.Model.ResourceReference _Request;
        
        /// <summary>
        /// Resource version
        /// </summary>
        [FhirElement("ruleset", Order=70)]
        [DataMember]
        public Hl7.Fhir.Model.Coding Ruleset
        {
            get { return _Ruleset; }
            set { _Ruleset = value; OnPropertyChanged("Ruleset"); }
        }
        private Hl7.Fhir.Model.Coding _Ruleset;
        
        /// <summary>
        /// Original version
        /// </summary>
        [FhirElement("originalRuleset", Order=80)]
        [DataMember]
        public Hl7.Fhir.Model.Coding OriginalRuleset
        {
            get { return _OriginalRuleset; }
            set { _OriginalRuleset = value; OnPropertyChanged("OriginalRuleset"); }
        }
        private Hl7.Fhir.Model.Coding _OriginalRuleset;
        
        /// <summary>
        /// Creation date
        /// </summary>
        [FhirElement("date", Order=90)]
        [DataMember]
        public Hl7.Fhir.Model.Date DateElement
        {
            get { return _DateElement; }
            set { _DateElement = value; OnPropertyChanged("DateElement"); }
        }
        private Hl7.Fhir.Model.Date _DateElement;
        
        /// <summary>
        /// Creation date
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string Date
        {
            get { return DateElement != null ? DateElement.Value : null; }
            set
            {
                if(value == null)
                  DateElement = null; 
                else
                  DateElement = new Hl7.Fhir.Model.Date(value);
                OnPropertyChanged("Date");
            }
        }
        
        /// <summary>
        /// Insurer
        /// </summary>
        [FhirElement("organization", Order=100)]
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
        [FhirElement("requestProvider", Order=110)]
        [References("Practitioner")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference RequestProvider
        {
            get { return _RequestProvider; }
            set { _RequestProvider = value; OnPropertyChanged("RequestProvider"); }
        }
        private Hl7.Fhir.Model.ResourceReference _RequestProvider;
        
        /// <summary>
        /// Responsible organization
        /// </summary>
        [FhirElement("requestOrganization", Order=120)]
        [References("Organization")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference RequestOrganization
        {
            get { return _RequestOrganization; }
            set { _RequestOrganization = value; OnPropertyChanged("RequestOrganization"); }
        }
        private Hl7.Fhir.Model.ResourceReference _RequestOrganization;
        
        /// <summary>
        /// complete | error
        /// </summary>
        [FhirElement("outcome", Order=130)]
        [DataMember]
        public Code<Hl7.Fhir.Model.ClaimResponse.RemittanceOutcome> OutcomeElement
        {
            get { return _OutcomeElement; }
            set { _OutcomeElement = value; OnPropertyChanged("OutcomeElement"); }
        }
        private Code<Hl7.Fhir.Model.ClaimResponse.RemittanceOutcome> _OutcomeElement;
        
        /// <summary>
        /// complete | error
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public Hl7.Fhir.Model.ClaimResponse.RemittanceOutcome? Outcome
        {
            get { return OutcomeElement != null ? OutcomeElement.Value : null; }
            set
            {
                if(value == null)
                  OutcomeElement = null; 
                else
                  OutcomeElement = new Code<Hl7.Fhir.Model.ClaimResponse.RemittanceOutcome>(value);
                OnPropertyChanged("Outcome");
            }
        }
        
        /// <summary>
        /// Disposition Message
        /// </summary>
        [FhirElement("disposition", Order=140)]
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
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string Disposition
        {
            get { return DispositionElement != null ? DispositionElement.Value : null; }
            set
            {
                if(value == null)
                  DispositionElement = null; 
                else
                  DispositionElement = new Hl7.Fhir.Model.FhirString(value);
                OnPropertyChanged("Disposition");
            }
        }
        
        /// <summary>
        /// Party to be paid any benefits payable
        /// </summary>
        [FhirElement("payeeType", Order=150)]
        [DataMember]
        public Hl7.Fhir.Model.Coding PayeeType
        {
            get { return _PayeeType; }
            set { _PayeeType = value; OnPropertyChanged("PayeeType"); }
        }
        private Hl7.Fhir.Model.Coding _PayeeType;
        
        /// <summary>
        /// Line items
        /// </summary>
        [FhirElement("item", Order=160)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.ClaimResponse.ItemsComponent> Item
        {
            get { if(_Item==null) _Item = new List<Hl7.Fhir.Model.ClaimResponse.ItemsComponent>(); return _Item; }
            set { _Item = value; OnPropertyChanged("Item"); }
        }
        private List<Hl7.Fhir.Model.ClaimResponse.ItemsComponent> _Item;
        
        /// <summary>
        /// Insurer added line items
        /// </summary>
        [FhirElement("additem", Order=170)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.ClaimResponse.AddedItemComponent> Additem
        {
            get { if(_Additem==null) _Additem = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemComponent>(); return _Additem; }
            set { _Additem = value; OnPropertyChanged("Additem"); }
        }
        private List<Hl7.Fhir.Model.ClaimResponse.AddedItemComponent> _Additem;
        
        /// <summary>
        /// Processing errors
        /// </summary>
        [FhirElement("error", Order=180)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.ClaimResponse.ErrorsComponent> Error
        {
            get { if(_Error==null) _Error = new List<Hl7.Fhir.Model.ClaimResponse.ErrorsComponent>(); return _Error; }
            set { _Error = value; OnPropertyChanged("Error"); }
        }
        private List<Hl7.Fhir.Model.ClaimResponse.ErrorsComponent> _Error;
        
        /// <summary>
        /// Total Cost of service from the Claim
        /// </summary>
        [FhirElement("totalCost", Order=190)]
        [DataMember]
        public Hl7.Fhir.Model.Money TotalCost
        {
            get { return _TotalCost; }
            set { _TotalCost = value; OnPropertyChanged("TotalCost"); }
        }
        private Hl7.Fhir.Model.Money _TotalCost;
        
        /// <summary>
        /// Unallocated deductable
        /// </summary>
        [FhirElement("unallocDeductable", Order=200)]
        [DataMember]
        public Hl7.Fhir.Model.Money UnallocDeductable
        {
            get { return _UnallocDeductable; }
            set { _UnallocDeductable = value; OnPropertyChanged("UnallocDeductable"); }
        }
        private Hl7.Fhir.Model.Money _UnallocDeductable;
        
        /// <summary>
        /// Total benefit payable for the Claim
        /// </summary>
        [FhirElement("totalBenefit", Order=210)]
        [DataMember]
        public Hl7.Fhir.Model.Money TotalBenefit
        {
            get { return _TotalBenefit; }
            set { _TotalBenefit = value; OnPropertyChanged("TotalBenefit"); }
        }
        private Hl7.Fhir.Model.Money _TotalBenefit;
        
        /// <summary>
        /// Payment adjustment for non-Claim issues
        /// </summary>
        [FhirElement("paymentAdjustment", Order=220)]
        [DataMember]
        public Hl7.Fhir.Model.Money PaymentAdjustment
        {
            get { return _PaymentAdjustment; }
            set { _PaymentAdjustment = value; OnPropertyChanged("PaymentAdjustment"); }
        }
        private Hl7.Fhir.Model.Money _PaymentAdjustment;
        
        /// <summary>
        /// Reason for Payment adjustment
        /// </summary>
        [FhirElement("paymentAdjustmentReason", Order=230)]
        [DataMember]
        public Hl7.Fhir.Model.Coding PaymentAdjustmentReason
        {
            get { return _PaymentAdjustmentReason; }
            set { _PaymentAdjustmentReason = value; OnPropertyChanged("PaymentAdjustmentReason"); }
        }
        private Hl7.Fhir.Model.Coding _PaymentAdjustmentReason;
        
        /// <summary>
        /// Expected data of Payment
        /// </summary>
        [FhirElement("paymentDate", Order=240)]
        [DataMember]
        public Hl7.Fhir.Model.Date PaymentDateElement
        {
            get { return _PaymentDateElement; }
            set { _PaymentDateElement = value; OnPropertyChanged("PaymentDateElement"); }
        }
        private Hl7.Fhir.Model.Date _PaymentDateElement;
        
        /// <summary>
        /// Expected data of Payment
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public string PaymentDate
        {
            get { return PaymentDateElement != null ? PaymentDateElement.Value : null; }
            set
            {
                if(value == null)
                  PaymentDateElement = null; 
                else
                  PaymentDateElement = new Hl7.Fhir.Model.Date(value);
                OnPropertyChanged("PaymentDate");
            }
        }
        
        /// <summary>
        /// Payment amount
        /// </summary>
        [FhirElement("paymentAmount", Order=250)]
        [DataMember]
        public Hl7.Fhir.Model.Money PaymentAmount
        {
            get { return _PaymentAmount; }
            set { _PaymentAmount = value; OnPropertyChanged("PaymentAmount"); }
        }
        private Hl7.Fhir.Model.Money _PaymentAmount;
        
        /// <summary>
        /// Payment identifier
        /// </summary>
        [FhirElement("paymentRef", Order=260)]
        [DataMember]
        public Hl7.Fhir.Model.Identifier PaymentRef
        {
            get { return _PaymentRef; }
            set { _PaymentRef = value; OnPropertyChanged("PaymentRef"); }
        }
        private Hl7.Fhir.Model.Identifier _PaymentRef;
        
        /// <summary>
        /// Funds reserved status
        /// </summary>
        [FhirElement("reserved", Order=270)]
        [DataMember]
        public Hl7.Fhir.Model.Coding Reserved
        {
            get { return _Reserved; }
            set { _Reserved = value; OnPropertyChanged("Reserved"); }
        }
        private Hl7.Fhir.Model.Coding _Reserved;
        
        /// <summary>
        /// Printed Form Identifier
        /// </summary>
        [FhirElement("form", Order=280)]
        [DataMember]
        public Hl7.Fhir.Model.Coding Form
        {
            get { return _Form; }
            set { _Form = value; OnPropertyChanged("Form"); }
        }
        private Hl7.Fhir.Model.Coding _Form;
        
        /// <summary>
        /// Processing notes
        /// </summary>
        [FhirElement("note", Order=290)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.ClaimResponse.NotesComponent> Note
        {
            get { if(_Note==null) _Note = new List<Hl7.Fhir.Model.ClaimResponse.NotesComponent>(); return _Note; }
            set { _Note = value; OnPropertyChanged("Note"); }
        }
        private List<Hl7.Fhir.Model.ClaimResponse.NotesComponent> _Note;
        
        public override IDeepCopyable CopyTo(IDeepCopyable other)
        {
            var dest = other as ClaimResponse;
            
            if (dest != null)
            {
                base.CopyTo(dest);
                if(Identifier != null) dest.Identifier = new List<Hl7.Fhir.Model.Identifier>(Identifier.DeepCopy());
                if(Request != null) dest.Request = (Hl7.Fhir.Model.ResourceReference)Request.DeepCopy();
                if(Ruleset != null) dest.Ruleset = (Hl7.Fhir.Model.Coding)Ruleset.DeepCopy();
                if(OriginalRuleset != null) dest.OriginalRuleset = (Hl7.Fhir.Model.Coding)OriginalRuleset.DeepCopy();
                if(DateElement != null) dest.DateElement = (Hl7.Fhir.Model.Date)DateElement.DeepCopy();
                if(Organization != null) dest.Organization = (Hl7.Fhir.Model.ResourceReference)Organization.DeepCopy();
                if(RequestProvider != null) dest.RequestProvider = (Hl7.Fhir.Model.ResourceReference)RequestProvider.DeepCopy();
                if(RequestOrganization != null) dest.RequestOrganization = (Hl7.Fhir.Model.ResourceReference)RequestOrganization.DeepCopy();
                if(OutcomeElement != null) dest.OutcomeElement = (Code<Hl7.Fhir.Model.ClaimResponse.RemittanceOutcome>)OutcomeElement.DeepCopy();
                if(DispositionElement != null) dest.DispositionElement = (Hl7.Fhir.Model.FhirString)DispositionElement.DeepCopy();
                if(PayeeType != null) dest.PayeeType = (Hl7.Fhir.Model.Coding)PayeeType.DeepCopy();
                if(Item != null) dest.Item = new List<Hl7.Fhir.Model.ClaimResponse.ItemsComponent>(Item.DeepCopy());
                if(Additem != null) dest.Additem = new List<Hl7.Fhir.Model.ClaimResponse.AddedItemComponent>(Additem.DeepCopy());
                if(Error != null) dest.Error = new List<Hl7.Fhir.Model.ClaimResponse.ErrorsComponent>(Error.DeepCopy());
                if(TotalCost != null) dest.TotalCost = (Hl7.Fhir.Model.Money)TotalCost.DeepCopy();
                if(UnallocDeductable != null) dest.UnallocDeductable = (Hl7.Fhir.Model.Money)UnallocDeductable.DeepCopy();
                if(TotalBenefit != null) dest.TotalBenefit = (Hl7.Fhir.Model.Money)TotalBenefit.DeepCopy();
                if(PaymentAdjustment != null) dest.PaymentAdjustment = (Hl7.Fhir.Model.Money)PaymentAdjustment.DeepCopy();
                if(PaymentAdjustmentReason != null) dest.PaymentAdjustmentReason = (Hl7.Fhir.Model.Coding)PaymentAdjustmentReason.DeepCopy();
                if(PaymentDateElement != null) dest.PaymentDateElement = (Hl7.Fhir.Model.Date)PaymentDateElement.DeepCopy();
                if(PaymentAmount != null) dest.PaymentAmount = (Hl7.Fhir.Model.Money)PaymentAmount.DeepCopy();
                if(PaymentRef != null) dest.PaymentRef = (Hl7.Fhir.Model.Identifier)PaymentRef.DeepCopy();
                if(Reserved != null) dest.Reserved = (Hl7.Fhir.Model.Coding)Reserved.DeepCopy();
                if(Form != null) dest.Form = (Hl7.Fhir.Model.Coding)Form.DeepCopy();
                if(Note != null) dest.Note = new List<Hl7.Fhir.Model.ClaimResponse.NotesComponent>(Note.DeepCopy());
                return dest;
            }
            else
            	throw new ArgumentException("Can only copy to an object of the same type", "other");
        }
        
        public override IDeepCopyable DeepCopy()
        {
            return CopyTo(new ClaimResponse());
        }
        
        public override bool Matches(IDeepComparable other)
        {
            var otherT = other as ClaimResponse;
            if(otherT == null) return false;
            
            if(!base.Matches(otherT)) return false;
            if( !DeepComparable.Matches(Identifier, otherT.Identifier)) return false;
            if( !DeepComparable.Matches(Request, otherT.Request)) return false;
            if( !DeepComparable.Matches(Ruleset, otherT.Ruleset)) return false;
            if( !DeepComparable.Matches(OriginalRuleset, otherT.OriginalRuleset)) return false;
            if( !DeepComparable.Matches(DateElement, otherT.DateElement)) return false;
            if( !DeepComparable.Matches(Organization, otherT.Organization)) return false;
            if( !DeepComparable.Matches(RequestProvider, otherT.RequestProvider)) return false;
            if( !DeepComparable.Matches(RequestOrganization, otherT.RequestOrganization)) return false;
            if( !DeepComparable.Matches(OutcomeElement, otherT.OutcomeElement)) return false;
            if( !DeepComparable.Matches(DispositionElement, otherT.DispositionElement)) return false;
            if( !DeepComparable.Matches(PayeeType, otherT.PayeeType)) return false;
            if( !DeepComparable.Matches(Item, otherT.Item)) return false;
            if( !DeepComparable.Matches(Additem, otherT.Additem)) return false;
            if( !DeepComparable.Matches(Error, otherT.Error)) return false;
            if( !DeepComparable.Matches(TotalCost, otherT.TotalCost)) return false;
            if( !DeepComparable.Matches(UnallocDeductable, otherT.UnallocDeductable)) return false;
            if( !DeepComparable.Matches(TotalBenefit, otherT.TotalBenefit)) return false;
            if( !DeepComparable.Matches(PaymentAdjustment, otherT.PaymentAdjustment)) return false;
            if( !DeepComparable.Matches(PaymentAdjustmentReason, otherT.PaymentAdjustmentReason)) return false;
            if( !DeepComparable.Matches(PaymentDateElement, otherT.PaymentDateElement)) return false;
            if( !DeepComparable.Matches(PaymentAmount, otherT.PaymentAmount)) return false;
            if( !DeepComparable.Matches(PaymentRef, otherT.PaymentRef)) return false;
            if( !DeepComparable.Matches(Reserved, otherT.Reserved)) return false;
            if( !DeepComparable.Matches(Form, otherT.Form)) return false;
            if( !DeepComparable.Matches(Note, otherT.Note)) return false;
            
            return true;
        }
        
        public override bool IsExactly(IDeepComparable other)
        {
            var otherT = other as ClaimResponse;
            if(otherT == null) return false;
            
            if(!base.IsExactly(otherT)) return false;
            if( !DeepComparable.IsExactly(Identifier, otherT.Identifier)) return false;
            if( !DeepComparable.IsExactly(Request, otherT.Request)) return false;
            if( !DeepComparable.IsExactly(Ruleset, otherT.Ruleset)) return false;
            if( !DeepComparable.IsExactly(OriginalRuleset, otherT.OriginalRuleset)) return false;
            if( !DeepComparable.IsExactly(DateElement, otherT.DateElement)) return false;
            if( !DeepComparable.IsExactly(Organization, otherT.Organization)) return false;
            if( !DeepComparable.IsExactly(RequestProvider, otherT.RequestProvider)) return false;
            if( !DeepComparable.IsExactly(RequestOrganization, otherT.RequestOrganization)) return false;
            if( !DeepComparable.IsExactly(OutcomeElement, otherT.OutcomeElement)) return false;
            if( !DeepComparable.IsExactly(DispositionElement, otherT.DispositionElement)) return false;
            if( !DeepComparable.IsExactly(PayeeType, otherT.PayeeType)) return false;
            if( !DeepComparable.IsExactly(Item, otherT.Item)) return false;
            if( !DeepComparable.IsExactly(Additem, otherT.Additem)) return false;
            if( !DeepComparable.IsExactly(Error, otherT.Error)) return false;
            if( !DeepComparable.IsExactly(TotalCost, otherT.TotalCost)) return false;
            if( !DeepComparable.IsExactly(UnallocDeductable, otherT.UnallocDeductable)) return false;
            if( !DeepComparable.IsExactly(TotalBenefit, otherT.TotalBenefit)) return false;
            if( !DeepComparable.IsExactly(PaymentAdjustment, otherT.PaymentAdjustment)) return false;
            if( !DeepComparable.IsExactly(PaymentAdjustmentReason, otherT.PaymentAdjustmentReason)) return false;
            if( !DeepComparable.IsExactly(PaymentDateElement, otherT.PaymentDateElement)) return false;
            if( !DeepComparable.IsExactly(PaymentAmount, otherT.PaymentAmount)) return false;
            if( !DeepComparable.IsExactly(PaymentRef, otherT.PaymentRef)) return false;
            if( !DeepComparable.IsExactly(Reserved, otherT.Reserved)) return false;
            if( !DeepComparable.IsExactly(Form, otherT.Form)) return false;
            if( !DeepComparable.IsExactly(Note, otherT.Note)) return false;
            
            return true;
        }
        
    }
    
}
