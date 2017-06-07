using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Dtos
{
    public class MedicineDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public DateTime DataExpiration { get; set; }

        public string StorageMethod { get; set; }

        public bool Perscription { get; set; }

        public bool Refunded { get; set; }

        public MedicineDto(int id, string name, string manufacturer, DateTime dataExpriration, string storageMethod, bool perscription)
        {
            Id = id;
            Name = name;
            Manufacturer = manufacturer;
            DataExpiration = dataExpriration;
            StorageMethod = storageMethod;
            Perscription = perscription;
        }
    }
}
