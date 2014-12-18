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
// Generated on Mon, Dec 15, 2014 13:18+0100 for FHIR v0.4.0
//
namespace Hl7.Fhir.Model
{
    /// <summary>
    /// An association of a Patient with an Organization and  Healthcare Provider(s) for a period of time that the Organization assumes some level of responsibility
    /// </summary>
    [FhirType("EpisodeOfCare", IsResource=true)]
    [DataContract]
    public partial class EpisodeOfCare : Hl7.Fhir.Model.DomainResource, System.ComponentModel.INotifyPropertyChanged
    {
        [NotMapped]
        public override ResourceType ResourceType { get { return ResourceType.EpisodeOfCare; } }
        [NotMapped]
        public override string TypeName { get { return "EpisodeOfCare"; } }
        
        /// <summary>
        /// The status of the encounter
        /// </summary>
        [FhirEnumeration("EpisodeOfCareStatus")]
        public enum EpisodeOfCareStatus
        {
            /// <summary>
            /// This episode of care is planned to start at the date specified in the period.start. During this status an organization may perform assessments to determine if they are eligible to receive services, or be organizing to make resources available to provide care services.
            /// </summary>
            [EnumLiteral("planned")]
            Planned,
            /// <summary>
            /// This episode of care is current.
            /// </summary>
            [EnumLiteral("active")]
            Active,
            /// <summary>
            /// This episode of care is on hold, the organization has limitted responsibility for the patient (such as while on respite).
            /// </summary>
            [EnumLiteral("onhold")]
            Onhold,
            /// <summary>
            /// This episode of care is finished at the organization is not expecting to be providing care to the patient.
            /// </summary>
            [EnumLiteral("finished")]
            Finished,
            /// <summary>
            /// The episode of care was withdrawn from service, often selected during the planned stage as the patient may have gone elsewhere, or the circumstances have changed and the organization is unable to provide the care.
            /// </summary>
            [EnumLiteral("withdrawn")]
            Withdrawn,
            /// <summary>
            /// The status is outside one of these values, an extension should be used to define what the status reason is.
            /// </summary>
            [EnumLiteral("other")]
            Other,
        }
        
        [FhirType("EpisodeOfCareStatusHistoryComponent")]
        [DataContract]
        public partial class EpisodeOfCareStatusHistoryComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            [NotMapped]
            public override string TypeName { get { return "EpisodeOfCareStatusHistoryComponent"; } }
            
            /// <summary>
            /// planned | active | onhold | finished | withdrawn | other
            /// </summary>
            [FhirElement("status", InSummary=true, Order=20)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus> StatusElement
            {
                get { return _StatusElement; }
                set { _StatusElement = value; OnPropertyChanged("StatusElement"); }
            }
            private Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus> _StatusElement;
            
            /// <summary>
            /// planned | active | onhold | finished | withdrawn | other
            /// </summary>
            /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
            [NotMapped]
            [IgnoreDataMemberAttribute]
            public Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus? Status
            {
                get { return StatusElement != null ? StatusElement.Value : null; }
                set
                {
                    if(value == null)
                      StatusElement = null; 
                    else
                      StatusElement = new Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>(value);
                    OnPropertyChanged("Status");
                }
            }
            
            /// <summary>
            /// The period during this episodeofcare that the specific status applied
            /// </summary>
            [FhirElement("period", InSummary=true, Order=30)]
            [Cardinality(Min=1,Max=1)]
            [DataMember]
            public Hl7.Fhir.Model.Period Period
            {
                get { return _Period; }
                set { _Period = value; OnPropertyChanged("Period"); }
            }
            private Hl7.Fhir.Model.Period _Period;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as EpisodeOfCareStatusHistoryComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(StatusElement != null) dest.StatusElement = (Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>)StatusElement.DeepCopy();
                    if(Period != null) dest.Period = (Hl7.Fhir.Model.Period)Period.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new EpisodeOfCareStatusHistoryComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as EpisodeOfCareStatusHistoryComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(StatusElement, otherT.StatusElement)) return false;
                if( !DeepComparable.Matches(Period, otherT.Period)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as EpisodeOfCareStatusHistoryComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(StatusElement, otherT.StatusElement)) return false;
                if( !DeepComparable.IsExactly(Period, otherT.Period)) return false;
                
                return true;
            }
            
        }
        
        
        [FhirType("EpisodeOfCareCareTeamComponent")]
        [DataContract]
        public partial class EpisodeOfCareCareTeamComponent : Hl7.Fhir.Model.BackboneElement, System.ComponentModel.INotifyPropertyChanged
        {
            [NotMapped]
            public override string TypeName { get { return "EpisodeOfCareCareTeamComponent"; } }
            
            /// <summary>
            /// The practitioner within the team
            /// </summary>
            [FhirElement("member", InSummary=true, Order=20)]
            [References("Practitioner")]
            [DataMember]
            public Hl7.Fhir.Model.ResourceReference Member
            {
                get { return _Member; }
                set { _Member = value; OnPropertyChanged("Member"); }
            }
            private Hl7.Fhir.Model.ResourceReference _Member;
            
            /// <summary>
            /// The role that this team member is taking within this episode of care
            /// </summary>
            [FhirElement("role", InSummary=true, Order=30)]
            [Cardinality(Min=0,Max=-1)]
            [DataMember]
            public List<Hl7.Fhir.Model.CodeableConcept> Role
            {
                get { if(_Role==null) _Role = new List<Hl7.Fhir.Model.CodeableConcept>(); return _Role; }
                set { _Role = value; OnPropertyChanged("Role"); }
            }
            private List<Hl7.Fhir.Model.CodeableConcept> _Role;
            
            /// <summary>
            /// The period of time that this practitioner is performing some role within the episode of care
            /// </summary>
            [FhirElement("period", InSummary=true, Order=40)]
            [DataMember]
            public Hl7.Fhir.Model.Period Period
            {
                get { return _Period; }
                set { _Period = value; OnPropertyChanged("Period"); }
            }
            private Hl7.Fhir.Model.Period _Period;
            
            public override IDeepCopyable CopyTo(IDeepCopyable other)
            {
                var dest = other as EpisodeOfCareCareTeamComponent;
                
                if (dest != null)
                {
                    base.CopyTo(dest);
                    if(Member != null) dest.Member = (Hl7.Fhir.Model.ResourceReference)Member.DeepCopy();
                    if(Role != null) dest.Role = new List<Hl7.Fhir.Model.CodeableConcept>(Role.DeepCopy());
                    if(Period != null) dest.Period = (Hl7.Fhir.Model.Period)Period.DeepCopy();
                    return dest;
                }
                else
                	throw new ArgumentException("Can only copy to an object of the same type", "other");
            }
            
            public override IDeepCopyable DeepCopy()
            {
                return CopyTo(new EpisodeOfCareCareTeamComponent());
            }
            
            public override bool Matches(IDeepComparable other)
            {
                var otherT = other as EpisodeOfCareCareTeamComponent;
                if(otherT == null) return false;
                
                if(!base.Matches(otherT)) return false;
                if( !DeepComparable.Matches(Member, otherT.Member)) return false;
                if( !DeepComparable.Matches(Role, otherT.Role)) return false;
                if( !DeepComparable.Matches(Period, otherT.Period)) return false;
                
                return true;
            }
            
            public override bool IsExactly(IDeepComparable other)
            {
                var otherT = other as EpisodeOfCareCareTeamComponent;
                if(otherT == null) return false;
                
                if(!base.IsExactly(otherT)) return false;
                if( !DeepComparable.IsExactly(Member, otherT.Member)) return false;
                if( !DeepComparable.IsExactly(Role, otherT.Role)) return false;
                if( !DeepComparable.IsExactly(Period, otherT.Period)) return false;
                
                return true;
            }
            
        }
        
        
        /// <summary>
        /// Identifier(s) by which this EpisodeOfCare is known
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
        /// planned | active | onhold | finished | withdrawn | other
        /// </summary>
        [FhirElement("currentStatus", InSummary=true, Order=60)]
        [Cardinality(Min=1,Max=1)]
        [DataMember]
        public Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus> CurrentStatusElement
        {
            get { return _CurrentStatusElement; }
            set { _CurrentStatusElement = value; OnPropertyChanged("CurrentStatusElement"); }
        }
        private Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus> _CurrentStatusElement;
        
        /// <summary>
        /// planned | active | onhold | finished | withdrawn | other
        /// </summary>
        /// <remarks>This uses the native .NET datatype, rather than the FHIR equivalent</remarks>
        [NotMapped]
        [IgnoreDataMemberAttribute]
        public Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus? CurrentStatus
        {
            get { return CurrentStatusElement != null ? CurrentStatusElement.Value : null; }
            set
            {
                if(value == null)
                  CurrentStatusElement = null; 
                else
                  CurrentStatusElement = new Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>(value);
                OnPropertyChanged("CurrentStatus");
            }
        }
        
        /// <summary>
        /// The status history for the EpisodeOfCare
        /// </summary>
        [FhirElement("statusHistory", Order=70)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatusHistoryComponent> StatusHistory
        {
            get { if(_StatusHistory==null) _StatusHistory = new List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatusHistoryComponent>(); return _StatusHistory; }
            set { _StatusHistory = value; OnPropertyChanged("StatusHistory"); }
        }
        private List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatusHistoryComponent> _StatusHistory;
        
        /// <summary>
        /// Specific type of EpisodeOfcare
        /// </summary>
        [FhirElement("type", InSummary=true, Order=80)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.CodeableConcept> Type
        {
            get { if(_Type==null) _Type = new List<Hl7.Fhir.Model.CodeableConcept>(); return _Type; }
            set { _Type = value; OnPropertyChanged("Type"); }
        }
        private List<Hl7.Fhir.Model.CodeableConcept> _Type;
        
        /// <summary>
        /// The patient that this episodeofcare applies to
        /// </summary>
        [FhirElement("patient", InSummary=true, Order=90)]
        [References("Patient")]
        [Cardinality(Min=1,Max=1)]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference Patient
        {
            get { return _Patient; }
            set { _Patient = value; OnPropertyChanged("Patient"); }
        }
        private Hl7.Fhir.Model.ResourceReference _Patient;
        
        /// <summary>
        /// The organization that has assumed the specific responsibilities for the specified duration
        /// </summary>
        [FhirElement("managingOrganization", InSummary=true, Order=100)]
        [References("Organization")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference ManagingOrganization
        {
            get { return _ManagingOrganization; }
            set { _ManagingOrganization = value; OnPropertyChanged("ManagingOrganization"); }
        }
        private Hl7.Fhir.Model.ResourceReference _ManagingOrganization;
        
        /// <summary>
        /// The interval during which the managing organization assumes the defined responsibility
        /// </summary>
        [FhirElement("period", InSummary=true, Order=110)]
        [DataMember]
        public Hl7.Fhir.Model.Period Period
        {
            get { return _Period; }
            set { _Period = value; OnPropertyChanged("Period"); }
        }
        private Hl7.Fhir.Model.Period _Period;
        
        /// <summary>
        /// A list of conditions/problems/diagnoses that this episode of care is intended to be providing care for
        /// </summary>
        [FhirElement("condition", Order=120)]
        [References("Condition")]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.ResourceReference> Condition
        {
            get { if(_Condition==null) _Condition = new List<Hl7.Fhir.Model.ResourceReference>(); return _Condition; }
            set { _Condition = value; OnPropertyChanged("Condition"); }
        }
        private List<Hl7.Fhir.Model.ResourceReference> _Condition;
        
        /// <summary>
        /// A Referral Request that this EpisodeOfCare manages activities within
        /// </summary>
        [FhirElement("referralRequest", Order=130)]
        [References("ReferralRequest")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference ReferralRequest
        {
            get { return _ReferralRequest; }
            set { _ReferralRequest = value; OnPropertyChanged("ReferralRequest"); }
        }
        private Hl7.Fhir.Model.ResourceReference _ReferralRequest;
        
        /// <summary>
        /// The practitioner that is the care manager/care co-ordinator for this patient
        /// </summary>
        [FhirElement("careManager", Order=140)]
        [References("Practitioner")]
        [DataMember]
        public Hl7.Fhir.Model.ResourceReference CareManager
        {
            get { return _CareManager; }
            set { _CareManager = value; OnPropertyChanged("CareManager"); }
        }
        private Hl7.Fhir.Model.ResourceReference _CareManager;
        
        /// <summary>
        /// The list of practitioners that may be facilitating this episode of care for specific purposes
        /// </summary>
        [FhirElement("careTeam", Order=150)]
        [Cardinality(Min=0,Max=-1)]
        [DataMember]
        public List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareCareTeamComponent> CareTeam
        {
            get { if(_CareTeam==null) _CareTeam = new List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareCareTeamComponent>(); return _CareTeam; }
            set { _CareTeam = value; OnPropertyChanged("CareTeam"); }
        }
        private List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareCareTeamComponent> _CareTeam;
        
        public override IDeepCopyable CopyTo(IDeepCopyable other)
        {
            var dest = other as EpisodeOfCare;
            
            if (dest != null)
            {
                base.CopyTo(dest);
                if(Identifier != null) dest.Identifier = new List<Hl7.Fhir.Model.Identifier>(Identifier.DeepCopy());
                if(CurrentStatusElement != null) dest.CurrentStatusElement = (Code<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatus>)CurrentStatusElement.DeepCopy();
                if(StatusHistory != null) dest.StatusHistory = new List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareStatusHistoryComponent>(StatusHistory.DeepCopy());
                if(Type != null) dest.Type = new List<Hl7.Fhir.Model.CodeableConcept>(Type.DeepCopy());
                if(Patient != null) dest.Patient = (Hl7.Fhir.Model.ResourceReference)Patient.DeepCopy();
                if(ManagingOrganization != null) dest.ManagingOrganization = (Hl7.Fhir.Model.ResourceReference)ManagingOrganization.DeepCopy();
                if(Period != null) dest.Period = (Hl7.Fhir.Model.Period)Period.DeepCopy();
                if(Condition != null) dest.Condition = new List<Hl7.Fhir.Model.ResourceReference>(Condition.DeepCopy());
                if(ReferralRequest != null) dest.ReferralRequest = (Hl7.Fhir.Model.ResourceReference)ReferralRequest.DeepCopy();
                if(CareManager != null) dest.CareManager = (Hl7.Fhir.Model.ResourceReference)CareManager.DeepCopy();
                if(CareTeam != null) dest.CareTeam = new List<Hl7.Fhir.Model.EpisodeOfCare.EpisodeOfCareCareTeamComponent>(CareTeam.DeepCopy());
                return dest;
            }
            else
            	throw new ArgumentException("Can only copy to an object of the same type", "other");
        }
        
        public override IDeepCopyable DeepCopy()
        {
            return CopyTo(new EpisodeOfCare());
        }
        
        public override bool Matches(IDeepComparable other)
        {
            var otherT = other as EpisodeOfCare;
            if(otherT == null) return false;
            
            if(!base.Matches(otherT)) return false;
            if( !DeepComparable.Matches(Identifier, otherT.Identifier)) return false;
            if( !DeepComparable.Matches(CurrentStatusElement, otherT.CurrentStatusElement)) return false;
            if( !DeepComparable.Matches(StatusHistory, otherT.StatusHistory)) return false;
            if( !DeepComparable.Matches(Type, otherT.Type)) return false;
            if( !DeepComparable.Matches(Patient, otherT.Patient)) return false;
            if( !DeepComparable.Matches(ManagingOrganization, otherT.ManagingOrganization)) return false;
            if( !DeepComparable.Matches(Period, otherT.Period)) return false;
            if( !DeepComparable.Matches(Condition, otherT.Condition)) return false;
            if( !DeepComparable.Matches(ReferralRequest, otherT.ReferralRequest)) return false;
            if( !DeepComparable.Matches(CareManager, otherT.CareManager)) return false;
            if( !DeepComparable.Matches(CareTeam, otherT.CareTeam)) return false;
            
            return true;
        }
        
        public override bool IsExactly(IDeepComparable other)
        {
            var otherT = other as EpisodeOfCare;
            if(otherT == null) return false;
            
            if(!base.IsExactly(otherT)) return false;
            if( !DeepComparable.IsExactly(Identifier, otherT.Identifier)) return false;
            if( !DeepComparable.IsExactly(CurrentStatusElement, otherT.CurrentStatusElement)) return false;
            if( !DeepComparable.IsExactly(StatusHistory, otherT.StatusHistory)) return false;
            if( !DeepComparable.IsExactly(Type, otherT.Type)) return false;
            if( !DeepComparable.IsExactly(Patient, otherT.Patient)) return false;
            if( !DeepComparable.IsExactly(ManagingOrganization, otherT.ManagingOrganization)) return false;
            if( !DeepComparable.IsExactly(Period, otherT.Period)) return false;
            if( !DeepComparable.IsExactly(Condition, otherT.Condition)) return false;
            if( !DeepComparable.IsExactly(ReferralRequest, otherT.ReferralRequest)) return false;
            if( !DeepComparable.IsExactly(CareManager, otherT.CareManager)) return false;
            if( !DeepComparable.IsExactly(CareTeam, otherT.CareTeam)) return false;
            
            return true;
        }
        
    }
    
}