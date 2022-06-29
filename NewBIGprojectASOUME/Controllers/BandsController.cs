using Microsoft.AspNet.Identity;
using NewBIGprojectASOUME.Models;
using NewBIGprojectASOUME.Viewmodels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace NewBIGprojectASOUME.Controllers
{
    public class BandsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BandsController()
        {
            _db = new ApplicationDbContext();
        }

        // GET: Bands
        [Authorize]
        public ActionResult Create()
        {
            var GigFormViewModel = new BandFormViewModel()
            {
                Artists = _db.Artists.ToList(),
                Genres = _db.Genres.ToList(),
                Bands = _db.Bands.ToList()
            };
            return View(GigFormViewModel);
        }

        [Authorize]
        public ActionResult Liking()
        {
            var userId = User.Identity.GetUserId();
            var bands = _db.Likes
                .Where(a => a.LikedId == userId)
                .Select(a => a.Band)
                .Include(g => g.User)
                .Include(g => g.Genre)
                .ToList();

            var viewmodel = new BandViewModel()
            {
                FeauturedBands = bands,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Bands I am Following"

            };

            return View("Bands",viewmodel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            var genre = _db.Genres.Single(g => g.Id == bandFormViewModel.Genre);

            var band = new Band
            {
                Genre = genre,
                DateCreated = bandFormViewModel.DateTimeCreated,
                UserID = User.Identity.GetUserId(),
                Name = bandFormViewModel.Name
            };

            _db.Bands.Add(band);
            _db.SaveChanges();

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