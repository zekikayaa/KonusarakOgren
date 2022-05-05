﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domains.Domains
{
    internal class Test : BaseEntity
    {
        public int PostId { get; set; }

        public Post Post { get; set; }

        public ICollection<Question> Questions { get; set; }

    }
}
