using MITM.Models;
using MITM.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MITM.Controllers.ApiControllers
{
    [RoutePrefix("api/blog")]
    public class BlogApiController : ApiController
    {
        [Route, HttpGet]
        public HttpResponseMessage GetBlogs()
        {
            List<Blog> BlogList = BlogService.GetBlogs();
            return Request.CreateResponse(HttpStatusCode.OK, BlogList);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetBlogById(int id)
        {
            Blog Blog = BlogService.GetBlogById(id);
            return Request.CreateResponse(HttpStatusCode.OK, Blog);
        }

    }
}
