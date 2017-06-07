using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Dtos
{
    public class ShopDto
    {
        public int IdMedicine { get; set; }

        public string Quantity { get; set; }

        public string DeliveryMethod { get; set; }
    }
}
