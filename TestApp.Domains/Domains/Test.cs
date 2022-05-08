using System.Collections.Generic;

namespace TestApp.Domains.Domains
{
    public class Test : BaseEntity
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
