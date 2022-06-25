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
            var userId = User.Identity.GetUserId();
            var user = _db.Users.Single(u => u.Id == userId);

            var genre = _db.Genres.Single(g => g.Id == bandFormViewModel.Genre);

            var artist = _db.Artists.Single(g => g.Id == bandFormViewModel.Artist);

            var band = new Band
            {

                User = user,
                Genre = genre,
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