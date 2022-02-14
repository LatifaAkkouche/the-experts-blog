using ExpertsBlog.Entities;

namespace ExpertsBlog.Api.Controllers
{
    public class TagsController : ControllerBase<Tag>
    {
        public TagsController(Repository<Tag> repository) : base(repository)
        {
        }
    }
}
