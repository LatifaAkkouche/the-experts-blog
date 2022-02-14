using ExpertsBlog.Entities;

namespace ExpertsBlog.Api.Controllers
{
    public class BlogPostsController : ControllerBase<BlogPost>
    {
        public BlogPostsController(Repository<BlogPost> repository) : base(repository)
        {
        }
    }
}