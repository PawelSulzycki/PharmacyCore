using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Models;
using System;
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
                medicineDto.Add(new MedicineDto
                {
                    Id = m.Id,
                    Manufacturer = m.Manufacturer,
                    DataExpiration = m.DataExpiration,
                    StorageMethod = m.StorageMethod,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    Price = m.Price,
                    Quantity = m.Quantity,
                    Name = m.Name
                });
            }

            return medicineDto;
        }

        public IEnumerable<MedicineDto> GetAllMedicineByUser(PharmacyContext context)
        {
            var medicineDto = new List<MedicineDto>();
            foreach (var m in context.Medicines.Where(x => x.Quantity != 0 && x.DataExpiration > DateTime.Now.AddDays(30)))
            {
                medicineDto.Add(new MedicineDto
                {
                    Id = m.Id,
                    Manufacturer = m.Manufacturer,
                    DataExpiration = m.DataExpiration,
                    StorageMethod = m.StorageMethod,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    Price = m.Price,
                    Quantity = m.Quantity,
                    Name = m.Name
                });
            }

            return medicineDto;
        }

        public IEnumerable<MedicineDto> GetMedicine(PharmacyContext context, ConditionsMedicinesListDto dto)
        {
            var medicineDto = new List<MedicineDto>();
            if (dto.StorageMethod == "brak")
            {
                return GetAllMedicineForUser(context);
            }
            foreach (var m in context.Medicines.Where(m => m.Refunded == dto.Refunded && m.Perscription == dto.Perscription
                     && m.StorageMethod == dto.StorageMethod && m.Quantity != 0 && m.DataExpiration > DateTime.Now.AddDays(30)).ToList())
            {
                medicineDto.Add(new MedicineDto
                {
                    Id = m.Id,
                    Manufacturer = m.Manufacturer,
                    DataExpiration = m.DataExpiration,
                    StorageMethod = m.StorageMethod,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    Price = m.Price,
                    Quantity = m.Quantity,
                    Name = m.Name,
                    Use = m.Use
                });
            }
            return medicineDto;
        }

        public MedicineDto GetMedicineById(PharmacyContext context, int id)
        {
            var medicineDataBase = context.Medicines.Single(m => m.Id == id);

            return new MedicineDto
            {
                Id = medicineDataBase.Id,
                Manufacturer = medicineDataBase.Manufacturer,
                DataExpiration = medicineDataBase.DataExpiration,
                StorageMethod = medicineDataBase.StorageMethod,
                Perscription = medicineDataBase.Perscription,
                Refunded = medicineDataBase.Refunded,
                Price = medicineDataBase.Price,
                Quantity = medicineDataBase.Quantity,
                Name = medicineDataBase.Name
            };
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

            context.Users.Add(user);
            context.SaveChanges();
        }

        public IEnumerable<UserDto> GetAllUser(PharmacyContext context)
        {
            var userDto = new List<UserDto>();

            foreach (var u in context.Users)
            {
                userDto.Add(new UserDto
                {
                    Id = u.Id,
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

        public UserDto GetUserById(PharmacyContext context, int id)
        {
            var user = context.Users.Single(x => x.Id == id);
            return new UserDto
            {
                Name = user.Name,
                Surname = user.Surname,
                Login = user.Login,
                Password = user.Password,
                Role = user.Role,
                City = user.City,
                Street = user.Street,
                PhoneNumber = user.PhoneNumber
            };
        }

        public UserDto GetUserByNameAndPassword(PharmacyContext context, string login, string password)
        {
            var userDataBase = context.Users.Single(x => x.Login == login && x.Password == password);

            return new UserDto
            {
                Id = userDataBase.Id,
                Name = userDataBase.Name,
                Surname = userDataBase.Surname,
                Login = userDataBase.Login,
                Password = userDataBase.Password,
                Role = userDataBase.Role,
                City = userDataBase.City,
                Street = userDataBase.Street,
                PhoneNumber = userDataBase.PhoneNumber

            };
        }

        public void AddOrder(OrderDto dto, PharmacyContext context)
        {
            var order = new Order
            {
                UserID = dto.UserID,
                MedicineId = dto.MedicineId,
                Quantity = dto.Quantity,
                DeliveryMethod = dto.DeliveryMethod,
                DataOfOrder = dto.DataOfOrder,
                StatusOfOrder = dto.StatusOfOrder,
                Price = dto.Price
            };

            context.Orders.Add(order);
            context.SaveChanges();
        }

        public IEnumerable<OrderDto> GetAllOrderByUserId(PharmacyContext context, int userId)
        {
            var orderDto = new List<OrderDto>();

            foreach (var u in context.Orders.Where(x => x.UserID == userId))
            {
                orderDto.Add(new OrderDto
                {
                    UserID = u.UserID,
                    MedicineId = u.MedicineId,
                    DataOfOrder = u.DataOfOrder,
                    DeliveryMethod = u.DeliveryMethod,
                    Price = u.Price,
                    Quantity = u.Quantity,
                    StatusOfOrder = u.StatusOfOrder
                });
            }

            return orderDto;
        }

        public IEnumerable<MedicineDto> GetAllMedicineForUser(PharmacyContext context)
        {
            var medicineDto = new List<MedicineDto>();
            foreach (var m in context.Medicines.Where(x => x.Quantity != 0 && x.DataExpiration > DateTime.Now.AddDays(30)))
            {
                medicineDto.Add(new MedicineDto
                {
                    Manufacturer = m.Manufacturer,
                    DataExpiration = m.DataExpiration,
                    StorageMethod = m.StorageMethod,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    Quantity = m.Quantity,
                    Name = m.Name,
                    Use = m.Use,
                });
            }

            return medicineDto;
        }

        public void UpdateQuantityInMedicine(PharmacyContext context, int quantity, int medicineId)
        {
            var medicine = context.Medicines.Single(m => m.Id == medicineId);

            medicine.Quantity = medicine.Quantity + quantity;

            context.Medicines.Update(medicine);
            context.SaveChanges();
        }

        public IEnumerable<OrderDto> GetAllOrder(PharmacyContext context)
        {
            var orderDto = new List<OrderDto>();

            foreach (var u in context.Orders)
            {
                orderDto.Add(new OrderDto
                {
                    UserID = u.UserID,
                    MedicineId = u.MedicineId,
                    DataOfOrder = u.DataOfOrder,
                    DeliveryMethod = u.DeliveryMethod,
                    Price = u.Price,
                    Quantity = u.Quantity,
                    StatusOfOrder = u.StatusOfOrder,
                    Id = u.Id
                });
            }

            return orderDto;
        }

        public void DoneOreder(PharmacyContext context, int orderId, int quantity)
        {
            var order = context.Orders.Single(x => x.Id == orderId);

            var medicine = context.Medicines.Single(m => m.Id == order.MedicineId);

            medicine.Quantity = medicine.Quantity - quantity;

            context.Medicines.Update(medicine);

            order.StatusOfOrder = "Zamowienie zrealizowane";

            context.Orders.Update(order);

            context.SaveChanges();
        }

        public UserDto InformationSeller(PharmacyContext context, int id)
        {
            var order = context.Orders.Single(x => x.Id == id);

            var user = context.Users.Single(x => x.Id == order.UserID);

            return new UserDto
            {
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                Street = user.Street,
                PhoneNumber = user.PhoneNumber

            };
        }

        public void DeleteUser(PharmacyContext context, int id)
        {
            var user = context.Users.Single(x => x.Id == id);

            context.Users.Attach(user);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void DeleteMedicine(PharmacyContext context, int medicineId)
        {
            var medicine = context.Medicines.Single(x => x.Id == medicineId);

            context.Medicines.Attach(medicine);
            context.Medicines.Remove(medicine);
            context.SaveChanges();
        }


    }
}
