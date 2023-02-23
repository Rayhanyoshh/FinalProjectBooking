using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("Special_offers")] 
    public class SpecialOffers
    {
        [Key]
        public int spof_id { get; set; }
        public string spof_name { get; set; }
        public string spof_description { get; set; }
        public string  spof_type { get; set; }
        public decimal spof_discount { get; set; }
        public DateTime spof_start_date { get; set; }
        public DateTime spof_end_date { get; set; }
        public int? spof_min_qty { get; set; }
        public int? spof_max_qty { get; set; }
        public DateTime? spof_modified_date { get; set; }


    }
}
