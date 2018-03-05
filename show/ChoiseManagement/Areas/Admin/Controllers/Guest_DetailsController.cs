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
    public class Guest_DetailsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Guest_Details
        public async Task<ActionResult> Index()
        {
            return View(await db.Guest_Details.ToListAsync());
        }

        // GET: Admin/Guest_Details/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest_Details guest_Details = await db.Guest_Details.FindAsync(id);
            if (guest_Details == null)
            {
                return HttpNotFound();
            }
            return View(guest_Details);
        }

        // GET: Admin/Guest_Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Guest_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Guest_Id,Guest_Title,Guest_First_Name,Guest_Last_Name,Guest_Address,Guest_Email,Guest_MobileNO,Guest_CreditCardNo,Paasword")] Guest_Details guest_Details)
        {
            if (ModelState.IsValid)
            {
                db.Guest_Details.Add(guest_Details);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(guest_Details);
        }

        // GET: Admin/Guest_Details/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest_Details guest_Details = await db.Guest_Details.FindAsync(id);
            if (guest_Details == null)
            {
                return HttpNotFound();
            }
            return View(guest_Details);
        }

        // POST: Admin/Guest_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Guest_Id,Guest_Title,Guest_First_Name,Guest_Last_Name,Guest_Address,Guest_Email,Guest_MobileNO,Guest_CreditCardNo,Paasword")] Guest_Details guest_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest_Details).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(guest_Details);
        }

        // GET: Admin/Guest_Details/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest_Details guest_Details = await db.Guest_Details.FindAsync(id);
            if (guest_Details == null)
            {
                return HttpNotFound();
            }
            return View(guest_Details);
        }

        // POST: Admin/Guest_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Guest_Details guest_Details = await db.Guest_Details.FindAsync(id);
            db.Guest_Details.Remove(guest_Details);
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
