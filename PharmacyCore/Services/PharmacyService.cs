﻿using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Repositories;
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
    }
}
