using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{

    [Table("Users")]
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string? UserType { get; set; }
        public string? UserCompanyName { get; set; }
        public string? UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public DateTime? UserModifiedDate { get; set; }
    }
}
