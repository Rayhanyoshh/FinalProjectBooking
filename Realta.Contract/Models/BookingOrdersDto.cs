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

        [Required(ErrorMessage = "Boor Payment type is Required")]
        public string? BoorPayType { get; set; }

        [Required(ErrorMessage = "Boor Is Paid is Required")]
        public string BoorIsPaid { get; set; }
        public string? BoorType { get; set; }
        public string? BoorCardnumber { get; set; }
        public string? BoorMemberType { get; set; }
        public string? BoorStatus { get; set; }
        [Required(ErrorMessage = "BoorUserId is Required")]
        public int BoorUserId { get; set; }
        [Required(ErrorMessage = "BoorHotelId is Required")]
        public int BoorHotelId { get; set; }
        public string? TrxNumber { get; set; }
        
        public int? FaciId { get; set; }

        public string? FaciName { get; set; }

        public DateTime FaciStartdate { get; set; }

        public DateTime FaciEnddate { get; set; }

        public decimal? FaciPrice { get; set; }

        public decimal? FaciDiscount { get; set; }

        public decimal? FaciTaxRate { get; set; }

        public int FaciMaxNumber { get; set; }

        public string? FaciPhotoUrl { get; set; }

    }
}



