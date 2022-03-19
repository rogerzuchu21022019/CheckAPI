using SeaceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeaceDemo.Controllers
{
    public class PostController : ApiController
    {
        private SeaceDemoEntitiesModel seaceEntities = new SeaceDemoEntitiesModel();

        [HttpGet]
        [Route("api/posts")]
        public IHttpActionResult GetAllPost()
        {
            List<Post> listPosts = seaceEntities.Posts.ToList();    
             return Ok(listPosts);
        }
        [HttpGet]
        [Route("api/posts/{id}")]
        public IHttpActionResult GetPostByID(int id) {
            Post post = seaceEntities.Posts.SingleOrDefault(posts => posts.idPost == id);
            if (post==null)
            {
                return NotFound();
            }
            
            return Ok(post);
        }
        [HttpPost]
        [Route("api/posts")]
        public IHttpActionResult CreateNewPost(Post post) {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Add Failed"));
                }
                seaceEntities.Posts.Add(post);
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
