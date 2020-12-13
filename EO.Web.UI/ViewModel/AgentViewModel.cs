using EO.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EO.Web.UI.ViewModel
{
    public class AgentViewModel : BaseEntity
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string CompanyName { get; set; }
    }
}
