using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EO.Data.Entities
{
    public class Agent : BaseEntity
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Password { get; set; }

        [NotMapped]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Role { get; set; }

        public List<Notice> Notices { get; set; }
    }
}
