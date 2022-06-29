using Microsoft.AspNet.Identity;
using NewBIGprojectASOUME.Dtos;
using NewBIGprojectASOUME.Models;
using System.Linq;
using System.Web.Http;

namespace NewBIGprojectASOUME.Controllers.Api
{
    //[Authorize]
    public class LikesController : ApiController
    {
        private readonly ApplicationDbContext _Context;

        public LikesController()
        {
            _Context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Like(LikeDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_Context.Likes.Any(a => a.LikedId == userId && a.BandId == dto.BandId))
                return BadRequest("The like allready exists");

            var like = new Like()
            {
                BandId = dto.BandId,
                LikedId = User.Identity.GetUserId()
            };
            _Context.Likes.Add(like);
            _Context.SaveChanges();

            return Ok();
        }
    }
}