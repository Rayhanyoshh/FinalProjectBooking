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
        public int BoexId { get; set; }

        public decimal? BoexPrice { get; set; }
        public Int16? BoexQty { get; set; }
        public decimal? BoexSubtotal { get; set; }
        public string? BoexMeasureUnit { get; set; }
        public int? BoexBordeId { get; set; }
        public int? BoexPritId { get; set; }
    }
}
