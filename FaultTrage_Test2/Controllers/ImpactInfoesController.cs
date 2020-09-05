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
    public class ImpactInfoesController : Controller
    {
        private FaultManagementEntities db = new FaultManagementEntities();

        // GET: ImpactInfoes
        public ActionResult Index()
        {
            var impactInfoes = db.ImpactInfoes.Include(i => i.Fault).Include(i => i.Team).Include(i => i.TicketStatu).Include(i => i.Troubleshooter);
            return View(impactInfoes.ToList());
        }

        // GET: ImpactInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImpactInfo impactInfo = db.ImpactInfoes.Find(id);
            if (impactInfo == null)
            {
                return HttpNotFound();
            }
            return View(impactInfo);
        }

        // GET: ImpactInfoes/Create
        public ActionResult Create()
        {
            ViewBag.FaultId = new SelectList(db.Faults, "FaultId", "FaultSeverity");
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName");
            ViewBag.TicketId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus");
            ViewBag.TroubleshooterId = new SelectList(db.Troubleshooters, "TroubleshooterId", "TroubleshooterName");
            return View();
        }

        // POST: ImpactInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Impactid,TicketId,TeamId,FaultId,TroubleshooterId,TicketRaisedDate,TicketClosingDate")] ImpactInfo impactInfo)
        {
            if (ModelState.IsValid)
            {
                db.ImpactInfoes.Add(impactInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FaultId = new SelectList(db.Faults, "FaultId", "FaultSeverity", impactInfo.FaultId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", impactInfo.TeamId);
            ViewBag.TicketId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", impactInfo.TicketId);
            ViewBag.TroubleshooterId = new SelectList(db.Troubleshooters, "TroubleshooterId", "TroubleshooterName", impactInfo.TroubleshooterId);
            return View(impactInfo);
        }

        // GET: ImpactInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImpactInfo impactInfo = db.ImpactInfoes.Find(id);
            if (impactInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.FaultId = new SelectList(db.Faults, "FaultId", "FaultSeverity", impactInfo.FaultId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", impactInfo.TeamId);
            ViewBag.TicketId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", impactInfo.TicketId);
            ViewBag.TroubleshooterId = new SelectList(db.Troubleshooters, "TroubleshooterId", "TroubleshooterName", impactInfo.TroubleshooterId);
            return View(impactInfo);
        }

        // POST: ImpactInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Impactid,TicketId,TeamId,FaultId,TroubleshooterId,TicketRaisedDate,TicketClosingDate")] ImpactInfo impactInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(impactInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FaultId = new SelectList(db.Faults, "FaultId", "FaultSeverity", impactInfo.FaultId);
            ViewBag.TeamId = new SelectList(db.Teams, "TeamId", "TeamName", impactInfo.TeamId);
            ViewBag.TicketId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", impactInfo.TicketId);
            ViewBag.TroubleshooterId = new SelectList(db.Troubleshooters, "TroubleshooterId", "TroubleshooterName", impactInfo.TroubleshooterId);
            return View(impactInfo);
        }

        // GET: ImpactInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImpactInfo impactInfo = db.ImpactInfoes.Find(id);
            if (impactInfo == null)
            {
                return HttpNotFound();
            }
            return View(impactInfo);
        }

        // POST: ImpactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ImpactInfo impactInfo = db.ImpactInfoes.Find(id);
            db.ImpactInfoes.Remove(impactInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
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
