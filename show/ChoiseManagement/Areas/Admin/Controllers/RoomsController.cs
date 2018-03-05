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
    public class RoomsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Rooms
        public async Task<ActionResult> Index()
        {
            var rooms = db.Rooms.Include(r => r.Room_Catagorys);
            return View(await rooms.ToListAsync());
        }

        // GET: Admin/Rooms/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // GET: Admin/Rooms/Create
        public ActionResult Create()
        {
            ViewBag.Room_Category_Id = new SelectList(db.Room_Catagorys, "Room_Catogory_Id", "Room_Catogory");
            return View();
        }

        // POST: Admin/Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Room_Id,Room_Category_Id,Room_Number,Room_Description,Room_Image_url_1,Room_Image_url_2,Room_Image_url_3,Room_Image_url_4,Room_Image_url_5,RoomCapacity")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Rooms.Add(room);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Room_Category_Id = new SelectList(db.Room_Catagorys, "Room_Catogory_Id", "Room_Catogory", room.Room_Category_Id);
            return View(room);
        }

        // GET: Admin/Rooms/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            ViewBag.Room_Category_Id = new SelectList(db.Room_Catagorys, "Room_Catogory_Id", "Room_Catogory", room.Room_Category_Id);
            return View(room);
        }

        // POST: Admin/Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Room_Id,Room_Category_Id,Room_Number,Room_Description,Room_Image_url_1,Room_Image_url_2,Room_Image_url_3,Room_Image_url_4,Room_Image_url_5,RoomCapacity")] Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Room_Category_Id = new SelectList(db.Room_Catagorys, "Room_Catogory_Id", "Room_Catogory", room.Room_Category_Id);
            return View(room);
        }

        // GET: Admin/Rooms/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = await db.Rooms.FindAsync(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            return View(room);
        }

        // POST: Admin/Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Room room = await db.Rooms.FindAsync(id);
            db.Rooms.Remove(room);
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
