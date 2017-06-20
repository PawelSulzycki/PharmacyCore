using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }

        public string DeliveryMethod { get; set; }

        public string StatusOfOrder { get; set; }

        public double Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataOfOrder { get; set; }

        public int MedicineId { get; set; }

        public Medicine Medicine { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }
    }
}
