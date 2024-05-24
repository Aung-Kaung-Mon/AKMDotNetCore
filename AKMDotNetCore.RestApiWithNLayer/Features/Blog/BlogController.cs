using AKMDotNetCore.RestApiWithNLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AKMDotNetCore.RestApiWithNLayer.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly BL_Blog _blBlog;

        public BlogController()
        {
            _blBlog = new BL_Blog();
        }

        [HttpGet]

        public IActionResult Read()
        {
            var list = _blBlog.GetBlogs();
            return Ok(list);
        }

        [HttpGet("{id}")]

        public IActionResult Edit(int id)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null) return NotFound("data not found");

            return Ok(item);
        }

        [HttpPost]

        public IActionResult Create(BlogModel requestModel)
        {
            var result = _blBlog.Create(requestModel);
            return Ok(result > 0 ? "Create Successfully" : "Fail");
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id , BlogModel requestModel)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null) return NotFound("data not found");

            var result = _blBlog.Put(id, requestModel);
            return Ok(result > 0 ? "Updated Successfully" : "Fail");
        }

        [HttpPatch("{id}")]

        public IActionResult Patch(int id, BlogModel requestModel)
        {
            var item = _blBlog.GetBlog(id);
            if (item is null) return NotFound("data not found");

            var result = _blBlog.Patch(id, requestModel);
            return Ok(result > 0 ? "Updated Successfully" : "Fail");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _blBlog.Delete(id);
            return Ok(result > 0 ? "Delete Successfully" : "Fail");
        }

    }
}
