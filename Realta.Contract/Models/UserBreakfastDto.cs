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
        [Required(ErrorMessage = "Usbr_borde_id is Required")]
        public int usbr_borde_id { get; set; }
        [Required(ErrorMessage = "Usbr_modified_date is Required")]
        public int usbr_modified_date { get; set; }
        [Required(ErrorMessage = "usbr_total_vacant is Required")]
        public int usbr_total_vacant { get; set; }
    }
}
