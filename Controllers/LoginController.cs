using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lifetime_apd.Models;

namespace lifetime_apd.Controllers
{
    public class LoginController : Controller
    {
        private readonly lifetime_apdEntities dbContext = new lifetime_apdEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user model)
        {
            if (ModelState.IsValid)
            {
                var user = dbContext.users.FirstOrDefault(u => u.USERNAME == model.USERNAME && u.PASSWORD == model.PASSWORD);

                if (user != null)
                {
                    // Jika username dan password sesuai, arahkan ke halaman lain
                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    // Jika login gagal, kembalikan ke halaman login dengan pesan error
                    ViewBag.ErrorMessage = "Login gagal. Silakan coba lagi.";
                }
            }

            // Jika model tidak valid atau login gagal, kembalikan ke halaman login dengan pesan error
            return View(model);
        }

        // Pastikan untuk melepas sumber daya DbContext setelah digunakan
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}