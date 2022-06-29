using NewBIGprojectASOUME.Models;
using NewBIGprojectASOUME.Repository;
using NewBIGprojectASOUME.Viewmodels;
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
            // var newBandsAdded = _bandRepos.GetLatestResultsByOneDay();
            //  var artists = _Context.Artists;
            var featuredBands = _bandRepos.GetLatestResultsByOneDay();

            var viewModel = new BandViewModel()
            {
                FeauturedBands = featuredBands,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Recent Albums"
            };

            return View("Bands",viewModel);
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