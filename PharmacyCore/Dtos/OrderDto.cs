using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Dtos
{
    public class OrderDto
    {
        public int Quantity { get; set; }

        public string DeliveryMethod { get; set; }

        public string StatusOfOrder { get; set; }

        public double Price { get; set; }

        public DateTime DataOfOrder { get; set; }

        public int MedicineId { get; set; }

        public int UserID { get; set; }

    }
}
