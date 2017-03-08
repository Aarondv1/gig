using Gigelicious.Dto;
using Gigelicious.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace Gigelicious.Controllers.Api
{
    public class FollowController : ApiController
    {

        private ApplicationDbContext _context;

        public FollowController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Follow(FollowDto dto)
        {
            var _followerid = User.Identity.GetUserId();

            if(_context.Follows.Any(a=>a.FollowerId == _followerid && a.FolloweeId == dto.ArtistId ))
                return BadRequest("This particular 'Follow' is already in the Database");


            var follow = new Follow()
            {
                FollowerId = _followerid,
                FolloweeId = dto.ArtistId

            };

            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();

        }
    }
}
