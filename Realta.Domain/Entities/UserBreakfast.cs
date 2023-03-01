using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("user_breakfast")]
    public  class UserBreakfast
    {
        [Key]
        public int UsbrBordeId { get; set; }        // UsbrBorde
        [Key]
        public DateTime UsbrModifiedDate { get; set; }
        public short UsbrTotalVacant { get; set; }

    }
}
