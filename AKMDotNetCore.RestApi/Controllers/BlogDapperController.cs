using AKMDotNetCore.RestApi.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AKMDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogDapperController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = "select * from Tbl_Blogs";

            using IDbConnection db = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
            List<BlogModel> list = db.Query<BlogModel>(query).ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]

        public IActionResult GetBlog(int id)
        {
           var blog = FindBlog(id);

            if (blog is null)
            {
                return NotFound("Data Not Found");
            }

            return Ok(blog);
                
         }

        [HttpPost]

        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blogs]
           ([BlogTitle]
           ,[BlogArthur]
           ,[BlogContent])
        VALUES
           (@BlogTitle, @BlogArthur, @BlogContent)";

            using IDbConnection db = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
            var result = db.Execute(query, blog);

            return Ok(result > 0 ? "Created successfully" : "Creation failed");

        }

        [HttpPut("{id}")]

        public IActionResult PutBlog(int id, BlogModel blog)
        {
            var item = FindBlog(id);
            if(item is null)
            {
                return NotFound("Data Not Found");
            }

            string query = @"UPDATE [dbo].[Tbl_Blogs]
    SET [BlogTitle] = @BlogTitle
      ,[BlogArthur] = @BlogArthur
      ,[BlogContent] = @BlogContent
    WHERE BlogID = @BlogId";

            blog.BlogId = id;
            using IDbConnection db = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
            var result = db.Execute(query, blog);

            return Ok(result > 0 ? "Updated successfully" : "Update failed");


        }

        [HttpPatch("{id}")]

        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            var item = FindBlog(id);
            if(item is null)
            {
                return NotFound("Data Not Found");
            }

            string condition = string.Empty;

            if(!string.IsNullOrEmpty(blog.BlogTitle))
            {
                condition += "[BlogTitle] = @BlogTitle, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogArthur))
            {
                condition += "[BlogArthur] = @BlogArthur, ";
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                condition += "[BlogContent] = @BlogContent, ";
            }

            condition = condition.Substring(0 , condition.Length - 2);

            string query = $"UPDATE [dbo].[Tbl_Blogs] SET {condition} WHERE BlogID = @BlogId";

        
            blog.BlogId = id;
            using IDbConnection db = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
            var result = db.Execute(query, blog);

            return Ok(result > 0 ? "Update Successfully" : "Update Fail");
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteBlog(int id)
        {
            var item = FindBlog(id);
            if (item is null)
            {
                return NotFound("Not Found The Data");
            }

            string query = "delete from Tbl_Blogs where BlogID = @BlogId";
            var param = new BlogModel()
            {
                BlogId = id
            };

            using IDbConnection db = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
            var result = db.Execute(query, param);

            return Ok(result > 0 ? "Delete Successfully" : "Delete Fail");
        }

        private BlogModel? FindBlog(int id)
        {
            string query = "select * from Tbl_Blogs where BlogId = @BlogId";

            using IDbConnection db = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query, new BlogModel() { BlogId = id }).FirstOrDefault();

            return item;
        }

    }
}
