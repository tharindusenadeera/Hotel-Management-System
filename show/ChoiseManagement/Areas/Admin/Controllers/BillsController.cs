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
    public class BillsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Bills
        public async Task<ActionResult> Index()
        {
            var bills = db.Bills.Include(b => b.Reservation_ID);
            return View(await bills.ToListAsync());
        }

        // GET: Admin/Bills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // GET: Admin/Bills/Create
        public ActionResult Create()
        {
            ViewBag.Reservation_ID = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id");
            return View();
        }

        // POST: Admin/Bills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Bill_ID,Reservation_ID,Total_Charge,Paid")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Bills.Add(bill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Reservation_ID = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id", bill.Reservation_ID);
            return View(bill);
        }

        // GET: Admin/Bills/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            ViewBag.Reservation_ID = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id", bill.Reservation_ID);
            return View(bill);
        }

        // POST: Admin/Bills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Bill_ID,Reservation_ID,Total_Charge,Paid")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Reservation_ID = new SelectList(db.Reservations, "Reservation_Id", "Reservation_Id", bill.Reservation_ID);
            return View(bill);
        }

        // GET: Admin/Bills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill bill = await db.Bills.FindAsync(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        // POST: Admin/Bills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Bill bill = await db.Bills.FindAsync(id);
            db.Bills.Remove(bill);
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
