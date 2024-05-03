using AKMDotNetCore.RestApi.DBs;
using AKMDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AKMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly AppDbContext _context;

        public BlogController()
        {
            _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var list = _context.Blogs.ToList();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);

            if(item is null)

            {
                return NotFound("data not found");
            }

            return Ok(item);
        }



        [HttpPost]
        public IActionResult Create(BlogModel blog)
        {
            _context.Blogs.Add(blog);
            var result =_context.SaveChanges();

            return Ok(result > 0 ? "Created Successfully" : "Fail");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, BlogModel blog)
        {
           var item = _context.Blogs.FirstOrDefault(x => x.BlogId ==id);
            if(item is null)
            {
                return NotFound("data not found");
            }

            item.BlogTitle = blog.BlogTitle;
            item.BlogArthur = blog.BlogArthur;
            item.BlogContent = blog.BlogContent;
            var result = _context.SaveChanges();

            return Ok(result > 0 ? "Updated Successfully" : "Fail");

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var item = _context.Blogs.FirstOrDefault(y => y.BlogId == id);
            if (item is null)
            {
                return NotFound("data not found");
            }

            if(!string.IsNullOrEmpty(blog.BlogTitle)){
                item.BlogTitle = blog.BlogTitle;
            }

            if (!string.IsNullOrEmpty(blog.BlogArthur))
            {
                item.BlogArthur = blog.BlogArthur;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                item.BlogContent = blog.BlogContent;
            }

            var result = _context.SaveChanges();
            return Ok(result > 0 ? "Updated Successfully" : "Fail");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var blog = _context.Blogs.FirstOrDefault(z => z.BlogId == id);

            if (blog is null)
            {
                return NotFound("data not found");
            }

            _context.Blogs.Remove(blog);
            var result = _context.SaveChanges();

            return Ok(result > 0 ? "Deleted Successfully" : "Fail");
        }
    }
}
