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
    public class TicketStatusController : Controller
    {
        private FaultManagementEntities db = new FaultManagementEntities();

        // GET: TicketStatus
        public ActionResult Index()
        {
            var ticketStatus = db.TicketStatus.Include(t => t.TicketStatus1).Include(t => t.TicketStatu1);
            return View(ticketStatus.ToList());
        }

        // GET: TicketStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketStatu ticketStatu = db.TicketStatus.Find(id);
            if (ticketStatu == null)
            {
                return HttpNotFound();
            }
            return View(ticketStatu);
        }

        // GET: TicketStatus/Create
        public ActionResult Create()
        {
            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus");
            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus");
            return View();
        }

        // POST: TicketStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketStausId,TicketStatus")] TicketStatu ticketStatu)
        {
            if (ModelState.IsValid)
            {
                db.TicketStatus.Add(ticketStatu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", ticketStatu.TicketStausId);
            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", ticketStatu.TicketStausId);
            return View(ticketStatu);
        }

        // GET: TicketStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketStatu ticketStatu = db.TicketStatus.Find(id);
            if (ticketStatu == null)
            {
                return HttpNotFound();
            }
            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", ticketStatu.TicketStausId);
            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", ticketStatu.TicketStausId);
            return View(ticketStatu);
        }

        // POST: TicketStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketStausId,TicketStatus")] TicketStatu ticketStatu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketStatu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", ticketStatu.TicketStausId);
            ViewBag.TicketStausId = new SelectList(db.TicketStatus, "TicketStausId", "TicketStatus", ticketStatu.TicketStausId);
            return View(ticketStatu);
        }

        // GET: TicketStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TicketStatu ticketStatu = db.TicketStatus.Find(id);
            if (ticketStatu == null)
            {
                return HttpNotFound();
            }
            return View(ticketStatu);
        }

        // POST: TicketStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TicketStatu ticketStatu = db.TicketStatus.Find(id);
            db.TicketStatus.Remove(ticketStatu);
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
