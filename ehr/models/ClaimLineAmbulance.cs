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
    
    public partial class ClaimLineAmbulance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClaimLineAmbulance()
        {
            this.Weight = 0m;
            this.PatientCount = 0;
        }
    
        public int Id { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public string Reason { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public string RoundTrip { get; set; }
        public string Stretcher { get; set; }
        public string CertCode_1 { get; set; }
        public string CertCode_2 { get; set; }
        public string CertCode_3 { get; set; }
        public string CertCode_4 { get; set; }
        public string CertCode_5 { get; set; }
        public string CertResponse { get; set; }
        public Nullable<int> PatientCount { get; set; }
        public string SystemNoteKey { get; set; }
    
        public virtual ClaimLine ClaimLine { get; set; }
    }
}
