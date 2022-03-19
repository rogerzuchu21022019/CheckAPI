using SeaceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeaceDemo.Controllers
{
    public class LikeController : ApiController
    {
        private SeaceDemoEntitiesModel seaceEntities = new SeaceDemoEntitiesModel();

        [HttpGet]
        [Route("api/likes")]
        public IHttpActionResult GetAllLikes()
        {
            List<Like> listLikes = seaceEntities.Likes.ToList();    
             return Ok(listLikes);
        }
        [HttpGet]
        [Route("api/likes/{id}")]
        public IHttpActionResult GetLikeByID(int id) {
            Like like = seaceEntities.Likes.SingleOrDefault(likes => likes.idLike == id);
            if (like == null)
            {
                return NotFound();
            }
            
            return Ok(like);
        }

        [HttpPost]
        [Route("api/likes")]
        public IHttpActionResult CreateNewLike(Like like) {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Add Failed"));
                }
                seaceEntities.Likes.Add(like);
                seaceEntities.SaveChanges();
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Add Failed"));
            }
            return Ok(new Message(0, "Add Successfully"));
        }
    }
}
