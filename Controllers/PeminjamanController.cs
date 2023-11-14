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
    public class PeminjamanController : Controller
    {
        private lifetime_apdEntities db = new lifetime_apdEntities();

        // GET: Peminjaman
        public ActionResult Index()
        {
            var peminjamen = db.peminjamen.Include(p => p.apd).Include(p => p.karyawan);
            return View(peminjamen.ToList());
        }

        // GET: Peminjaman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peminjaman peminjaman = db.peminjamen.Find(id);
            if (peminjaman == null)
            {
                return HttpNotFound();
            }
            return View(peminjaman);
        }

        // GET: Peminjaman/Create
        public ActionResult Create()
        {
            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD");
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP");
            return View();
        }

        // POST: Peminjaman/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_KARYAWAN,ID_APD,TANGGAL_PINJAM,TANGGAL_KEMBALI,JUMLAH,STATUS_PEMINJAMAN")] peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                db.peminjamen.Add(peminjaman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD", peminjaman.ID_APD);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", peminjaman.ID_KARYAWAN);
            return View(peminjaman);
        }

        // GET: Peminjaman/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peminjaman peminjaman = db.peminjamen.Find(id);
            if (peminjaman == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD", peminjaman.ID_APD);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", peminjaman.ID_KARYAWAN);
            return View(peminjaman);
        }

        // POST: Peminjaman/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_KARYAWAN,ID_APD,TANGGAL_PINJAM,TANGGAL_KEMBALI,JUMLAH,STATUS_PEMINJAMAN")] peminjaman peminjaman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peminjaman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD", peminjaman.ID_APD);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", peminjaman.ID_KARYAWAN);
            return View(peminjaman);
        }

        // GET: Peminjaman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            peminjaman peminjaman = db.peminjamen.Find(id);
            if (peminjaman == null)
            {
                return HttpNotFound();
            }
            return View(peminjaman);
        }

        // POST: Peminjaman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            peminjaman peminjaman = db.peminjamen.Find(id);
            db.peminjamen.Remove(peminjaman);
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
