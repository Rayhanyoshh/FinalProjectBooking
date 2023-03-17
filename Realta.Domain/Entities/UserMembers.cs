using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    public class UserMembers :Users
    {
        [Key]
        public int UsmeUserId { get; set; }
        public string UsmeMembName { get; set; }
        [ForeignKey("Members")]
        public DateTime? UsmePromoteDate { get; set; }
        public Int16? UsmePoints { get; set; }
        public string? UsmeType { get; set; }
    }
}
