using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FaultTrage_Test2;

namespace FaultTrage_Test2.Controllers
{
    public class AssignFaultsController : Controller
    {
        private FaultManagementEntities db = new FaultManagementEntities();

        // GET: Faults
        public ActionResult Index(int? id)
        {
            if(id == null || id == 0)
            {
                var faults = db.Faults.Include(f => f.SLA1);//.ThenInclude(s=> s.FaultType1);//.Include(f => f.FaultType1).Include(f => f.TicketStatu1);
                return View(faults.ToList());
            }
            else
            {
                Fault fault = db.Faults.Find(id);
                List<Fault> faults = new List<Fault>();
                faults.Add(fault);
                return View(faults);
            }
        }

        // GET: AssignFaults/Assign/5
        public ActionResult Assign(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //ViewBag.Troubleshooter = new SelectList(db.Troubleshooters, "TroubleshooterId", "TroubleshooterName");
            //ViewBag.Troubleshooter = new SelectList(db.Troubleshooters, "TroubleshooterId", "TroubleshooterName");
            ViewBag.TroubleshooterId = new SelectList(db.Troubleshooters, "TroubleshooterId", "TroubleshooterName");

            Fault fault = db.Faults.Find(id);
            ImpactInfo impactInfo = new ImpactInfo();
            impactInfo.FaultId = fault.FaultId;
            impactInfo.TicketRaisedDate = DateTime.Now;
            impactInfo.TicketClosingDate = DateTime.Now;
            if (fault == null)
            {
                return HttpNotFound();
            }
            return View(impactInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Assign([Bind(Include = "Impactid, TicketId,FaultId,TroubleshooterId,TicketRaisedDate,TicketClosingDate")] ImpactInfo impactInfo)
        {
            if (ModelState.IsValid)
            {
                Troubleshooter troubleshooter = db.Troubleshooters.Find(impactInfo.TroubleshooterId);
                impactInfo.TeamId = troubleshooter.TroubleshooterTeam;
                db.ImpactInfoes.Add(impactInfo);
                db.SaveChanges();
                return RedirectToAction("Index", "ImpactInfoes");
            }
            return View(impactInfo);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
