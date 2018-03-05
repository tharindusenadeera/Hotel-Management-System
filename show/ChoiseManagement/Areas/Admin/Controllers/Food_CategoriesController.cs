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
    public class Food_CategoriesController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Food_Categories
        public async Task<ActionResult> Index()
        {
            return View(await db.Food_Categories.ToListAsync());
        }

        // GET: Admin/Food_Categories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Categories food_Categories = await db.Food_Categories.FindAsync(id);
            if (food_Categories == null)
            {
                return HttpNotFound();
            }
            return View(food_Categories);
        }

        // GET: Admin/Food_Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Food_Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Food_category_Id,Category,Description")] Food_Categories food_Categories)
        {
            if (ModelState.IsValid)
            {
                db.Food_Categories.Add(food_Categories);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(food_Categories);
        }

        // GET: Admin/Food_Categories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Categories food_Categories = await db.Food_Categories.FindAsync(id);
            if (food_Categories == null)
            {
                return HttpNotFound();
            }
            return View(food_Categories);
        }

        // POST: Admin/Food_Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Food_category_Id,Category,Description")] Food_Categories food_Categories)
        {
            if (ModelState.IsValid)
            {
                db.Entry(food_Categories).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(food_Categories);
        }

        // GET: Admin/Food_Categories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Food_Categories food_Categories = await db.Food_Categories.FindAsync(id);
            if (food_Categories == null)
            {
                return HttpNotFound();
            }
            return View(food_Categories);
        }

        // POST: Admin/Food_Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Food_Categories food_Categories = await db.Food_Categories.FindAsync(id);
            db.Food_Categories.Remove(food_Categories);
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
