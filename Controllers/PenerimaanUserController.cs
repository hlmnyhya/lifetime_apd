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
    public class PenerimaanUserController : Controller
    {
        private lifetime_apdEntities db = new lifetime_apdEntities();

        // GET: PenerimaanUser
        public ActionResult Index()
        {
            var penerimaans = db.penerimaans.Include(p => p.apd).Include(p => p.karyawan);
            return View(penerimaans.ToList());
        }

        // GET: PenerimaanUser/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            penerimaan penerimaan = db.penerimaans.Find(id);
            if (penerimaan == null)
            {
                return HttpNotFound();
            }
            return View(penerimaan);
        }

        // GET: PenerimaanUser/Create
        public ActionResult Create()
        {
            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD");
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP");
            return View();
        }

        // POST: PenerimaanUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_APD,ID_KARYAWAN,TANGGAL_PENERIMAAN,TOTAL_PENERIMAAN")] penerimaan penerimaan)
        {
            if (ModelState.IsValid)
            {
                db.penerimaans.Add(penerimaan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD", penerimaan.ID_APD);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", penerimaan.ID_KARYAWAN);
            return View(penerimaan);
        }

        // GET: PenerimaanUser/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            penerimaan penerimaan = db.penerimaans.Find(id);
            if (penerimaan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD", penerimaan.ID_APD);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", penerimaan.ID_KARYAWAN);
            return View(penerimaan);
        }

        // POST: PenerimaanUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_APD,ID_KARYAWAN,TANGGAL_PENERIMAAN,TOTAL_PENERIMAAN")] penerimaan penerimaan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(penerimaan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_APD = new SelectList(db.apds, "ID", "NAMA_APD", penerimaan.ID_APD);
            ViewBag.ID_KARYAWAN = new SelectList(db.karyawans, "ID", "NIP", penerimaan.ID_KARYAWAN);
            return View(penerimaan);
        }

        // GET: PenerimaanUser/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            penerimaan penerimaan = db.penerimaans.Find(id);
            if (penerimaan == null)
            {
                return HttpNotFound();
            }
            return View(penerimaan);
        }

        // POST: PenerimaanUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            penerimaan penerimaan = db.penerimaans.Find(id);
            db.penerimaans.Remove(penerimaan);
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
