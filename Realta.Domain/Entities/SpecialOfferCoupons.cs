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
        public int SocoId { get; set; }
        public int SocoBordeId { get; set; }
        public int SocoSpofId { get; set; }
    }
}
