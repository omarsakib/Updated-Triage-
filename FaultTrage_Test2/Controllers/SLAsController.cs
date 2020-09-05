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
    public class SLAsController : Controller
    {
        private FaultManagementEntities db = new FaultManagementEntities();

        // GET: SLAs
        public ActionResult Index()
        {
            var sLAs = db.SLAs.Include(s => s.FaultType1);
            return View(sLAs.ToList());
        }

        // GET: SLAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLA sLA = db.SLAs.Find(id);
            if (sLA == null)
            {
                return HttpNotFound();
            }
            return View(sLA);
        }

        // GET: SLAs/Create
        public ActionResult Create()
        {
            ViewBag.FaultType = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1");
            return View();
        }

        // POST: SLAs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SLAId,FaultType,TimeForTroubleshooting")] SLA sLA)
        {
            if (ModelState.IsValid)
            {
                db.SLAs.Add(sLA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FaultType = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1", sLA.FaultType);
            return View(sLA);
        }

        // GET: SLAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLA sLA = db.SLAs.Find(id);
            if (sLA == null)
            {
                return HttpNotFound();
            }
            ViewBag.FaultType = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1", sLA.FaultType);
            return View(sLA);
        }

        // POST: SLAs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SLAId,FaultType,TimeForTroubleshooting")] SLA sLA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sLA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FaultType = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1", sLA.FaultType);
            return View(sLA);
        }

        // GET: SLAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLA sLA = db.SLAs.Find(id);
            if (sLA == null)
            {
                return HttpNotFound();
            }
            return View(sLA);
        }

        // POST: SLAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SLA sLA = db.SLAs.Find(id);
            db.SLAs.Remove(sLA);
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
