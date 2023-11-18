using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lifetime_apd;
using lifetime_apd.Models;

namespace lifetime_apd.Controllers
{
    public class HomeController : Controller
    {
        private lifetime_apdEntities db = new lifetime_apdEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            // Create an instance of the DashboardModels
            var viewModel = new DashboardModels();

            // Get the count of records from the database
            viewModel.PeminjamanCount = viewModel.GetPeminjamanCount();
            viewModel.PenerimaanCount = viewModel.GetPenerimaanCount();
            viewModel.PermintaanCount = viewModel.GetPermintaanCount();
            viewModel.PengadaanCount = viewModel.GetPengadaanCount();

            // Pass the viewModel to the view
            return View(viewModel);
        }


        public ActionResult DashboardUsers()
        {
            // Create an instance of the DashboardModels
            var viewModel = new DashboardModels();

            // Get the count of records from the database
            viewModel.PeminjamanCount = viewModel.GetPeminjamanCount();
            viewModel.PenerimaanCount = viewModel.GetPenerimaanCount();
            viewModel.PermintaanCount = viewModel.GetPermintaanCount();
            viewModel.PengadaanCount = viewModel.GetPengadaanCount();

            // Pass the viewModel to the view
            return View(viewModel);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}