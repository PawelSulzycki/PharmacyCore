using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Dtos
{
    public class MedicineDto
    {
        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public DateTime DataExpiration { get; set; }

        public MedicineDto(string name, string manufacturer, DateTime dataExpriration)
        {
            Name = name;
            Manufacturer = manufacturer;
            DataExpiration = dataExpriration;
        }
    }
}
