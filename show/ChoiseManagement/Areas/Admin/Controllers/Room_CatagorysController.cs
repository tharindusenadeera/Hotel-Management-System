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
    public class Room_CatagorysController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Room_Catagorys
        public async Task<ActionResult> Index()
        {
            return View(await db.Room_Catagorys.ToListAsync());
        }

        // GET: Admin/Room_Catagorys/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Catagorys room_Catagorys = await db.Room_Catagorys.FindAsync(id);
            if (room_Catagorys == null)
            {
                return HttpNotFound();
            }
            return View(room_Catagorys);
        }

        // GET: Admin/Room_Catagorys/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Room_Catagorys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Room_Catogory_Id,Room_Catogory,Room_Description,Image_Url,IsActive,LCD_Television,DvdPlayer,RoomServices,MiniBar,WiFi,HairDrier")] Room_Catagorys room_Catagorys)
        {
            if (ModelState.IsValid)
            {
                db.Room_Catagorys.Add(room_Catagorys);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(room_Catagorys);
        }

        // GET: Admin/Room_Catagorys/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Catagorys room_Catagorys = await db.Room_Catagorys.FindAsync(id);
            if (room_Catagorys == null)
            {
                return HttpNotFound();
            }
            return View(room_Catagorys);
        }

        // POST: Admin/Room_Catagorys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Room_Catogory_Id,Room_Catogory,Room_Description,Image_Url,IsActive,LCD_Television,DvdPlayer,RoomServices,MiniBar,WiFi,HairDrier")] Room_Catagorys room_Catagorys)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room_Catagorys).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(room_Catagorys);
        }

        // GET: Admin/Room_Catagorys/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room_Catagorys room_Catagorys = await db.Room_Catagorys.FindAsync(id);
            if (room_Catagorys == null)
            {
                return HttpNotFound();
            }
            return View(room_Catagorys);
        }

        // POST: Admin/Room_Catagorys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Room_Catagorys room_Catagorys = await db.Room_Catagorys.FindAsync(id);
            db.Room_Catagorys.Remove(room_Catagorys);
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
