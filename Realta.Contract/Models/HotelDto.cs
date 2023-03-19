using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace Realta.Contract.Models;

public class HotelsDto
{
    [Required(ErrorMessage = "hotel id is required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int HotelId { get; set; }
    
    [Required(ErrorMessage = "Hotel name is required")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HotelName { get; set; }
    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal HotelRatingStar { get; set; }
    
    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HotelDescription { get; set; }
    
    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HotelAddress { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HotelCity { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FaciId { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FaciName { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime FaciStartdate { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DateTime FaciEnddate { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? FaciPrice { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? FaciDiscount { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public decimal? FaciTaxRate { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int FaciMaxNumber { get; set; }

    [AllowNull]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FaciPhotoUrl { get; set; }
    
}