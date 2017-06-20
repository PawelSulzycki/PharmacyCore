using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Dtos
{
    public class QuantityDto
    {
        public int MedicineId { get; set; }

        public int Quantity { get; set; }
    }
}
