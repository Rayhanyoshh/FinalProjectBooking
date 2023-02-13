using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BookingOrdersDto
    {
        [Required(ErrorMessage = "Boor ID is Required")]
        public int boor_id { get; set; }


        [Required(ErrorMessage = "Boor Order Date is Required")]
        public string boor_order_number { get; set; }

        [Required(ErrorMessage = "Boor Order Number is Required")]
        public DateTime boor_order_date { get; set; }
        public DateTime boor_arrival_date { get; set; }
        public short? boor_total_room { get; set; }
        public short? boor_total_guest { get; set; }
        public decimal? boor_discount { get; set; }
        public decimal? boor_total_tax { get; set; }
        public decimal? boor_total_ammount { get; set; }
        public decimal? boor_down_payment { get; set; }

        [Required(ErrorMessage = "Boor Payment type is Required")]
        public string? boor_pay_type { get; set; }

        [Required(ErrorMessage = "Boor Is Paid is Required")]
        public string boor_is_paid { get; set; }

        [Required(ErrorMessage = "Boor Type is Required")]
        public string boor_type { get; set; }

        [CreditCard(ErrorMessage = "Type your creditcard number correctly")]
        public string? boor_cardnumber { get; set; }
        public string? boor_member_type { get; set; }
        public string? boor_status { get; set; }
        public int boor_user_id { get; set; }
        public int boor_hotel_id { get; set; }
    }
}



