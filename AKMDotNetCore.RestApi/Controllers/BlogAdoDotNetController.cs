using AKMDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AKMDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogAdoDotNetController : ControllerBase
{
    [HttpGet]

    public IActionResult GetBlogs()
    {
        string query = "Select * from Tbl_Blogs";

        SqlConnection connection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(query, connection);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
        DataTable dt = new DataTable();
        dataAdapter.Fill(dt);

        connection.Close();


        List<BlogModel> list = dt.AsEnumerable().Select(dr => new BlogModel()
        {
            BlogId = Convert.ToInt32(dr["BlogId"]),
            BlogTitle = Convert.ToString(dr["BlogTitle"]),
            BlogArthur = Convert.ToString(dr["BlogArthur"]),
            BlogContent = Convert.ToString(dr["BlogContent"])


        }).ToList();

        return Ok(list);
    }

    [HttpGet("{id}")]

    public IActionResult GetBlog(int id)
    {
        var item = FindById(id);

        if (item is null)
        {
            return NotFound("Data Not Found");
        }

        return Ok(item);

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

        SqlConnection connection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogArthur", blog.BlogArthur);
        cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
        var result = cmd.ExecuteNonQuery();

        connection.Close();

        return Ok(result > 0 ? "Successfully Created" : "Creation Fail");
    }

    [HttpPut("{id}")]

    public IActionResult PutBlog(int id, BlogModel blog)
    {
        var item = FindById(id);

        if (item is null)
        {
            return NotFound("NO DATA FOUND");
        }

        string query = @"UPDATE [dbo].[Tbl_Blogs]
         SET [BlogTitle] = @BlogTitle
        ,[BlogArthur] = @BlogAuthor
        ,[BlogContent] = @BlogContent
         WHERE BlogID = @BlogID";

        SqlConnection connection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogID", id);
        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
        cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogArthur);
        cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
        var result = cmd.ExecuteNonQuery();

        connection.Close();

        return Ok(result > 0 ? "Successfully Updated" : "Update Fail");

    }

    [HttpPatch("{id}")]

    public IActionResult PatchBlog(int id, BlogModel blog)
    {
        var item = FindById(id);

        if (item is null)
        {
            return NotFound("NO DATA FOUND");
        }

        string condition = string.Empty;

        if (!string.IsNullOrEmpty(blog.BlogTitle))
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

        condition = condition.Substring(0, condition.Length - 2);

        string query = $"UPDATE [dbo].[Tbl_Blogs] SET {condition} WHERE BlogID = @BlogID";

        SqlConnection connection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogID", id);

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
           cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);

        }

        if (!string.IsNullOrEmpty(blog.BlogArthur))
        {
         cmd.Parameters.AddWithValue("@BlogArthur", blog.BlogArthur);

       }

       if (!string.IsNullOrEmpty(blog.BlogContent))
       {
           cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
      }
        
        var result = cmd.ExecuteNonQuery();

        connection.Close();

        return Ok(result > 0 ? "Successfully Updated" : "Update Fail");

    }

    [HttpDelete("{id}")]

    public IActionResult DeleteBlog(int id)
    {
        var item = FindById(id);

        if(item is null)
        {
            return NotFound("DATA NOT FOUND");
        }

        string query = @"DELETE FROM [dbo].[Tbl_Blogs]
                       WHERE BlogID = @BlogID";

        SqlConnection connection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogID", id);
        var result = cmd.ExecuteNonQuery();

        connection.Close();

        return Ok(result > 0 ? "Delete Successfully" : "fail delete");

    }


    private BlogModel? FindById(int id)
    {
        string query = "Select * from Tbl_Blogs Where BlogId = @BlogID";

        SqlConnection connection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@BlogID", id);
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        dataAdapter.Fill(dt);

        connection.Close();

        if(dt.Rows.Count == 0)
        {
            return null;
        }

        DataRow dr = dt.Rows[0];

        BlogModel blog = new BlogModel()
        {
            BlogId = Convert.ToInt32(dr["BlogId"]),
            BlogTitle = Convert.ToString(dr["BlogTitle"]),
            BlogArthur = Convert.ToString(dr["BlogArthur"]),
            BlogContent = Convert.ToString(dr["BlogContent"])
        };

        return blog;
    }
}
