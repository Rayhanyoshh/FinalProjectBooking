using System.Diagnostics.CodeAnalysis;

namespace Realta.Contract.Models;

public class UserDto
{
    public int UserId { get; set; }
    public string UserFullName { get; set; }
    public string? UserType { get; set; }
    public string? UserCompanyName { get; set; }
    public string? UserEmail { get; set; }
    public string UserPhoneNumber { get; set; }
    public DateTime? UserModifiedDate { get; set; }
}