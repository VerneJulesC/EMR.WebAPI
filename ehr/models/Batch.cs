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
    
    public partial class Batch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Batch()
        {
            this.Identifier = "";
            this.Status = "U";
        }
    
        public int Id { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string Identifier { get; set; }
        public string ClaimIDs { get; set; }
        public int CreatedById { get; set; }
        public string Status { get; set; }
        public string SystemNoteKey { get; set; }
    }
}