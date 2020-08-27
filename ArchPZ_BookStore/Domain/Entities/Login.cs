using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Login
    {
        [HiddenInput(DisplayValue = false)]
        [Required(ErrorMessage = "Login bleat")]
        [Display(Name = "Login")]
        public string UserLogin { get { return Login0; } }

        [Required(ErrorMessage = "Password bleat")]
        [Display(Name = "Password")]
        public string Password { get { return Password0; } }


        private string Login0 = "Admin";

        private string Password0 = "root";

        
    }
}
