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
    public class ReservationsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Reservations
        public async Task<ActionResult> Index()
        {
            var reservations = db.Reservations.Include(r => r.Guest_Details).Include(r => r.Package).Include(r => r.Room);
            return View(await reservations.ToListAsync());
        }

        // GET: Admin/Reservations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // GET: Admin/Reservations/Create
        public ActionResult Create()
        {
            ViewBag.Guest_Id = new SelectList(db.Guest_Details, "Guest_Id", "Guest_Title");
            ViewBag.Package_Id = new SelectList(db.Packages, "Package_ID", "Package_Name");
            ViewBag.Room_Number = new SelectList(db.Rooms, "Room_Id", "Room_Description");
            return View();
        }

        // POST: Admin/Reservations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Reservation_Id,Guest_Id,Package_Id,Room_Number,Check_In,Check_Out,Adults,Childrens")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Reservations.Add(reservation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Guest_Id = new SelectList(db.Guest_Details, "Guest_Id", "Guest_Title", reservation.Guest_Id);
            ViewBag.Package_Id = new SelectList(db.Packages, "Package_ID", "Package_Name", reservation.Package_Id);
            ViewBag.Room_Number = new SelectList(db.Rooms, "Room_Id", "Room_Description", reservation.Room_Number);
            return View(reservation);
        }

        // GET: Admin/Reservations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            ViewBag.Guest_Id = new SelectList(db.Guest_Details, "Guest_Id", "Guest_Title", reservation.Guest_Id);
            ViewBag.Package_Id = new SelectList(db.Packages, "Package_ID", "Package_Name", reservation.Package_Id);
            ViewBag.Room_Number = new SelectList(db.Rooms, "Room_Id", "Room_Description", reservation.Room_Number);
            return View(reservation);
        }

        // POST: Admin/Reservations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Reservation_Id,Guest_Id,Package_Id,Room_Number,Check_In,Check_Out,Adults,Childrens")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Guest_Id = new SelectList(db.Guest_Details, "Guest_Id", "Guest_Title", reservation.Guest_Id);
            ViewBag.Package_Id = new SelectList(db.Packages, "Package_ID", "Package_Name", reservation.Package_Id);
            ViewBag.Room_Number = new SelectList(db.Rooms, "Room_Id", "Room_Description", reservation.Room_Number);
            return View(reservation);
        }

        // GET: Admin/Reservations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reservation reservation = await db.Reservations.FindAsync(id);
            if (reservation == null)
            {
                return HttpNotFound();
            }
            return View(reservation);
        }

        // POST: Admin/Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Reservation reservation = await db.Reservations.FindAsync(id);
            db.Reservations.Remove(reservation);
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
