using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("Booking_order_detail")] 
    public class Booking_order_detail
    {
        [Key]
        public int Borde_id { get; set; }
        public int Bodre_boor_id { get; set; }
        public DateTime Borde_checkin { get; set; }
        public DateTime Borde_checkout { get; set; }
        public int? Borde_adults { get; set; }
        public int? Borde_kids { get;set; }
        public decimal? Borde_price { get; set; }
        public decimal? Borde_extra { get; set; }
        public decimal? Bodre_discount { get; set; }
        public decimal? Borde_tax { get; set; }
        public decimal? Borde_subtotal { get; set; }
        public int? Borde_faci_id { get; set; }

    }
}
