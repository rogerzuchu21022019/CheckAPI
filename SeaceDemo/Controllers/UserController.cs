using SeaceDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeaceDemo.Controllers
{
    public class UserController : ApiController
    {
        private SeaceDemoEntitiesModel seaceEntities = new SeaceDemoEntitiesModel();

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetAllUser()
        {
            List<User> listUsers = seaceEntities.Users.ToList();    
             return Ok(listUsers);
        }
        [HttpGet]
        [Route("api/users/{id}")]
        public IHttpActionResult GetUserByID(string id) {
            User user = seaceEntities.Users.SingleOrDefault(users => users.idUser == id);
            if (user==null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }
        [HttpPost]
        [Route("api/users")]
        public IHttpActionResult CreateNewUser(User user) {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Add Failed"));
                }
                seaceEntities.Users.Add(user);
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
