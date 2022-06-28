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
        public readonly BandFormViewModel _viewModel;
        public readonly ApplicationDbContext _Context = new ApplicationDbContext();
        public HomeController()
        {
            _bandRepos = new BandsRepository();
            _viewModel = new BandFormViewModel();
        }
        public ActionResult Index()
        {
       
            var newBandsAdded = _bandRepos.GetLatestResultsByOneDay();

            //string genre;

            //if (TempData.ContainsKey("genre"))
            //    genre = TempData["genre"] as string;

            //TempData.Keep("genre");
    
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