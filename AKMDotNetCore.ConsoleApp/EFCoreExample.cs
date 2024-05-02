using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AKMDotNetCore.ConsoleApp;

internal class EFCoreExample
{

    private readonly AppDbContext db = new AppDbContext();
    public void Run()
    {
        //Read();
        //Edit(13);
        //Create("Post Title", "Post Author", "Post Content");
        //Update(13, "hello", "Mingalapar", "Bonjour");
        Delete(13);

    }

    private void Read()
    {
        var blogs = db.Blogs.ToList();
        foreach (BlogDto blog in blogs)
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
        var blog = db.Blogs.FirstOrDefault(x => x.BlogId == id);
        if(blog is null)
        {
            Console.WriteLine("Data not found");
            return;
        }

        Console.WriteLine(blog.BlogId);
        Console.WriteLine(blog.BlogTitle);
        Console.WriteLine(blog.BlogArthur);
        Console.WriteLine(blog.BlogContent);
        Console.WriteLine("-----------------------");
        Console.WriteLine("");
    }

    private void Create(string title, string author, string content)
    {
        var item = new BlogDto()
        {
            BlogTitle = title,
            BlogArthur = author,
            BlogContent = content
        };

        db.Blogs.Add(item);
        int result = db.SaveChanges();


        Console.WriteLine(result > 0 ? "Created successfully" : "creation failed");
    }

    private void Update(int id, string title, string author, string content)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);

        if (item is null)
        {
            Console.WriteLine("Data not found");
            return;
        }

        item.BlogTitle = title;
        item.BlogArthur = author;
        item.BlogContent = content;

        int result = db.SaveChanges();


        Console.WriteLine(result > 0 ? "Updated successfully" : "creation failed");
    }

    private void Delete(int id)
    {
        var item = db.Blogs.FirstOrDefault(x => x.BlogId ==id );

        if (item is null)
        {
            Console.WriteLine("Data not found");
            return;
        }

        db.Blogs.Remove(item);
        int result = db.SaveChanges();

        Console.WriteLine(result > 0 ? "Deleted successfully" : "creation failed");

    }

}
