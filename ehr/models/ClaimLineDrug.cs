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
    
    public partial class ClaimLineDrug
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClaimLineDrug()
        {
            this.Quantity = 0;
        }
    
        public int Id { get; set; }
        public string Qualifier { get; set; }
        public string Code { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string Unit { get; set; }
        public string PrescriptionCode { get; set; }
        public string PrescriptionNumber { get; set; }
        public string SystemNoteKey { get; set; }
    
        public virtual ClaimLine ClaimLine { get; set; }
    }
}