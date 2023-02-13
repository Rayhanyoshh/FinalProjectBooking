using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    internal class BookingOrdersDto
    {
        [Required(ErrorMessage = "BoorID is Required")]
        public int BoorId { get; set; }


        [Required]
        [MinLength(5, ErrorMessage = "Region Description must longer than 5 Character")]
        [MaxLength(50, ErrorMessage = "Region Description cannot no longer than 50 character")]

        public string? RegionDescription { get; set; }
    }
}



