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
    public class Booking_order_detail_extra
    {
        [Key]
        public int Boex_id { get; set; }
        public decimal? Boex_price { get; set; }
        public Int16? Boex_qty { get; set; }
        public decimal? Boex_subtotal { get; set; }
        public string? Boex_measure_unit { get; set; }
        public int? Boex_borde_id { get; set; }
        public int? Boex_prit_id { get; set; }


    }
}
