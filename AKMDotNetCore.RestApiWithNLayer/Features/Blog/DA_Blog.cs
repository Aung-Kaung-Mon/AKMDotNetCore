using AKMDotNetCore.RestApiWithNLayer.DBs;
using AKMDotNetCore.RestApiWithNLayer.Models;

namespace AKMDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;

        public DA_Blog()
        {
            _context = new AppDbContext();
        }

        public List<BlogModel> GetBlogs()
        {
            var list = _context.Blogs.ToList();
            return list;
        }

        public BlogModel? GetBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if(item is null) return null;

            return item;
        }

        public int Create(BlogModel requestModel)
        {
            _context.Blogs.Add(requestModel);

            var result = _context.SaveChanges();

            return result;
        }

        public int Put(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogArthur = requestModel.BlogArthur;
            item.BlogContent = requestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;
        }

        public int Patch(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            if(!String.IsNullOrEmpty(requestModel.BlogTitle)) item.BlogTitle = requestModel.BlogTitle;

            if(!String.IsNullOrEmpty(requestModel.BlogArthur)) item.BlogArthur= requestModel.BlogArthur;

            if(!String.IsNullOrEmpty(requestModel.BlogContent)) item.BlogContent = requestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;

        }

        public int Delete(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
