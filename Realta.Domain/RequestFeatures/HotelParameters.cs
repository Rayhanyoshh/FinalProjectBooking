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
        [AllowNull]
        public int? HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? HotelCity { get; set; }
        public string? HotelAddress { get; set; }
        public int? FaciId { get; set; }
        public string? FaciName { get; set; }
        public DateTime? FaciStartdate { get; set; }
        public DateTime? FaciEnddate { get; set; }
        public int? FaciMaxNumber { get; set; }
        public decimal? FaciPrice { get; set; }
        
        public string OrderBy { get; set; } = "hotelName";

        

        

        public string? Location { get; set; }
        [AllowNull]
        public DateTime? StartDate { get; set; }
        [AllowNull]
        public DateTime? EndDate { get; set; }
        [AllowNull]
        public int? Number { get; set; }
        [AllowNull]
        public decimal? MaxPrice {get; set; }
        [AllowNull]
        public decimal? MinPrice { get; set; }
        [AllowNull]
        public bool ValidatePriceRange => MaxPrice > MinPrice;
    }
}
