using Store_01.Models;

namespace Store_01.Reader
{
    public class BlogReader : IBlogReader
    {
        private readonly StoreContext store;
        public BlogReader(StoreContext store)
        {
            this.store = store; 
        }

        List<Blog> IBlogReader.GetBlogs()
        {
            return store.Blogs.Select(b=>b).ToList();
        }
    }
}
