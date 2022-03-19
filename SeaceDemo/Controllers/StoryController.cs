using SeaceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeaceDemo.Controllers
{
    public class StoryController : ApiController
    {
        private SeaceDemoEntitiesModel seaceEntities = new SeaceDemoEntitiesModel();

        [HttpGet]
        [Route("api/stories")]
        public IHttpActionResult GetAllStory()
        {
            List<Story> listUsers = seaceEntities.Stories.ToList();    
             return Ok(listUsers);
        }
        [HttpGet]
        [Route("api/stories/{id}")]
        public IHttpActionResult GetUserByID(int id) {
            Story story = seaceEntities.Stories.SingleOrDefault(stories => stories.idStory == id);
            if (story == null)
            {
                return NotFound();
            }
            
            return Ok(story);
        }
        [HttpPost]
        [Route("api/stories")]
        public IHttpActionResult CreateNewUser(Story stories) {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Add Failed"));
                }
                seaceEntities.Stories.Add(stories);
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
