using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Domain.RequestFeatures
{
    public class SpecialOfferParameters : RequestParameters
    {
        public uint MinQty { get; set; }
        public uint MaxQty { get; set; } = int.MaxValue;
        public bool ValidateStockRange => MaxQty > MinQty;
        public string? SearchTerm { get; set; }
        public string OrderBy { get; set; } = "SpofId";
    }
}