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

        public IEnumerable<MedicineDto> GetAllMedicine(PharmacyContext context)
        {
            var medicineDto = new List<MedicineDto>();  
            foreach(var m in context.Medicines)
            {
                medicineDto.Add(new MedicineDto(m.Name, m.Manufacturer, m.DataExpiration));
            }

            return medicineDto;
        }

        public IEnumerable<MedicineDto> GetMedicine(PharmacyContext context, ConditionsMedicinesListDto dto)
        {
            var medicineDto = new List<MedicineDto>();
            foreach(var m in context.Medicines.Where(m => m.Refunded == dto.Refunded && m.Perscription==dto.Perscription 
                    && m.StorageMethod == dto.StorageMethod).ToList())
            {
                medicineDto.Add(new MedicineDto(m.Name, m.Manufacturer, m.DataExpiration));
            }
            return medicineDto;
        }
    }
}
