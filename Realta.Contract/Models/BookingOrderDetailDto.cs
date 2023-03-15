using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BookingOrderDetailDto
    {
        [AllowNull] public int BordeId { get; set; }

        [Required(ErrorMessage = "Borde Boor ID is Required")]
        public int BordeBoorId { get; set; }

        [Required(ErrorMessage = "Borde Checkin is Required")]
        public DateTime BordeCheckin { get; set; }

        [Required(ErrorMessage = "Borde Checkout is Required")]
        public DateTime BordeCheckout { get; set; }

        public int? BordeAdults { get; set; }
        public int? BordeKids { get; set; }
        public decimal? BordePrice { get; set; }
        public decimal? BordeExtra { get; set; }
        public decimal? BordeDiscount { get; set; }
        public decimal? BordeTax { get; set; }
        public decimal? BordeSubtotal { get; set; }
        [Required(ErrorMessage = "BordeFaciId is Required")]
        public int? BordeFaciId { get; set; }

    }
}
