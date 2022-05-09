using System.ComponentModel.DataAnnotations;

namespace TestApp.Domains.ViewModel
{
    public class QuestionTestViewModel
    {
        [Required]
        public string Inquiry { get; set; }


        [Required]
        public string CorrectOption { get; set; }


        [Required]
        public string OptionA { get; set; }


        [Required]
        public string OptionB { get; set; }


        [Required]
        public string OptionC { get; set; }


        [Required]
        public string OptionD { get; set; }

    }
}
