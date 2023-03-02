using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.Entities
{
    [Table("Special_offers")] 
    public class SpecialOffers
    {
        [Key]
        public int SpofId { get; set; }
        public string? SpofName { get; set; }
        public string? SpofDescription { get; set; }
        public string? SpofType { get; set; }
        public decimal SpofDiscount { get; set; }
        public DateTime SpofStartDate { get; set; }
        public DateTime SpofEndDate { get; set; }
        public int? SpofMinQty { get; set; }
        public int? SpofMaxQty { get; set; }
        public DateTime? SpofModifiedDate { get; set; }


    }
}
