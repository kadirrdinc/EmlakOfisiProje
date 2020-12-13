
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EO.Data.Entities
{
    public class Notice : BaseEntity
    {
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string StatusType { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string HouseType { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int SquareMeter { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public string NumberOfRooms { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int HouseAge { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public bool IsFurnished { get; set; }

        [Required(ErrorMessage = "Zorunlu Alan")]
        public int AgentId { get; set; }
        public Agent Agent { get; set; }


    }
}
