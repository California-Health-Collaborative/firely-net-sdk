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
    /// Typed element containing the primitive xhtml
    /// </summary>
    [FhirType("xhtml")]
    [DataContract]
    public partial class XHtml : Hl7.Fhir.Model.Element, System.ComponentModel.INotifyPropertyChanged
    {
        public override string TypeName { get { return "xhtml"; } }
        
        public XHtml(string value)
        {
            Value = value; 
        }
        
        public XHtml(): this((string)null) {}
        
        /// <summary>
        /// Primitive value of the element
        /// </summary>
        [FhirElement("value", IsPrimitiveValue=true, XmlSerialization=XmlSerializationHint.Attribute, InSummary=true, Order=30)]
        [NarrativeXhtmlPattern]
        [DataMember]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; OnPropertyChanged("Value"); }
        }
        private string _Value;
        
        public override IDeepCopyable CopyTo(IDeepCopyable other)
        {
            var dest = other as XHtml;
            
            if (dest != null)
            {
                base.CopyTo(dest);
                if(Value != null) dest.Value = Value;
                return dest;
            }
            else
            	throw new ArgumentException("Can only copy to an object of the same type", "other");
        }
        
        public override IDeepCopyable DeepCopy()
        {
            return CopyTo(new XHtml());
        }
        
        public override bool Matches(IDeepComparable other)
        {
            var otherT = other as XHtml;
            if(otherT == null) return false;
            
            if(!base.Matches(otherT)) return false;
            if( Value != otherT.Value ) return false;
            
            return true;
        }
        
        public override bool IsExactly(IDeepComparable other)
        {
            var otherT = other as XHtml;
            if(otherT == null) return false;
            
            if(!base.IsExactly(otherT)) return false;
            if( Value != otherT.Value ) return false;
            
            return true;
        }
        
    }
    
}
