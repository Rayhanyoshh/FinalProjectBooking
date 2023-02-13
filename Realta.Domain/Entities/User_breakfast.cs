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
    [Table("user_berakfast")]
    public  class User_breakfast
    {
        [Key]
        public int Usbr_borde_id { get; set; }
        public int Usbr_modified_date { get; set; }
    }
}
