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
        public int HotelId { get; set; }
        public string? HotelName { get; set; }
        public decimal HotelRoomPrice { get; set; }
        [AllowNull]
        public string? HotelDescription { get; set; } = string.Empty;
        // public bool HotelStatus { get; set; }
        // [AllowNull]
        // public string? HotelReasonStatus { get; set; } = string.Empty;
        [AllowNull]
        public decimal HotelRatingStar { get; set; }
        // [Phone]
        // public string? HotelPhonenumber { get; set; }
        // [AllowNull]
        // public DateTime HotelModifiedDate { get; set; } = DateTime.Now;
        [AllowNull]
        public string? HotelAddress { get; set; }
        [AllowNull]
        public string HotelProvience { get; set; }

    }
}
