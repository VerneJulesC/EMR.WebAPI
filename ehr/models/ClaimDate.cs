//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMR.WebAPI.ehr.models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClaimDate
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> OnsetOfCurrent { get; set; }
        public Nullable<System.DateTime> InitialTreatment { get; set; }
        public Nullable<System.DateTime> LastSeen { get; set; }
        public Nullable<System.DateTime> Acute { get; set; }
        public Nullable<System.DateTime> LastMenstrual { get; set; }
        public Nullable<System.DateTime> LastXRay { get; set; }
        public Nullable<System.DateTime> HearingVision { get; set; }
        public Nullable<System.DateTime> LastWorked { get; set; }
        public Nullable<System.DateTime> ReturnToWork { get; set; }
        public Nullable<System.DateTime> Admission { get; set; }
        public Nullable<System.DateTime> Discharge { get; set; }
        public Nullable<System.DateTime> Assumed { get; set; }
        public Nullable<System.DateTime> Property { get; set; }
        public Nullable<System.DateTime> Repricer { get; set; }
        public string SystemNoteKey { get; set; }
        public Nullable<System.DateTime> Other { get; set; }
        public Nullable<System.DateTime> DisabilityStart { get; set; }
        public Nullable<System.DateTime> DisabilityEnd { get; set; }
    }
}
