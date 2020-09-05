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
    public class TroubleshootersController : Controller
    {
        private FaultManagementEntities db = new FaultManagementEntities();

        // GET: Troubleshooters
        public ActionResult Index()
        {
            var troubleshooters = db.Troubleshooters.Include(t => t.Designation).Include(t => t.FaultType).Include(t => t.Team).Include(t => t.TroubleshooterManager);
            return View(troubleshooters.ToList());
        }

        // GET: Troubleshooters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Troubleshooter troubleshooter = db.Troubleshooters.Find(id);
            if (troubleshooter == null)
            {
                return HttpNotFound();
            }
            return View(troubleshooter);
        }

        // GET: Troubleshooters/Create
        public ActionResult Create()
        {
            ViewBag.TroubleshooterDesignation = new SelectList(db.Designations, "DesignationId", "Designation1");
            ViewBag.TroubleshooterExpertise = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1");
            ViewBag.TroubleshooterTeam = new SelectList(db.Teams, "TeamId", "TeamName");
            ViewBag.ManagerofTroubleshooter = new SelectList(db.TroubleshooterManagers, "TroubleshooterManagerId", "ManagerName");
            return View();
        }

        // POST: Troubleshooters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TroubleshooterId,TroubleshooterName,TroubleshooterDesignation,TroubleshooterTeam,TroubleshooterPhoneNo,TroubleshooterExpertise,YearOfExperience,ManagerofTroubleshooter,NumberofSolves")] Troubleshooter troubleshooter)
        {
            if (ModelState.IsValid)
            {
                db.Troubleshooters.Add(troubleshooter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TroubleshooterDesignation = new SelectList(db.Designations, "DesignationId", "Designation1", troubleshooter.TroubleshooterDesignation);
            ViewBag.TroubleshooterExpertise = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1", troubleshooter.TroubleshooterExpertise);
            ViewBag.TroubleshooterTeam = new SelectList(db.Teams, "TeamId", "TeamName", troubleshooter.TroubleshooterTeam);
            ViewBag.ManagerofTroubleshooter = new SelectList(db.TroubleshooterManagers, "TroubleshooterManagerId", "ManagerName", troubleshooter.ManagerofTroubleshooter);
            return View(troubleshooter);
        }

        // GET: Troubleshooters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Troubleshooter troubleshooter = db.Troubleshooters.Find(id);
            if (troubleshooter == null)
            {
                return HttpNotFound();
            }
            ViewBag.TroubleshooterDesignation = new SelectList(db.Designations, "DesignationId", "Designation1", troubleshooter.TroubleshooterDesignation);
            ViewBag.TroubleshooterExpertise = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1", troubleshooter.TroubleshooterExpertise);
            ViewBag.TroubleshooterTeam = new SelectList(db.Teams, "TeamId", "TeamName", troubleshooter.TroubleshooterTeam);
            ViewBag.ManagerofTroubleshooter = new SelectList(db.TroubleshooterManagers, "TroubleshooterManagerId", "ManagerName", troubleshooter.ManagerofTroubleshooter);
            return View(troubleshooter);
        }

        // POST: Troubleshooters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TroubleshooterId,TroubleshooterName,TroubleshooterDesignation,TroubleshooterTeam,TroubleshooterPhoneNo,TroubleshooterExpertise,YearOfExperience,ManagerofTroubleshooter,NumberofSolves")] Troubleshooter troubleshooter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(troubleshooter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TroubleshooterDesignation = new SelectList(db.Designations, "DesignationId", "Designation1", troubleshooter.TroubleshooterDesignation);
            ViewBag.TroubleshooterExpertise = new SelectList(db.FaultTypes, "FaultTypeId", "FaultType1", troubleshooter.TroubleshooterExpertise);
            ViewBag.TroubleshooterTeam = new SelectList(db.Teams, "TeamId", "TeamName", troubleshooter.TroubleshooterTeam);
            ViewBag.ManagerofTroubleshooter = new SelectList(db.TroubleshooterManagers, "TroubleshooterManagerId", "ManagerName", troubleshooter.ManagerofTroubleshooter);
            return View(troubleshooter);
        }

        // GET: Troubleshooters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Troubleshooter troubleshooter = db.Troubleshooters.Find(id);
            if (troubleshooter == null)
            {
                return HttpNotFound();
            }
            return View(troubleshooter);
        }

        // POST: Troubleshooters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Troubleshooter troubleshooter = db.Troubleshooters.Find(id);
            db.Troubleshooters.Remove(troubleshooter);
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
