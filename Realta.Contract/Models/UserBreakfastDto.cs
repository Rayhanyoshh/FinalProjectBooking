using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class UserBreakfastDto
    {
        [Required(ErrorMessage = "UsbrBordeId is Required")]
        public int UsbrBordeId { get; set; }
        [Required(ErrorMessage = "UsbrModifiedDate is Required")]
        public DateTime UsbrModifiedDate { get; set; }
        [Required(ErrorMessage = "UsbrTotalVacant is Required")]
        public short UsbrTotalVacant { get; set; }
    }
}
