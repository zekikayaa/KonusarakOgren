using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.Domains.Domains
{
    public class Question : BaseEntity
    {

        public string Inquiry { get; set; }

        public int CorrectOption { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }
        
        public string OptionC  { get; set; }

        public string OptionD { get; set; }


        [ForeignKey("Test")]
        public int TestId { get; set; }

        public Test Test { get; set; }

    }
}
