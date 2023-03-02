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
        public int BoexId { get; set; }
        public decimal? BoexPrice { get; set; }
        public Int16? BoexQty { get; set; }
        public decimal? BoexSubtotal { get; set; }
        public string? BoexMeasureUnit { get; set; }
        public int? BoexBordeId { get; set; }
        public int? BoexPritId { get; set; }


    }
}
