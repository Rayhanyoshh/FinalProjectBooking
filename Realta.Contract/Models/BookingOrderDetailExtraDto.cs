using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class BookingOrderDetailExtraDto
    {
        [AllowNull] public int BoexId { get; set; }

        [AllowNull] public decimal? BoexPrice { get; set; }
        [AllowNull] public Int16? BoexQty { get; set; }
        [AllowNull] public decimal? BoexSubtotal { get; set; }
        [AllowNull] public string? BoexMeasureUnit { get; set; }
        [AllowNull] public int? BoexBordeId { get; set; }
        [AllowNull] public int? BoexPritId { get; set; }
        [AllowNull] public string? PritName { get; set; }

    }
}
