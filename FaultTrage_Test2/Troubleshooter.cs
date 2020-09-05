//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FaultTrage_Test2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Troubleshooter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Troubleshooter()
        {
            this.ImpactInfoes = new HashSet<ImpactInfo>();
        }
    
        public int TroubleshooterId { get; set; }
        public string TroubleshooterName { get; set; }
        public int TroubleshooterDesignation { get; set; }
        public int TroubleshooterTeam { get; set; }
        public string TroubleshooterPhoneNo { get; set; }
        public int TroubleshooterExpertise { get; set; }
        public int YearOfExperience { get; set; }
        public int ManagerofTroubleshooter { get; set; }
        public int NumberofSolves { get; set; }
    
        public virtual Designation Designation { get; set; }
        public virtual FaultType FaultType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImpactInfo> ImpactInfoes { get; set; }
        public virtual Team Team { get; set; }
        public virtual TroubleshooterManager TroubleshooterManager { get; set; }
    }
}