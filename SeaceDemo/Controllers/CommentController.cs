using SeaceDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeaceDemo.Controllers
{
    public class CommentController : ApiController
    {
        private SeaceDemoEntitiesModel seaceEntities = new SeaceDemoEntitiesModel();

        [HttpGet]
        [Route("api/comments")]
        public IHttpActionResult GetAllComments()
        {
            List<Comment> listComments = seaceEntities.Comments.ToList();    
             return Ok(listComments);
        }
        [HttpGet]
        [Route("api/comments/{id}")]
        public IHttpActionResult GetCommentByID(int id) {
            Comment comment = seaceEntities.Comments.SingleOrDefault(comments => comments.idComment == id);
            if (comment == null)
            {
                return NotFound();
            }
            
            return Ok(comment);
        }
        [HttpPost]
        [Route("api/comments")]
        public IHttpActionResult CreateNewComment(Comment comment) {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Add Failed"));
                }
                seaceEntities.Comments.Add(comment);
                seaceEntities.SaveChanges();
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Add Failed"));
            }
            return Ok(new Message(1, "Add Successfully"));
        }


        [HttpPost]
        [Route("api/update-comments")]
        public IHttpActionResult UpdateComment(Comment comment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Update Failed"));
                }

                Comment cmt = seaceEntities.Comments.SingleOrDefault(
                    p => p.idComment == comment.idComment && p.idPost == comment.idPost && p.idUser == comment.idUser
                );
                if (cmt == null)
                {
                    return Ok(new Message(0, "Update Failed"));
                }

                cmt.contentComment = comment.contentComment;
                seaceEntities.Comments.AddOrUpdate(cmt);
                seaceEntities.SaveChanges();
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Update Failed"));
            }
            return Ok(new Message(1, "Update Successfully"));
        }


        [HttpDelete]
        [Route("api/delete-comment/{id}")]
        public IHttpActionResult DeleteComment(int id)
        {

            if (!ModelState.IsValid)
            {
                return Ok(new Message(0,"Delete Failed"));
            }
            Comment cmt = seaceEntities.Comments.SingleOrDefault(cmts => cmts.idComment == id);
            if(cmt == null)
            {
                return Ok(new Message(0, "Delete Failed"));
            }
            seaceEntities.Comments.Remove(cmt);
            seaceEntities.SaveChanges();
            
            return Ok(new Message(1,"Delete Successfully"));
        }
    }
}
