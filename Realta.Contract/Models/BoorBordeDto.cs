using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BoorBordeDto
    {
        public BookingOrdersDto? BookingOrders { get; set; }
        public virtual ICollection<BordeBoex> BookingDetailExtra { get; set; }
    }
}
