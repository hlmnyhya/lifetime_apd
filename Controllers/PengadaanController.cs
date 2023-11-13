using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lifetime_apd;

namespace lifetime_apd.Controllers
{
    public class PengadaanController : Controller
    {
        private lifetime_apdEntities db = new lifetime_apdEntities();

        // GET: Pengadaan
        public ActionResult Index()
        {
            return View(db.pengadaans.ToList());
        }

        // GET: Pengadaan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pengadaan pengadaan = db.pengadaans.Find(id);
            if (pengadaan == null)
            {
                return HttpNotFound();
            }
            return View(pengadaan);
        }

        // GET: Pengadaan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pengadaan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JUMLAH_PENGADAAN,TANGGAL_PENGADAAN")] pengadaan pengadaan)
        {
            if (ModelState.IsValid)
            {
                db.pengadaans.Add(pengadaan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pengadaan);
        }

        // GET: Pengadaan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pengadaan pengadaan = db.pengadaans.Find(id);
            if (pengadaan == null)
            {
                return HttpNotFound();
            }
            return View(pengadaan);
        }

        // POST: Pengadaan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JUMLAH_PENGADAAN,TANGGAL_PENGADAAN")] pengadaan pengadaan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pengadaan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pengadaan);
        }

        // GET: Pengadaan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pengadaan pengadaan = db.pengadaans.Find(id);
            if (pengadaan == null)
            {
                return HttpNotFound();
            }
            return View(pengadaan);
        }

        // POST: Pengadaan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pengadaan pengadaan = db.pengadaans.Find(id);
            db.pengadaans.Remove(pengadaan);
            db.SaveChanges();
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
