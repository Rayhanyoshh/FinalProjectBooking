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
    public class Booking_orders
    {
        [Key]
        public int boor_id { get; set; }
        public string boor_order_number { get; set; }
        public DateTime boor_order_date { get; set; }
        public DateTime? boor_arrival_date { get; set; }
        public short? boor_total_room { get; set; }
        public short? boor_total_guest { get; set; }
        public decimal? boor_discount { get; set; }
        public decimal? boor_total_tax { get; set; }
        public decimal? boor_total_ammount { get; set; }
        public decimal? boor_down_payment { get; set; }
        public string boor_pay_type { get; set; }
        public string boor_is_paid { get; set; }
        public string boor_type { get; set; }
        public string? boor_cardnumber { get; set; }
        public string? boor_member_type { get; set; }
        public string? boor_status { get; set; }
        public int  boor_user_id { get; set; }
        public int boor_hotel_id { get; set; }

    }
}
