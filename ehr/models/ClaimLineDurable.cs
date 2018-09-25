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
    
    public partial class ClaimLineDurable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClaimLineDurable()
        {
            this.CertQuantity = 0m;
        }
    
        public int Id { get; set; }
        public string Transmission { get; set; }
        public string Procedure { get; set; }
        public string Quantity { get; set; }
        public Nullable<decimal> Rental { get; set; }
        public Nullable<decimal> Purchase { get; set; }
        public string Frequency { get; set; }
        public string CertCode { get; set; }
        public Nullable<decimal> CertQuantity { get; set; }
        public string SystemNoteKey { get; set; }
    
        public virtual ClaimLine ClaimLine { get; set; }
    }
}