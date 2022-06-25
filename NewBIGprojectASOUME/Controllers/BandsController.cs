using NewBIGprojectASOUME.Models;
using NewBIGprojectASOUME.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewBIGprojectASOUME.Controllers
{
    public class BandsController : Controller
    {
        BandsRepository _BandRepos;
        ApplicationDbContext _db = new ApplicationDbContext();
        
        public BandsController()
        {
            _BandRepos = new BandsRepository();
        }
        // GET: Bands
        public ActionResult Create()
        {
            var GigFormViewModel = new BandFormViewModel()
            {
                Genres = _db.Genres.ToList()
            };
            return View(GigFormViewModel);
        }
    }
}