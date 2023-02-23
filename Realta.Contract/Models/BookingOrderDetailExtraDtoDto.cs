using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BookingOrderDetailExtraDtoDto
    {
        [Required(ErrorMessage = "Boex ID is Required")]
        public int boex_id { get; set; }

        public decimal? boex_price { get; set; }
        public Int16? boex_qty { get; set; }
        public decimal? boex_subtotal { get; set; }
        public string? boex_measure_unit { get; set; }
        public int? boex_borde_id { get; set; }
        public int? boex_prit_id { get; set; }
    }
}
