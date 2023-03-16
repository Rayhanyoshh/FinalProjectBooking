using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BordeBoex
    {
        public BookingOrderDetailDto? BookingOrderDetail { get; set; }
        public virtual ICollection<BookingOrderDetailExtraDto> BookingOrderDetailExtra { get; set; }
    }
}
