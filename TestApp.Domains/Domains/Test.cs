using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Domains.Domains
{
    public class Test : BaseEntity
    {

        [ForeignKey("Post")]
        public int PostId { get; set; }

        public Post Post { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
