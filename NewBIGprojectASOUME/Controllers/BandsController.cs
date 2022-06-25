using Microsoft.AspNet.Identity;
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
        ApplicationDbContext _db;
        
        public BandsController()
        {
            _BandRepos = new BandsRepository();
            _db = new ApplicationDbContext();
        }
        // GET: Bands
        [Authorize]
        public ActionResult Create()
        {
            var GigFormViewModel = new BandFormViewModel()
            {    Artists = _db.Artists.ToList(),
                Genres = _db.Genres.ToList(),
                Bands = _db.Bands.ToList()
            };
            return View(GigFormViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(BandFormViewModel bandFormViewModel)
        {
            if (!ModelState.IsValid)

            {

                bandFormViewModel.Genres = _db.Genres.ToList();
                bandFormViewModel.Artists = _db.Artists.ToList();
                bandFormViewModel.Bands = _db.Bands.ToList();
                return View("Create", bandFormViewModel);
            }
              

            var artist = _db.Artists.Single(g => g.Id == bandFormViewModel.Artist);

            var band = new Band
            {   
                DateCreated = bandFormViewModel.DateTimeCreated,
                UserID = User.Identity.GetUserId(),
                GenreId = bandFormViewModel.Genre,
                Name = bandFormViewModel.Name
            };

            _db.Bands.Add(band);

            var bandArtist = new ArtistsBandsConnection()
            {
                ArtistId = artist.Id,
                BandId = band.Id
            };
            _db.ArtistsBandsConnections.Add(bandArtist);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}