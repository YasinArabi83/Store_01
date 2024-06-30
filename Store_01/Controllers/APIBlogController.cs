using Microsoft.AspNetCore.Mvc;
using Store_01.Reader;

namespace Store_01.Controllers
{
    public class APIBlogController : ControllerBase
    {
        private readonly IBlogReader blogReader;
        public APIBlogController(IBlogReader blogReader)
        {
            this.blogReader = blogReader;
        }
        [HttpGet]
        public IActionResult GetBlog()
        {
            return Ok(blogReader.GetBlogs());
        }
    }
}
