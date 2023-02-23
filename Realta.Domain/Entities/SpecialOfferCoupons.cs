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
    public class SpecialOfferCoupons
    {
        [Key]
        public int soco_id { get; set; }
        public int soco_borde_id { get; set; }
        public int soco_spof_id { get; set; }
    }
}
