using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BookingListOrderDetailExtraDto
    {
        public BookingOrdersDto bookingOrders { get; set; }
        public IEnumerable<BookingOrderDetailDto>? bookingOrderDetail { get; set; }
        public IEnumerable<BookingOrderDetailExtraDto>? bookingOrderDetailExtra { get; set; }

    }
}
