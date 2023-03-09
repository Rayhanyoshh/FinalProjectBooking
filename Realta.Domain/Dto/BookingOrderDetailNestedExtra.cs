using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    public class BookingOrderDetailNestedExtra
    {

        public int BordeId { get; set; }
        public int BordeBoorId { get; set; }

        public DateTime BordeCheckin { get; set; }

        public DateTime BordeCheckout { get; set; }

        public int? BordeAdults { get; set; }
        public int? BordeKids { get; set; }
        public decimal? BordePrice { get; set; }
        public decimal? BordeExtra { get; set; }
        public decimal? BordeDiscount { get; set; }
        public decimal? BordeTax { get; set; }
        public decimal? BordeSubtotal { get; set; }
        public int? BordeFaciId { get; set; }

        public virtual ICollection<BookingOrderDetailExtra>? BookingOrderDetailExtras { get; set; }

    }
}
