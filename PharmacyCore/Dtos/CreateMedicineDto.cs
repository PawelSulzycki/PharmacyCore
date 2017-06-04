using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Dtos
{
    public class CreateMedicineDto
    {
        private int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }
        
        public DateTime DataExpiration { get; set; }

        public string StorageMethod { get; set; }

        public string Use { get; set; }

        public double Price { get; set; }

        public bool Refunded { get; set; }

        public bool Perscription { get; set; }
    }
}
