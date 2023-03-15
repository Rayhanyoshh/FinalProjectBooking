using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("Booking_orders")]
    public class BookingOrders
    {
        [Key]
        public int? BoorId { get; set; }
        public string? BoorOrderNumber { get; set; }
        public DateTime? BoorOrderDate { get; set; }
        public DateTime? BoorArrivalDate { get; set; }
        public short? BoorTotalRoom { get; set; }
        public short? BoorTotalGuest { get; set; }
        public decimal? BoorDiscount { get; set; }
        public decimal? BoorTotalTax { get; set; }
        public decimal? BoorTotalAmmount { get; set; }
        public decimal? BoorDownPayment { get; set; }
        public string BoorPayType { get; set; }
        public string BoorIsPaid { get; set; }
        public string? BoorType { get; set; }
        public string? BoorCardnumber { get; set; }
        public string? BoorMemberType { get; set; }
        public string? BoorStatus { get; set; }
        public int BoorUserId { get; set; }
        public int BoorHotelId { get; set; }


    }
}
