using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domains.Domains
{
    internal class Question : BaseEntity
    {

        public string Inquiry { get; set; }

        public string CorrectOption { get; set; }

        public string OptionA { get; set; }

        public string OptionB { get; set; }
        
        public string OptionC  { get; set; }

        public string OptionD { get; set; }


        [ForeignKey("Test")]
        public int TestId { get; set; }

        public Test Test { get; set; }

    }
}
