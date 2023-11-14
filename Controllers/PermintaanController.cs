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
    public class PermintaanController : Controller
    {
        private lifetime_apdEntities db = new lifetime_apdEntities();

        // GET: Permintaan
        public ActionResult Index()
        {
            var permintaans = db.permintaans.Include(p => p.apd).Include(p => p.karyawan);
            return View(permintaans.ToList());
        }

        // GET: Permintaan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permintaan permintaan = db.permintaans.Find(id);
            if (permintaan == null)
            {
                return HttpNotFound();
            }
            return View(permintaan);
        }

        // GET: Permintaan/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERMINTAAN = new SelectList(db.apds, "ID", "NAMA_APD");
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP");
            return View();
        }

        // POST: Permintaan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_PERMINTAAN,ID_KARYAWAN,TANGGAL_PERMINTAAN,JUMLAH_PERMINTAAN,STATUS_PERMINTAAN")] permintaan permintaan)
        {
            if (ModelState.IsValid)
            {
                db.permintaans.Add(permintaan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERMINTAAN = new SelectList(db.apds, "ID", "NAMA_APD", permintaan.ID_PERMINTAAN);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", permintaan.ID_KARYAWAN);
            return View(permintaan);
        }

        // GET: Permintaan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permintaan permintaan = db.permintaans.Find(id);
            if (permintaan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERMINTAAN = new SelectList(db.apds, "ID", "NAMA_APD", permintaan.ID_PERMINTAAN);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", permintaan.ID_KARYAWAN);
            return View(permintaan);
        }

        // POST: Permintaan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_PERMINTAAN,ID_KARYAWAN,TANGGAL_PERMINTAAN,JUMLAH_PERMINTAAN,STATUS_PERMINTAAN")] permintaan permintaan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permintaan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERMINTAAN = new SelectList(db.apds, "ID", "NAMA_APD", permintaan.ID_PERMINTAAN);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", permintaan.ID_KARYAWAN);
            return View(permintaan);
        }

        // GET: Permintaan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permintaan permintaan = db.permintaans.Find(id);
            if (permintaan == null)
            {
                return HttpNotFound();
            }
            return View(permintaan);
        }

        // POST: Permintaan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            permintaan permintaan = db.permintaans.Find(id);
            db.permintaans.Remove(permintaan);
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
