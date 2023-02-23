using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("Booking_order_detail_extra")]
    public class BookingOrderDetailExtra
    {
        [Key]
        public int boex_id { get; set; }
        public decimal? boex_price { get; set; }
        public Int16? boex_qty { get; set; }
        public decimal? boex_subtotal { get; set; }
        public string? boex_measure_unit { get; set; }
        public int? boex_borde_id { get; set; }
        public int? boex_prit_id { get; set; }


    }
}
