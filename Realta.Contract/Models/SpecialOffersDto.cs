using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class SpecialOffersDto
    {
        [Required(ErrorMessage = "spof_id is Required")]

        public int SpofId { get; set; }
        [Required(ErrorMessage = "spof_name is Required")]

        public string SpofName { get; set; }
        [Required(ErrorMessage = "spof_description is Required")]
        public string SpofDescription { get; set; }
        [Required(ErrorMessage = "spof_type is Required")]
        public string SpofType { get; set; }
        [Required(ErrorMessage = "spof_discount is Required")]
        public decimal SpofDiscount { get; set; }
        [Required(ErrorMessage = "spof_start_date is Required")]
        public DateTime SpofStartDate { get; set; }
        [Required(ErrorMessage = "spof_end_date is Required")]
        public DateTime SpofEndDate { get; set; }
        public int? SpofMinQty { get; set; }
        public int? SpofMaxQty { get; set; }
        public DateTime? SpofModifiedDate { get; set; }
    }
}
