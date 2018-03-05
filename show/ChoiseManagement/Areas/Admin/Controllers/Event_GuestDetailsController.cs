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
    public class Event_GuestDetailsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Event_GuestDetails
        public async Task<ActionResult> Index()
        {
            return View(await db.Event_GuestDetails.ToListAsync());
        }

        // GET: Admin/Event_GuestDetails/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_GuestDetails event_GuestDetails = await db.Event_GuestDetails.FindAsync(id);
            if (event_GuestDetails == null)
            {
                return HttpNotFound();
            }
            return View(event_GuestDetails);
        }

        // GET: Admin/Event_GuestDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Event_GuestDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EventReservationId,GuestName,Guest_Email,Guest_Contact_No,EventName,EventDescription")] Event_GuestDetails event_GuestDetails)
        {
            if (ModelState.IsValid)
            {
                db.Event_GuestDetails.Add(event_GuestDetails);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(event_GuestDetails);
        }

        // GET: Admin/Event_GuestDetails/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_GuestDetails event_GuestDetails = await db.Event_GuestDetails.FindAsync(id);
            if (event_GuestDetails == null)
            {
                return HttpNotFound();
            }
            return View(event_GuestDetails);
        }

        // POST: Admin/Event_GuestDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EventReservationId,GuestName,Guest_Email,Guest_Contact_No,EventName,EventDescription")] Event_GuestDetails event_GuestDetails)
        {
            if (ModelState.IsValid)
            {
                db.Entry(event_GuestDetails).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(event_GuestDetails);
        }

        // GET: Admin/Event_GuestDetails/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_GuestDetails event_GuestDetails = await db.Event_GuestDetails.FindAsync(id);
            if (event_GuestDetails == null)
            {
                return HttpNotFound();
            }
            return View(event_GuestDetails);
        }

        // POST: Admin/Event_GuestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Event_GuestDetails event_GuestDetails = await db.Event_GuestDetails.FindAsync(id);
            db.Event_GuestDetails.Remove(event_GuestDetails);
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
