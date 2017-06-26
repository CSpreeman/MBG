using MITM.Models;
using MITM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MITM.Controllers.ApiControllers
{
    [RoutePrefix("api/comment")]
    public class CommentsApiController : ApiController
    {
        [Route(""), HttpGet]
        public HttpResponseMessage getAllComments()
        {
            List<Comment> commentList = CommentService.GetAllComments();
            return Request.CreateResponse(HttpStatusCode.OK, commentList);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage getCommentsByBlogId(int id = 0)
        {
            List<Comment> commentList = CommentService.GetCommentByBlogId(id);
            return Request.CreateResponse(HttpStatusCode.OK, commentList);
        }

        [Route, HttpPost]
        public HttpResponseMessage postComment(Comment payload)
        {
            int Id = CommentService.PostComment(payload);
            return Request.CreateResponse(HttpStatusCode.OK, Id);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage deleteComment(int id = 0)
        {
            CommentService.deleteComment(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
