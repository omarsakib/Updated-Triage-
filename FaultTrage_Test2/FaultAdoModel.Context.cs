﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FaultManagementEntities : DbContext
    {
        public FaultManagementEntities()
            : base("name=FaultManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Fault> Faults { get; set; }
        public virtual DbSet<FaultType> FaultTypes { get; set; }
        public virtual DbSet<ImpactInfo> ImpactInfoes { get; set; }
        public virtual DbSet<SLA> SLAs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TicketStatu> TicketStatus { get; set; }
        public virtual DbSet<Troubleshooter> Troubleshooters { get; set; }
        public virtual DbSet<TroubleshooterManager> TroubleshooterManagers { get; set; }
    }
}
