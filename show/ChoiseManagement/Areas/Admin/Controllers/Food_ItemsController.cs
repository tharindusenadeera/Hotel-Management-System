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
    public class Food_ItemsController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Food_Items
        public async Task<ActionResult> Index()
        {
            var food_Items = db.Food_Items.Include(f => f.Food_Categories);
            return View(await food_Items.ToListAsync());
        }

        // GET: Admin/Food_Items/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Items food_Items = await db.Food_Items.FindAsync(id);
            if (food_Items == null)
            {
                return HttpNotFound();
            }
            return View(food_Items);
        }

        // GET: Admin/Food_Items/Create
        public ActionResult Create()
        {
            ViewBag.Item_Category_ID = new SelectList(db.Food_Categories, "Food_category_Id", "Category");
            return View();
        }

        // POST: Admin/Food_Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Item_Category_ID,Item_Name,Item_Code,Description,Portion_Price,Image_URL")] Food_Items food_Items)
        {
            if (ModelState.IsValid)
            {
                db.Food_Items.Add(food_Items);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Item_Category_ID = new SelectList(db.Food_Categories, "Food_category_Id", "Category", food_Items.Item_Category_ID);
            return View(food_Items);
        }

        // GET: Admin/Food_Items/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Items food_Items = await db.Food_Items.FindAsync(id);
            if (food_Items == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_Category_ID = new SelectList(db.Food_Categories, "Food_category_Id", "Category", food_Items.Item_Category_ID);
            return View(food_Items);
        }

        // POST: Admin/Food_Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Item_Category_ID,Item_Name,Item_Code,Description,Portion_Price,Image_URL")] Food_Items food_Items)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Items).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Item_Category_ID = new SelectList(db.Food_Categories, "Food_category_Id", "Category", food_Items.Item_Category_ID);
            return View(food_Items);
        }

        // GET: Admin/Food_Items/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Items food_Items = await db.Food_Items.FindAsync(id);
            if (food_Items == null)
            {
                return HttpNotFound();
            }
            return View(food_Items);
        }

        // POST: Admin/Food_Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Food_Items food_Items = await db.Food_Items.FindAsync(id);
            db.Food_Items.Remove(food_Items);
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
