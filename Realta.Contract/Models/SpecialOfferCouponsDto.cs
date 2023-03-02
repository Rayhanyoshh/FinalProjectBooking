using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Realta.Contract.Models
{
    public class SpecialOfferCouponsDto
    {
        public int Socoid { get; set; }
        public int SocoBordeId { get; set; }
        public int SocoSpofId { get; set; }
    }
}
