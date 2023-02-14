using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BordeDto
    {
        [Required(ErrorMessage = "Borde ID is Required")]
        public int borde_id { get; set; }

        [Required(ErrorMessage = "Borde Boor ID is Required")]
        public int borde_boor_id { get; set; }

        [Required(ErrorMessage = "Borde Checkin is Required")]
        public DateTime borde_checkin { get; set; }

        [Required(ErrorMessage = "Borde Checkout is Required")]
        public DateTime borde_checkout { get; set; }

        public int? borde_adults { get; set; }
        public int? borde_kids { get; set; }
        public decimal? borde_price { get; set; }
        public decimal? borde_extra { get; set; }
        public decimal? borde_discount { get; set; }
        public decimal? borde_tax { get; set; }
        public decimal? borde_subtotal { get; set; }
        public int? borde_faci_id { get; set; }
    }
}
