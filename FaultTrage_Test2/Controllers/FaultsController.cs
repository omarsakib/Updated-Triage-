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
    public class FaultsController : Controller
    {
        private FaultManagementEntities db = new FaultManagementEntities();

        // GET: Faults
        public ActionResult Index()
        {
            var faults = db.Faults.Include(f => f.SLA1);
            return View(faults.ToList());
        }

        // GET: Faults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fault fault = db.Faults.Find(id);
            if (fault == null)
            {
                return HttpNotFound();
            }
            return View(fault);
        }

        // GET: Faults/Create
        public ActionResult Create()
        {
            ViewBag.SLA = new SelectList(db.SLAs, "SLAId", "SLAId");
            return View();
        }

        // POST: Faults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FaultId,FaultType,FaultSeverity,FaultComponent,FaultEventDate,SLA,FaultPlatform,FaultImpact,TicketStatus,FaultEscalationTime")] Fault fault)
        {
            if (ModelState.IsValid)
            {
                db.Faults.Add(fault);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SLA = new SelectList(db.SLAs, "SLAId", "SLAId", fault.SLA);
            return View(fault);
        }

        // GET: Faults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fault fault = db.Faults.Find(id);
            if (fault == null)
            {
                return HttpNotFound();
            }
            ViewBag.SLA = new SelectList(db.SLAs, "SLAId", "SLAId", fault.SLA);
            return View(fault);
        }

        // POST: Faults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FaultId,FaultType,FaultSeverity,FaultComponent,FaultEventDate,SLA,FaultPlatform,FaultImpact,TicketStatus,FaultEscalationTime")] Fault fault)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fault).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SLA = new SelectList(db.SLAs, "SLAId", "SLAId", fault.SLA);
            return View(fault);
        }

        // GET: Faults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fault fault = db.Faults.Find(id);
            if (fault == null)
            {
                return HttpNotFound();
            }
            return View(fault);
        }

        // POST: Faults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fault fault = db.Faults.Find(id);
            db.Faults.Remove(fault);
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
