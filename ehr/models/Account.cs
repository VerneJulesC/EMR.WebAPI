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
    
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            this.IsInactive = false;
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsInactive { get; set; }
        public string SystemNoteKey { get; set; }
    
        public virtual AccountPreference AccountPreference { get; set; }
    }
}