using System;

namespace PharmacyCore.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string DeliveryMethod { get; set; }

        public string StatusOfOrder { get; set; }

        public double Price { get; set; }

        public DateTime DataOfOrder { get; set; }

        public int MedicineId { get; set; }

        public int UserID { get; set; }

    }
}
