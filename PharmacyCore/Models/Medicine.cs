using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Models
{
    public class Medicine
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataExpiration { get; set; }

        public string StorageMethod { get; set; }

        public string Use { get; set; }

        public double Price { get; set; }

        public bool Refunded { get; set; }

        public bool Perscription { get; set; }

        public int Quantity { get; set; }
    }
}
