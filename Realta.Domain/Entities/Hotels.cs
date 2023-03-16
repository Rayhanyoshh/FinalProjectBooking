using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("Hotels")]
    public class Hotels
    {
        [Key]
        [Required(ErrorMessage = "hotel id is required")]
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Hotel name is required")]
        public string? HotelName { get; set; }
        [AllowNull]
        public decimal HotelRatingStar { get; set; }
        [AllowNull]
        
        public string HotelDescription { get; set; }
        [AllowNull]
        public string? HotelAddress { get; set; }
        [AllowNull]
        public string? HotelCity { get; set; }

        [AllowNull]
        public int? FaciId { get; set; }

        [AllowNull]
        public string? FaciName { get; set; }
        [AllowNull]
        public DateTime FaciStartdate { get; set; }
        [AllowNull]
        public DateTime FaciEnddate { get; set; }
        [AllowNull]
        public decimal? FaciPrice { get; set; }
        [AllowNull]
        public decimal? FaciDiscount { get; set; }
        [AllowNull]
        public decimal? FaciTax { get; set; }
        [AllowNull]
        public int FaciMaxNumber { get; set; }
        [AllowNull]
        public string FaciPhotoUrl { get; set; }
    }
}
