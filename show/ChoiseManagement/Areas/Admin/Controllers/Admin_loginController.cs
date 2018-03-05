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
    public class Admin_loginController : Controller
    {
        private HotelModel db = new HotelModel();

        // GET: Admin/Admin_login
        public async Task<ActionResult> Index()
        {
            return View(await db.Admin_login.ToListAsync());
        }

        // GET: Admin/Admin_login/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_login admin_login = await db.Admin_login.FindAsync(id);
            if (admin_login == null)
            {
                return HttpNotFound();
            }
            return View(admin_login);
        }

        // GET: Admin/Admin_login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admin_login/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Depertment_Id,Depertment,Password")] Admin_login admin_login)
        {
            if (ModelState.IsValid)
            {
                db.Admin_login.Add(admin_login);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(admin_login);
        }

        // GET: Admin/Admin_login/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_login admin_login = await db.Admin_login.FindAsync(id);
            if (admin_login == null)
            {
                return HttpNotFound();
            }
            return View(admin_login);
        }

        // POST: Admin/Admin_login/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Depertment_Id,Depertment,Password")] Admin_login admin_login)
        {
            if (ModelState.IsValid)
            {
                db.Entry(admin_login).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(admin_login);
        }

        // GET: Admin/Admin_login/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin_login admin_login = await db.Admin_login.FindAsync(id);
            if (admin_login == null)
            {
                return HttpNotFound();
            }
            return View(admin_login);
        }

        // POST: Admin/Admin_login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Admin_login admin_login = await db.Admin_login.FindAsync(id);
            db.Admin_login.Remove(admin_login);
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
