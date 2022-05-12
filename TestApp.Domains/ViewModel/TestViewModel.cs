using System;
using System.Collections.Generic;

namespace TestApp.Domains.ViewModel
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public DateTime CreatedDate { get; set; }

        public List<QuestionTestViewModel> Questions { get; set; }


    }
}
