using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyCore.Repositories
{
    public class PharmacyRepository
    {
        public void AddMedicine(CreateMedicineDto dto, PharmacyContext context)
        {
            var medicine = new Medicine
            {
                DataExpiration = dto.DataExpiration,
                Manufacturer = dto.Manufacturer,
                Name = dto.Name,
                Perscription = dto.Perscription,
                Price = dto.Price,
                Refunded = dto.Refunded,
                StorageMethod = dto.StorageMethod,
                Use = dto.Use,
                Quantity = dto.Quantity
            };

            context.Medicines.Add(medicine);
            context.SaveChanges();
        }

        public IEnumerable<MedicineDto> GetAllMedicine(PharmacyContext context)
        {
            var medicineDto = new List<MedicineDto>();
            foreach (var m in context.Medicines)
            {
                medicineDto.Add(new MedicineDto(m.Id, m.Name, m.Manufacturer, m.DataExpiration, m.StorageMethod, m.Perscription, m.Refunded));
            }

            return medicineDto;
        }

        public IEnumerable<MedicineDto> GetMedicine(PharmacyContext context, ConditionsMedicinesListDto dto)
        {
            var medicineDto = new List<MedicineDto>();
            foreach (var m in context.Medicines.Where(m => m.Refunded == dto.Refunded && m.Perscription == dto.Perscription
                     && m.StorageMethod == dto.StorageMethod).ToList())
            {
                medicineDto.Add(new MedicineDto(m.Id, m.Name, m.Manufacturer, m.DataExpiration, m.StorageMethod, m.Perscription, m.Refunded));
            }
            return medicineDto;
        }

        public MedicineDto GetMedicineById(PharmacyContext context, int id)
        {
            var medicineDataBase = context.Medicines.Single(m => m.Id == id);

            return new MedicineDto(medicineDataBase.Id, medicineDataBase.Name, medicineDataBase.Manufacturer, medicineDataBase.DataExpiration, medicineDataBase.StorageMethod, medicineDataBase.Perscription, medicineDataBase.Refunded);
        }

        public void AddUser(UserDto dto, PharmacyContext context)
        {
            var user = new User
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Login = dto.Login,
                Password = dto.Password,
                Role = dto.Role,
                City = dto.City,
                Street = dto.Street,
                PhoneNumber = dto.PhoneNumber
            };

            context.User.Add(user);
            context.SaveChanges();
        }

        public IEnumerable<UserDto> GetAllUser(PharmacyContext context)
        {
            var userDto = new List<UserDto>();

            foreach (var u in context.User)
            {
                userDto.Add(new UserDto
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    Login = u.Login,
                    Password = u.Password,
                    Role = u.Role,
                    City = u.City,
                    Street = u.Street,
                    PhoneNumber = u.PhoneNumber
                });
            }

            return userDto;
        }
    }
}
