using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.RequestFeatures
{
    public class HotelParameters : RequestParameters
    {
        public string? Location { get; set; }
        [AllowNull]
        public DateTime? StartDate { get; set; }
        [AllowNull]
        public DateTime? EndDate { get; set; }
        [AllowNull]
        public int? Number { get; set; }
        [AllowNull]
        public uint? MaxPrice {get; set; }
        [AllowNull]
        public uint? MinPrice { get; set; }
        [AllowNull]
        public bool ValidatePriceRange => MaxPrice > MinPrice;
    }
}
