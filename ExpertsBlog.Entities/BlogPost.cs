using System.Collections.Generic;

namespace ExpertsBlog.Entities
{
    public class BlogPost : EntityBase
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public HashSet<Tag> Tags { get; } = new();
    }
}