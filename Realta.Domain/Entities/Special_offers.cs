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
    public class Special_offers
    {
        [Key]
        public int Spof_id { get; set; }
        public string Spof_name { get; set; }
        public string Spof_description { get; set; }
        public string  Spof_type { get; set; }
        public decimal Spof_discount { get; set; }
        public DateTime Spof_start_date { get; set; }
        public DateTime Spof_end_date { get; set; }
        public int? Spof_min_qty { get; set; }
        public int? Spof_max_qty { get; set; }
        public DateTime? Spof_modified_date { get; set; }


    }
}
