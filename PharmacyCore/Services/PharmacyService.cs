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
                viewModel.Add(new MedicineViewModel(m.Id, m.Name, m.Manufacturer, m.DataExpiration, m.Refunded, m.Perscription, m.StorageMethod));
            }

            return viewModel;
        }

        public IEnumerable<MedicineViewModel> GetMedicineViewModel(PharmacyContext context, ConditionsMedicinesListDto dto)
        {
            var medicineDto = pharmacyRepository.GetMedicine(context, dto);
            var viewModel = new List<MedicineViewModel>();
            foreach (var m in medicineDto)
            {
                viewModel.Add(new MedicineViewModel(m.Id, m.Name, m.Manufacturer, m.DataExpiration, m.Refunded, m.Perscription, m.StorageMethod));
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
    }
}
