using AKMDotNetCore.RestApiWithNLayer.Models;

namespace AKMDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _daBlog;

        public BL_Blog()
        {
            _daBlog = new DA_Blog();
        }

        public List<BlogModel> GetBlogs()
        {
            var list = _daBlog.GetBlogs();
            return list;
        }

        public BlogModel GetBlog(int id)
        {
            var item = _daBlog.GetBlog(id);
            return item;
        }

        public int Create(BlogModel requestModel)
        {
            var result = _daBlog.Create(requestModel);
            return result;
        }

        public int Put(int id , BlogModel requestModel)
        {
            var result = _daBlog.Put(id, requestModel);
            return result;
        }

        public int Patch(int id, BlogModel requestModel)
        {
            var result = _daBlog.Patch(id, requestModel);
            return result;
        }

        public int Delete(int id)
        {
            var result = _daBlog.Delete(id);
            return result;
        }

    }
}
