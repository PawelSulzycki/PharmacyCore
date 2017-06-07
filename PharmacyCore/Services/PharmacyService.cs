using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Repositories;
using PharmacyCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                viewModel.Add(new MedicineViewModel(m.Id,m.Name, m.Manufacturer, m.DataExpiration));
            }

            return viewModel;
        }

        public IEnumerable<MedicineViewModel> GetMedicineViewModel(PharmacyContext context, ConditionsMedicinesListDto dto)
        {
            var medicineDto = pharmacyRepository.GetMedicine(context, dto);
            var viewModel = new List<MedicineViewModel>();
            foreach (var m in medicineDto)
            {
                viewModel.Add(new MedicineViewModel(m.Id,m.Name, m.Manufacturer, m.DataExpiration));
            }

            return viewModel;
        }

        public MedicineDto GetMedicineById(PharmacyContext context, int id)
        {
            return pharmacyRepository.GetMedicineById(context, id);
        }
    }
}
