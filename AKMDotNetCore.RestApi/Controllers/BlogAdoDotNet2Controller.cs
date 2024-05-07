using AKMDotNetCore.RestApi.Models;
using AKMDotNetCore.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AKMDotNetCore.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogAdoDotNet2Controller : ControllerBase
{

    private readonly AdoDotNetService _service = new AdoDotNetService(ConnectionStrings.stringBuilder.ConnectionString);

    [HttpGet]

    public IActionResult GetBlogs()
    {
        string query = "Select * from Tbl_Blogs";

        List<BlogModel> list = _service.Query<BlogModel>(query);

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

       
        List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
        parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle!));
        parameters.Add(new AdoDotNetParameter("@BlogArthur", blog.BlogArthur!));
        parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent!));

        var result = _service.Execute(query , parameters);

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
        ,[BlogArthur] = @BlogArthur
        ,[BlogContent] = @BlogContent
         WHERE BlogID = @BlogID";

        List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
        parameters.Add(new AdoDotNetParameter("@BlogID", id));
        parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle!));
        parameters.Add(new AdoDotNetParameter("@BlogArthur", blog.BlogArthur!));
        parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent!));

        var result = _service.Execute(query, parameters);

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

        List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
        parameters.Add(new AdoDotNetParameter("@BlogID", id));

        if (!string.IsNullOrEmpty(blog.BlogTitle))
        {
            condition += "[BlogTitle] = @BlogTitle, ";
            parameters.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle!));
        }

        if (!string.IsNullOrEmpty(blog.BlogArthur))
        {
            condition += "[BlogArthur] = @BlogArthur, ";
            parameters.Add(new AdoDotNetParameter("@BlogArthur", blog.BlogArthur!));
        }

        if (!string.IsNullOrEmpty(blog.BlogContent))
        {
            condition += "[BlogContent] = @BlogContent, ";
            parameters.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent!));
        }

        condition = condition.Substring(0, condition.Length - 2);

        string query = $"UPDATE [dbo].[Tbl_Blogs] SET {condition} WHERE BlogID = @BlogID";

      
        var result = _service.Execute(query , parameters);
    
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

        List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
        parameters.Add(new AdoDotNetParameter("@BlogID", id));

        var result = _service.Execute(query, parameters);

        return Ok(result > 0 ? "Delete Successfully" : "fail delete");

    }


    private BlogModel? FindById(int id)
    {
        string query = "Select * from Tbl_Blogs Where BlogId = @BlogID";

        List<AdoDotNetParameter> parameters = new List<AdoDotNetParameter>();
        parameters.Add(new AdoDotNetParameter("BlogID", id));

        var blog = _service.QueryFirstOrDefault<BlogModel>(query , parameters);

        return blog;
    }
}
