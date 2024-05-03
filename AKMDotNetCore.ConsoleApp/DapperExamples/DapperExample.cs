using AKMDotNetCore.ConsoleApp.Dtos;
using AKMDotNetCore.ConsoleApp.Services;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.ConsoleApp.DapperExamples;

internal class DapperExample
{
    public void Run()
    {

        // Edit(13);
        //Create("hello", "hi", "content");
        //Update(16, "updatedHello", "hi", "UpdatedContent");
        Delete(16);
    }

    private void Read()
    {
        using IDbConnection dbConnection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        List<BlogDto> list = dbConnection.Query<BlogDto>("select * from Tbl_Blogs").ToList();

        foreach (BlogDto blog in list)
        {
            Console.WriteLine(blog.BlogId);
            Console.WriteLine(blog.BlogTitle);
            Console.WriteLine(blog.BlogArthur);
            Console.WriteLine(blog.BlogContent);
            Console.WriteLine("-----------------------");
            Console.WriteLine("");

        }
    }

    private void Edit(int id)
    {
        using IDbConnection dbConnection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        var blog = dbConnection.Query<BlogDto>("select * from Tbl_Blogs where BlogId = @BlogId", new BlogDto() { BlogId = id }).FirstOrDefault();

        if (blog is null)
        {
            Console.WriteLine("Data not found");
        };

        Console.WriteLine(blog.BlogId);
        Console.WriteLine(blog.BlogTitle);
        Console.WriteLine(blog.BlogArthur);
        Console.WriteLine(blog.BlogContent);
    }

    private void Create(string title, string author, string content)
    {

        string query = @"INSERT INTO [dbo].[Tbl_Blogs]
           ([BlogTitle]
           ,[BlogArthur]
           ,[BlogContent])
        VALUES
           (@BlogTitle, @BlogArthur, @BlogContent)";

        var param = new BlogDto()
        {
            BlogTitle = title,
            BlogArthur = author,
            BlogContent = content
        };


        using IDbConnection dbConnection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        int result = dbConnection.Execute(query, param);

        Console.WriteLine(result > 0 ? "Created successfully" : "creation failed");
    }

    private void Update(int id, string title, string author, string content)
    {

        string query = @"UPDATE [dbo].[Tbl_Blogs]
    SET [BlogTitle] = @BlogTitle
      ,[BlogArthur] = @BlogArthur
      ,[BlogContent] = @BlogContent
    WHERE BlogID = @BlogId";

        var param = new BlogDto()
        {
            BlogId = id,
            BlogTitle = title,
            BlogArthur = author,
            BlogContent = content
        };


        using IDbConnection dbconnection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        int result = dbconnection.Execute(query, param);

        Console.WriteLine(result > 0 ? "Updated successfully" : "creation failed");

    }

    private void Delete(int id)
    {
        string query = "delete from Tbl_Blogs where BlogID = @BlogId";
        var param = new BlogDto()
        {
            BlogId = id
        };

        using IDbConnection dbConnection = new SqlConnection(ConnectionStrings.stringBuilder.ConnectionString);
        int result = dbConnection.Execute(query, param);

        Console.WriteLine(result > 0 ? "Deleted successfully" : "creation failed");

    }
}
