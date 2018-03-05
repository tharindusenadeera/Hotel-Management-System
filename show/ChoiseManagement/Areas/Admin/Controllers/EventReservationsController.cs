using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ChoiseManagement.Models.Hotel;

namespace ChoiseManagement.Areas.Admin.Controllers
{
    public class EventReservationsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/EventReservations
        public async Task<ActionResult> Index()
        {
            var eventReservations = db.EventReservations.Include(e => e.Event_GuestDetails).Include(e => e.Hall);
            return View(await eventReservations.ToListAsync());
        }

        // GET: Admin/EventReservations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventReservation eventReservation = await db.EventReservations.FindAsync(id);
            if (eventReservation == null)
            {
                return HttpNotFound();
            }
            return View(eventReservation);
        }

        // GET: Admin/EventReservations/Create
        public ActionResult Create()
        {
            ViewBag.EventReservationId = new SelectList(db.Event_GuestDetails, "EventReservationId", "GuestName");
            ViewBag.HallNumber = new SelectList(db.Halls, "HallId", "HallName");
            return View();
        }

        // POST: Admin/EventReservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EventBookingID,HallNumber,EventStartDate,EventEndDate,EventReservationId")] EventReservation eventReservation)
        {
            if (ModelState.IsValid)
            {
                db.EventReservations.Add(eventReservation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EventReservationId = new SelectList(db.Event_GuestDetails, "EventReservationId", "GuestName", eventReservation.EventReservationId);
            ViewBag.HallNumber = new SelectList(db.Halls, "HallId", "HallName", eventReservation.HallNumber);
            return View(eventReservation);
        }

        // GET: Admin/EventReservations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventReservation eventReservation = await db.EventReservations.FindAsync(id);
            if (eventReservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventReservationId = new SelectList(db.Event_GuestDetails, "EventReservationId", "GuestName", eventReservation.EventReservationId);
            ViewBag.HallNumber = new SelectList(db.Halls, "HallId", "HallName", eventReservation.HallNumber);
            return View(eventReservation);
        }

        // POST: Admin/EventReservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EventBookingID,HallNumber,EventStartDate,EventEndDate,EventReservationId")] EventReservation eventReservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventReservation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EventReservationId = new SelectList(db.Event_GuestDetails, "EventReservationId", "GuestName", eventReservation.EventReservationId);
            ViewBag.HallNumber = new SelectList(db.Halls, "HallId", "HallName", eventReservation.HallNumber);
            return View(eventReservation);
        }

        // GET: Admin/EventReservations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventReservation eventReservation = await db.EventReservations.FindAsync(id);
            if (eventReservation == null)
            {
                return HttpNotFound();
            }
            return View(eventReservation);
        }

        // POST: Admin/EventReservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EventReservation eventReservation = await db.EventReservations.FindAsync(id);
            db.EventReservations.Remove(eventReservation);
            await db.SaveChangesAsync();
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
