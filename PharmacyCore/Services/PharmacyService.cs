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
                viewModel.Add(new MedicineViewModel {
                    Id= m.Id,
                    DataExpiration =m.DataExpiration,
                    Manufacturer =m.Manufacturer,
                    Name = m.Name,
                    Perscription = m.Perscription,
                    Refunded = m.Refunded,
                    StorageMethod = m.StorageMethod,
                    Quantity = m.Quantity
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
                    StorageMethod = m.StorageMethod
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
                    Name = item.Name,
                    Surname = item.Surname,
                    Login = item.Login,
                    Role = item.Role,
                    PhoneNumber = item.PhoneNumber
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

        public UserDto GetUserByNameAndPassword(PharmacyContext context, string name, string password)
        {
            return pharmacyRepository.GetUserByNameAndPassword(context, name, password);
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
                    Name= medicine.Name,
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
                    Name = m.Name
                });
            }

            return viewModel;
        }

        public void UpdateQuantityInMedicine(PharmacyContext context, int quantity, int medicineId)
        {
            pharmacyRepository.UpdateQuantityInMedicine(context, quantity, medicineId);
        }
    }
}
