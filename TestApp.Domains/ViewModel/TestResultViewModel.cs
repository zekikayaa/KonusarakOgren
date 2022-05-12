using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domains.ViewModel
{
    public class TestResultViewModel
    {
        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        public string CorrectOption { get; set; }

    }
}
