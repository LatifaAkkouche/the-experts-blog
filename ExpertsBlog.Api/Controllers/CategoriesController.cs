using ExpertsBlog.Entities;

namespace ExpertsBlog.Api.Controllers
{
    public class CategoriesController : ControllerBase<Category>
    {
        public CategoriesController(Repository<Category> repository) : base(repository)
        {
        }
    }
}
