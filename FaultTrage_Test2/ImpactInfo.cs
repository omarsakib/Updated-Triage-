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
    
    public partial class ImpactInfo
    {
        public int Impactid { get; set; }
        public int TicketId { get; set; }
        public int TeamId { get; set; }
        public int FaultId { get; set; }
        public int TroubleshooterId { get; set; }
        public System.DateTime TicketRaisedDate { get; set; }
        public System.DateTime TicketClosingDate { get; set; }
    
        public virtual Fault Fault { get; set; }
        public virtual Team Team { get; set; }
        public virtual TicketStatu TicketStatu { get; set; }
        public virtual Troubleshooter Troubleshooter { get; set; }
    }
}
