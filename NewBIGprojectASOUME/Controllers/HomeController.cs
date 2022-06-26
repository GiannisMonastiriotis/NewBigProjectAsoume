using NewBIGprojectASOUME.Models;
using NewBIGprojectASOUME.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBIGprojectASOUME.Controllers
{
    public class HomeController : Controller
    {
        public readonly BandsRepository _bandRepos;

        public HomeController()
        {
            _bandRepos = new BandsRepository();
        }
        public ActionResult Index()
        {
           // var band = new Band();
           // ViewBag.DateProvided = band.DateTimeProvided;
            var newBandsAdded = _bandRepos.GetLatestResultsByTenMinutes();
            return View(newBandsAdded);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bandRepos.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}