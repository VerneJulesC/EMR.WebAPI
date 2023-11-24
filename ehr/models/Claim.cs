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
    
    public partial class Claim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Claim()
        {
            this.AcceptAssignment = "C";
            this.FilingStatus = "U";
            this.Relationship = "18";
            this.EmploymentRelated = false;
            this.OutsideLabCharges = 0m;
            this.AssignBenefits = "N";
            this.AllowRelease = "I";
            this.HasSignature = false;
            this.HomeBound = false;
            this.ClaimPayerType = "Other";
            this.ClaimLines = new HashSet<ClaimLine>();
        }
    
        public int Id { get; set; }
        public string AcceptAssignment { get; set; }
        public Nullable<decimal> AmountBalance { get; set; }
        public Nullable<decimal> AmountCopay { get; set; }
        public Nullable<decimal> AmountTotal { get; set; }
        public string FilingStatus { get; set; }
        public string PrimaryPayerMemberID { get; set; }
        public string SecondaryPayerMemberID { get; set; }
        public string DiagnosisCodes { get; set; }
        public string Relationship { get; set; }
        public Nullable<int> PlaceOfServiceId { get; set; }
        public Nullable<int> PrimarySubscriberId { get; set; }
        public Nullable<int> SecondarySubscriberId { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> FacilityId { get; set; }
        public Nullable<int> PrimaryPayerId { get; set; }
        public Nullable<int> SecondaryPayerId { get; set; }
        public Nullable<bool> EmploymentRelated { get; set; }
        public Nullable<bool> OutsideLab { get; set; }
        public Nullable<decimal> OutsideLabCharges { get; set; }
        public string Identifier { get; set; }
        public Nullable<System.DateTime> DateOfService { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> ProviderId { get; set; }
        public Nullable<int> RenderingProviderId { get; set; }
        public Nullable<int> BillingProviderId { get; set; }
        public string AssignBenefits { get; set; }
        public string AllowRelease { get; set; }
        public Nullable<bool> HasSignature { get; set; }
        public string SpecialProgram { get; set; }
        public string DelayReason { get; set; }
        public string NoteType { get; set; }
        public string Notes { get; set; }
        public Nullable<bool> HomeBound { get; set; }
        public string SystemNoteKey { get; set; }
        public string ClaimPayerType { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<int> ReferringProviderId { get; set; }
        public string AutoAccident { get; set; }
        public string OtherAccident { get; set; }
    
        public virtual PlaceOfService PlaceOfService { get; set; }
        public virtual Subscriber PrimarySubscriber { get; set; }
        public virtual Subscriber SecondarySubscriber { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Facility Facility { get; set; }
        public virtual Payer PrimaryPayer { get; set; }
        public virtual Payer SecondaryPayer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClaimLine> ClaimLines { get; set; }
        public virtual ClaimDate Dates { get; set; }
        public virtual Provider RenderingProvider { get; set; }
        public virtual Provider BillingProvider { get; set; }
        public virtual ClaimAccident Accident { get; set; }
        public virtual ClaimSupplemental Supplemental { get; set; }
        public virtual ClaimContract Contract { get; set; }
        public virtual ClaimReference Reference { get; set; }
        public virtual ClaimAmbulance Ambulance { get; set; }
        public virtual ClaimSpinal Spinal { get; set; }
        public virtual ClaimCondition Condition { get; set; }
        public virtual ClaimRepricing Repricing { get; set; }
        public virtual ClaimAmount Amounts { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Provider ReferringProvider { get; set; }
    }
}
