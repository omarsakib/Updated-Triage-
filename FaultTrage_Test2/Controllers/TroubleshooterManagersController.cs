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
    public class TroubleshooterManagersController : Controller
    {
        private FaultManagementEntities db = new FaultManagementEntities();

        // GET: TroubleshooterManagers
        public ActionResult Index()
        {
            return View(db.TroubleshooterManagers.ToList());
        }

        // GET: TroubleshooterManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroubleshooterManager troubleshooterManager = db.TroubleshooterManagers.Find(id);
            if (troubleshooterManager == null)
            {
                return HttpNotFound();
            }
            return View(troubleshooterManager);
        }

        // GET: TroubleshooterManagers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TroubleshooterManagers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TroubleshooterManagerId,ManagerName,ManagerDesignation")] TroubleshooterManager troubleshooterManager)
        {
            if (ModelState.IsValid)
            {
                db.TroubleshooterManagers.Add(troubleshooterManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(troubleshooterManager);
        }

        // GET: TroubleshooterManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroubleshooterManager troubleshooterManager = db.TroubleshooterManagers.Find(id);
            if (troubleshooterManager == null)
            {
                return HttpNotFound();
            }
            return View(troubleshooterManager);
        }

        // POST: TroubleshooterManagers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TroubleshooterManagerId,ManagerName,ManagerDesignation")] TroubleshooterManager troubleshooterManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(troubleshooterManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(troubleshooterManager);
        }

        // GET: TroubleshooterManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TroubleshooterManager troubleshooterManager = db.TroubleshooterManagers.Find(id);
            if (troubleshooterManager == null)
            {
                return HttpNotFound();
            }
            return View(troubleshooterManager);
        }

        // POST: TroubleshooterManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TroubleshooterManager troubleshooterManager = db.TroubleshooterManagers.Find(id);
            db.TroubleshooterManagers.Remove(troubleshooterManager);
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
