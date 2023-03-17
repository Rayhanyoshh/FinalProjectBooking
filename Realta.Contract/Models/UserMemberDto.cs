namespace Realta.Contract.Models;

public class UserMemberDto : UserDto
{
    public int UsmeUserId { get; set; }
    public string UsmeMembName { get; set; }
    public DateTime? UsmePromoteDate { get; set; }
    public Int16? UsmePoints { get; set; }
    public string? UsmeType { get; set; }

}