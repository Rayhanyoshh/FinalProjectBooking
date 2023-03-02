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
        public int BoorId { get; set; }


        [Required(ErrorMessage = "Boor Order Date is Required")]
        public string BoorOrderNumber { get; set; }

        [Required(ErrorMessage = "Boor Order Number is Required")]
        public DateTime BoorOrderDate { get; set; }
        public DateTime BoorArrivalDate { get; set; }
        public short? BoorTotalRoom { get; set; }
        public short? BoorTotalGuest { get; set; }
        public decimal? BoorDiscount { get; set; }
        public decimal? BoorTotalTax { get; set; }
        public decimal? BoorTotalAmmount { get; set; }
        public decimal? BoorDownPayment { get; set; }

        [Required(ErrorMessage = "Boor Payment type is Required")]
        public string? BoorPayType { get; set; }

        [Required(ErrorMessage = "Boor Is Paid is Required")]
        public string BoorIsPaid { get; set; }

        [Required(ErrorMessage = "Boor Type is Required")]
        public string BoorType { get; set; }

        [CreditCard(ErrorMessage = "Type your creditcard number correctly")]
        public string? BoorCardnumber { get; set; }
        public string? BoorMemberType { get; set; }
        public string? BoorStatus { get; set; }
        public int BoorUserId { get; set; }
        public int BoorHotelId { get; set; }
    }
}



