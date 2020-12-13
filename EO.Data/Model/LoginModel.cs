using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EO.Data.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }

    }
}
