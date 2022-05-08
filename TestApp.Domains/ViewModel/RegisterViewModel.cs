using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Domains.ViewModel
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }


        [Required]
        public string Passowrd { get; set; }


    }
}
