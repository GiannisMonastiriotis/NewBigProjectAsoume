using Microsoft.AspNet.Identity;
using NewBIGprojectASOUME.Dtos;
using NewBIGprojectASOUME.Models;
using System.Linq;
using System.Web.Http;

namespace NewBIGprojectASOUME.Controllers
{
    public class LikingsController : ApiController
    {
        private ApplicationDbContext _context;

        public LikingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Like(LikingDto dto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Likings.Any(l => l.LikesId == userId && l.LikeeId == dto.LikeeId))
                return BadRequest("You Like this allready.");

            var liking = new Liking
            {
                LikesId = userId,
                LikeeId = dto.LikeeId
            };
            _context.Likings.Add(liking);
            _context.SaveChanges();

            return Ok();
        }
    }
}