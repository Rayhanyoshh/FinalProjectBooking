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

        public int spof_id { get; set; }
        [Required(ErrorMessage = "spof_name is Required")]

        public string spof_name { get; set; }
        [Required(ErrorMessage = "spof_description is Required")]
        public string spof_description { get; set; }
        [Required(ErrorMessage = "spof_type is Required")]
        public string spof_type { get; set; }
        [Required(ErrorMessage = "spof_discount is Required")]
        public decimal spof_discount { get; set; }
        [Required(ErrorMessage = "spof_start_date is Required")]
        public DateTime spof_start_date { get; set; }
        [Required(ErrorMessage = "spof_end_date is Required")]
        public DateTime spof_end_date { get; set; }
        public int? spof_min_qty { get; set; }
        public int? spof_max_qty { get; set; }
        public DateTime? spof_modified_date { get; set; }
    }
}
