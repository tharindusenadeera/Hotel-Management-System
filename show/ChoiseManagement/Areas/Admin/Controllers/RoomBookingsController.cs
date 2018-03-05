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
    public class RoomBookingsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/RoomBookings
        public async Task<ActionResult> Index()
        {
            var roomBookings = db.RoomBookings.Include(r => r.Reservation);
            return View(await roomBookings.ToListAsync());
        }

        // GET: Admin/RoomBookings/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomBooking roomBooking = await db.RoomBookings.FindAsync(id);
            if (roomBooking == null)
            {
                return HttpNotFound();
            }
            return View(roomBooking);
        }

        // GET: Admin/RoomBookings/Create
        public ActionResult Create()
        {
            ViewBag.ReservationId = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id");
            return View();
        }

        // POST: Admin/RoomBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BookingID,RoomNo,CategoryId,ArivalDate,DepartureDate,ReservationId")] RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                db.RoomBookings.Add(roomBooking);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ReservationId = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id", roomBooking.ReservationId);
            return View(roomBooking);
        }

        // GET: Admin/RoomBookings/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomBooking roomBooking = await db.RoomBookings.FindAsync(id);
            if (roomBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReservationId = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id", roomBooking.ReservationId);
            return View(roomBooking);
        }

        // POST: Admin/RoomBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BookingID,RoomNo,CategoryId,ArivalDate,DepartureDate,ReservationId")] RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomBooking).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ReservationId = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id", roomBooking.ReservationId);
            return View(roomBooking);
        }

        // GET: Admin/RoomBookings/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomBooking roomBooking = await db.RoomBookings.FindAsync(id);
            if (roomBooking == null)
            {
                return HttpNotFound();
            }
            return View(roomBooking);
        }

        // POST: Admin/RoomBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RoomBooking roomBooking = await db.RoomBookings.FindAsync(id);
            db.RoomBookings.Remove(roomBooking);
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
