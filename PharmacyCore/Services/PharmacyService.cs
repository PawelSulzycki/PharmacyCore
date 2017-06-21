using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Repositories;
using PharmacyCore.ViewModels;
using System.Collections.Generic;

namespace PharmacyCore.Services
{
    public class PharmacyService
    {
        private readonly PharmacyRepository pharmacyRepository;

        public PharmacyService()
        {
            pharmacyRepository = new PharmacyRepository();
        }

        public void CreateMedicine(CreateMedicineDto dto, PharmacyContext context)
        {
            pharmacyRepository.AddMedicine(dto, context);
        }

        public CreateMedicineViewModel GetCreateMedicineViewModel()
        {
            var viewModel = new CreateMedicineViewModel()
            {
                CreateMedicineDto = new CreateMedicineDto()
            };

            return viewModel;
        }

        public IEnumerable<MedicineViewModel> GetAllMedicineViewModel(PharmacyContext context)
        {
            var medicineDto = pharmacyRepository.GetAllMedicine(context);
            var viewModel = new List<MedicineViewModel>();
            foreach (var m in medicineDto)
            {
                viewModel.Add(new MedicineViewModel
                {
                    Id = m.Id,
                    DataExpiration = m.DataExpiration,
                    Manufacturer = m.Manufacturer,
                    Name = m.Name,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    StorageMethod = m.StorageMethod,
                    Quantity = m.Quantity,
                    Price = m.Price,
                    Use = m.Use
                });
            }

            return viewModel;
        }

        public IEnumerable<MedicineViewModel> GetAllMedicineByUserViewModel(PharmacyContext context)
        {
            var medicineDto = pharmacyRepository.GetAllMedicineByUser(context);
            var viewModel = new List<MedicineViewModel>();
            foreach (var m in medicineDto)
            {
                viewModel.Add(new MedicineViewModel
                {
                    Id = m.Id,
                    DataExpiration = m.DataExpiration,
                    Manufacturer = m.Manufacturer,
                    Name = m.Name,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    StorageMethod = m.StorageMethod,
                    Quantity = m.Quantity,
                    Price = m.Price,
                    Use = m.Use
                });
            }

            return viewModel;
        }

        public IEnumerable<MedicineViewModel> GetMedicineViewModel(PharmacyContext context, ConditionsMedicinesListDto dto)
        {
            var medicineDto = pharmacyRepository.GetMedicine(context, dto);
            var viewModel = new List<MedicineViewModel>();
            foreach (var m in medicineDto)
            {
                viewModel.Add(new MedicineViewModel
                {
                    Id = m.Id,
                    DataExpiration = m.DataExpiration,
                    Manufacturer = m.Manufacturer,
                    Name = m.Name,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    StorageMethod = m.StorageMethod,
                    Use = m.Use,
                    Price = m.Price,
                    Quantity = m.Quantity
                });
            }

            return viewModel;
        }

        public MedicineDto GetMedicineById(PharmacyContext context, int id)
        {
            return pharmacyRepository.GetMedicineById(context, id);
        }

        public void CreateUser(UserDto dto, PharmacyContext context)
        {
            pharmacyRepository.AddUser(dto, context);
        }

        public IEnumerable<AdminViewModel> GetAllUser(PharmacyContext context)
        {
            var viewModel = new List<AdminViewModel>();

            foreach (var item in pharmacyRepository.GetAllUser(context))
            {
                viewModel.Add(new AdminViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Surname = item.Surname,
                    Login = item.Login,
                    Password = item.Password,
                    Role = item.Role,
                    PhoneNumber = item.PhoneNumber,
                    Street = item.Street,
                    City = item.City
                });
            }

            return viewModel;
        }

        public CreateUserViewModel GetCreateUserViewModel()
        {
            var viewModel = new CreateUserViewModel()
            {
                UserDto = new UserDto()
            };

            return viewModel;
        }

        public UserDto GetUserByNameAndPassword(PharmacyContext context, string login, string password)
        {
            return pharmacyRepository.GetUserByNameAndPassword(context, login, password);
        }

        public void CreateOrder(OrderDto dto, PharmacyContext context)
        {
            pharmacyRepository.AddOrder(dto, context);
        }

        public IEnumerable<OrderViewModel> GetAllOrderByUserIdViewModel(PharmacyContext context, int userId)
        {
            var viewModel = new List<OrderViewModel>();

            foreach (var item in pharmacyRepository.GetAllOrderByUserId(context, userId))
            {
                var medicine = pharmacyRepository.GetMedicineById(context, item.MedicineId);

                viewModel.Add(new OrderViewModel
                {
                    Name = medicine.Name,
                    Price = item.Price,
                    DataOfOrder = item.DataOfOrder,
                    DeliveryMethod = item.DeliveryMethod,
                    Quantity = item.Quantity,
                    StatusOfOrder = item.StatusOfOrder
                });
            }

            return viewModel;
        }

        public IEnumerable<MedicineViewModel> GetAllMedicineForUserViewModel(PharmacyContext context)
        {
            var medicineDto = pharmacyRepository.GetAllMedicineForUser(context);
            var viewModel = new List<MedicineViewModel>();
            foreach (var m in medicineDto)
            {
                viewModel.Add(new MedicineViewModel
                {
                    Manufacturer = m.Manufacturer,
                    DataExpiration = m.DataExpiration,
                    StorageMethod = m.StorageMethod,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    Quantity = m.Quantity,
                    Name = m.Name,
                    Use = m.Use
                });
            }

            return viewModel;
        }

        public void UpdateQuantityInMedicine(PharmacyContext context, int quantity, int medicineId)
        {
            pharmacyRepository.UpdateQuantityInMedicine(context, quantity, medicineId);
        }

        public IEnumerable<SellerOrderViewModel> GetAllOrderViewModel(PharmacyContext context)
        {
            var viewModel = new List<SellerOrderViewModel>();

            foreach (var item in pharmacyRepository.GetAllOrder(context))
            {
                if (item.StatusOfOrder == "Zamówienie w czasie realizacji")
                {
                    var user = pharmacyRepository.GetUserById(context, item.UserID);
                    var medicine = pharmacyRepository.GetMedicineById(context, item.MedicineId);

                    viewModel.Add(new SellerOrderViewModel
                    {
                        DataOfOrder = item.DataOfOrder,
                        DeliveryMethod = item.DeliveryMethod,
                        Quantity = item.Quantity,
                        UserName = user.Login,
                        Name = medicine.Name,
                        Id = item.Id
                    });
                }
            }

            return viewModel;
        }
        public void DoneOreder(PharmacyContext context, int orderId, int quantity)
        {
            pharmacyRepository.DoneOreder(context, orderId, quantity);
        }

        public InformationSellerViewModel InformationSellerViewModel(PharmacyContext context, int id)
        {
            var user = pharmacyRepository.InformationSeller(context, id);

            return new InformationSellerViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                PhoneNumber = user.PhoneNumber,
                Street = user.Street
            };
        }

        public void DeleteUser(PharmacyContext context, int id)
        {
            pharmacyRepository.DeleteUser(context, id);
        }

        public void DeleteMedicine(PharmacyContext context, int medicineId)
        {
            pharmacyRepository.DeleteMedicine(context, medicineId);
        }
    }
}
