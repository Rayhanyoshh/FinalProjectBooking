using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class HotelReviewsDto
    {
        [Required(ErrorMessage = "hotel review id is required")]
        public int HoreId { get; set; }
        [Required(ErrorMessage = "user review is required")]
        public string? HoreUserReview { get; set; }
        [Required(ErrorMessage = "rating is required")]
        [Range(1, 5, ErrorMessage = "Value for Rating must be between {1} and {2}.")]
        public byte HoreRating { get; set; } = 5;
        [Required(ErrorMessage = "user id is required")]
        public int HoreUserId { get; set; }
        [Required(ErrorMessage = "hotel id is required")]
        public int HoreHotelId { get; set; }
        [AllowNull]
        public DateTime HoreCreatedOn { get; set; }
    }
}
