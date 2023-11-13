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
    public class KaryawanController : Controller
    {
        private lifetime_apdEntities db = new lifetime_apdEntities();

        // GET: Karyawan
        public ActionResult Index()
        {
            var karyawans = db.karyawans.Include(k => k.unit).Include(k => k.user);
            return View(karyawans.ToList());
        }

        // GET: Karyawan/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karyawan karyawan = db.karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // GET: Karyawan/Create
        public ActionResult Create()
        {
            ViewBag.ID_UNIT = new SelectList(db.units, "ID", "NAMA_UNIT");
            ViewBag.ID_USERS = new SelectList(db.users, "ID", "NAMA");
            return View();
        }

        // POST: Karyawan/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_USERS,ID_UNIT,NIP,NAMA,JABATAN,JENIS_KELAMIN,TANGGAL_LAHIR,ALAMAT,STATUS_PENERIMAAN")] karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.karyawans.Add(karyawan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_UNIT = new SelectList(db.units, "ID", "NAMA_UNIT", karyawan.ID_UNIT);
            ViewBag.ID_USERS = new SelectList(db.users, "ID", "NAMA", karyawan.ID_USERS);
            return View(karyawan);
        }

        // GET: Karyawan/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karyawan karyawan = db.karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_UNIT = new SelectList(db.units, "ID", "NAMA_UNIT", karyawan.ID_UNIT);
            ViewBag.ID_USERS = new SelectList(db.users, "ID", "NAMA", karyawan.ID_USERS);
            return View(karyawan);
        }

        // POST: Karyawan/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_USERS,ID_UNIT,NIP,NAMA,JABATAN,JENIS_KELAMIN,TANGGAL_LAHIR,ALAMAT,STATUS_PENERIMAAN")] karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karyawan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_UNIT = new SelectList(db.units, "ID", "NAMA_UNIT", karyawan.ID_UNIT);
            ViewBag.ID_USERS = new SelectList(db.users, "ID", "NAMA", karyawan.ID_USERS);
            return View(karyawan);
        }

        // GET: Karyawan/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            karyawan karyawan = db.karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // POST: Karyawan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            karyawan karyawan = db.karyawans.Find(id);
            db.karyawans.Remove(karyawan);
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
