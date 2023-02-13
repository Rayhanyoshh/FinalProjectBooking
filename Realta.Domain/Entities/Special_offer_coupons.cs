using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("Special_offer_coupons")] 
    public class Special_offer_coupons
    {
        [Key]
        public int Soco_id { get; set; }
        public int Soco_borde_id { get; set; }
        public int Soco_spof_id { get; set; }
    }
}
