//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SS
{
    using System;
    using System.Collections.Generic;
    
    public partial class Disbursement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disbursement()
        {
            this.DisbursementItems = new HashSet<DisbursementItem>();
        }
    
        public int disbursementid { get; set; }
        public string deptcode { get; set; }
        public int representativecode { get; set; }
        public Nullable<System.DateTime> collectiondate { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementItem> DisbursementItems { get; set; }
    }
}