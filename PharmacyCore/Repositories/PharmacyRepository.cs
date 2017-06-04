using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyCore.Repositories
{
    public class PharmacyRepository
    {
        public void AddMedicine(CreateMedicineDto dto, PharmacyContext context)
        {
            var medicine = new Medicine {
                DataExpiration = dto.DataExpiration,
                Manufacturer = dto.Manufacturer,
                Name=dto.Name,
                Perscription = dto.Perscription,
                Price = dto.Price,
                Refunded = dto.Refunded,
                StorageMethod = dto.StorageMethod,
                Use = dto.Use
            };

            context.Medicines.Add(medicine);
            context.SaveChanges();
        }
    }
}
