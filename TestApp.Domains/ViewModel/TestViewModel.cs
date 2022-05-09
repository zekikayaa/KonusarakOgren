using System.Collections.Generic;

namespace TestApp.Domains.ViewModel
{
    public class TestViewModel
    {
        public int PostId { get; set; }
        

        public string PostTitle { get; set; }

        public string PostContent { get; set; }

        public List<QuestionTestViewModel> Questions { get; set; }


    }
}
