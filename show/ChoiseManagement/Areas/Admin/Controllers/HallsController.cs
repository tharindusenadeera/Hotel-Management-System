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
    public class HallsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Halls
        public async Task<ActionResult> Index()
        {
            return View(await db.Halls.ToListAsync());
        }

        // GET: Admin/Halls/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = await db.Halls.FindAsync(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // GET: Admin/Halls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Halls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HallId,HallName,HallCapacity,HallDescription,HImage1,HImage2,HImage3,HImage4,Hall_price_Hour")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Halls.Add(hall);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hall);
        }

        // GET: Admin/Halls/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = await db.Halls.FindAsync(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Admin/Halls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HallId,HallName,HallCapacity,HallDescription,HImage1,HImage2,HImage3,HImage4,Hall_price_Hour")] Hall hall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hall).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hall);
        }

        // GET: Admin/Halls/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hall hall = await db.Halls.FindAsync(id);
            if (hall == null)
            {
                return HttpNotFound();
            }
            return View(hall);
        }

        // POST: Admin/Halls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Hall hall = await db.Halls.FindAsync(id);
            db.Halls.Remove(hall);
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
