using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lifetime_apd;

namespace lifetime_apd.Controllers
{
    public class ApdController : Controller
    {
        private lifetime_apdEntities db = new lifetime_apdEntities();

        // GET: Apd
        public async Task<ActionResult> Index()
        {
            return View(await db.apds.ToListAsync());
        }

        // GET: Apd/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apd apd = await db.apds.FindAsync(id);
            if (apd == null)
            {
                return HttpNotFound();
            }
            return View(apd);
        }

        // GET: Apd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apd/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,NAMA_APD,GAMBAR_APD")] apd apd)
        {
            if (ModelState.IsValid)
            {
                db.apds.Add(apd);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(apd);
        }

        // GET: Apd/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apd apd = await db.apds.FindAsync(id);
            if (apd == null)
            {
                return HttpNotFound();
            }
            return View(apd);
        }

        // POST: Apd/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,NAMA_APD,GAMBAR_APD")] apd apd)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apd).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(apd);
        }

        // GET: Apd/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            apd apd = await db.apds.FindAsync(id);
            if (apd == null)
            {
                return HttpNotFound();
            }
            return View(apd);
        }

        // POST: Apd/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            apd apd = await db.apds.FindAsync(id);
            db.apds.Remove(apd);
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
