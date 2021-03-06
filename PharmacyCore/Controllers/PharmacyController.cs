﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyCore.Dtos;
using PharmacyCore.Repositories;
using PharmacyCore.DBContexts;
using PharmacyCore.Services;
using Microsoft.AspNetCore.Authorization;

namespace PharmacyCore.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly PharmacyContext _context;
        private readonly PharmacyService _pharmacyService;

        public PharmacyController(PharmacyContext context)
        {
            _context = context;
            _pharmacyService = new PharmacyService();
        }

        public ActionResult CreateMedicine()
        {
            var viewModel = _pharmacyService.GetCreateMedicineViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateMedicine([Bind(Prefix = "CreateMedicineDto")] CreateMedicineDto dto)
        {
            if (ModelState.IsValid)
            {
                _pharmacyService.CreateMedicine(dto, _context);
            }
            return RedirectToAction("CreateMedicine");
        }

        public ActionResult Show()
        {
            var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Show([Bind(Prefix = "ConditionsMedicinesListDto")] ConditionsMedicinesListDto dto)
        {
            var viewModel = _pharmacyService.GetMedicineViewModel(_context, dto);
            return View(viewModel);
        }

        public ActionResult Shop()
        {
            var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Shop([Bind(Prefix = "ShopDto")] ShopDto dto)
        {
            var medicine = _pharmacyService.GetMedicineById(_context, dto.IdMedicine);
            if (dto.DeliveryMethod == "Wysylka" && medicine.StorageMethod== "Warunki chlodnicze")
            {
                ViewBag.Error = "Odbiór tylko osobisty, ponieważ lek jest przechowywany w warunkach chlodniczych";
                var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
                return View(viewModel);
            }else if(dto.DeliveryMethod == "Wysylka" && medicine.Perscription == true)
            {
                ViewBag.Error = "Odbiór tylko osobisty, ponieważ jest potrzebne okazanie recepty";
                var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
                return View(viewModel);
            }
            return View("Successful");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            
            //CreateMedicineDto medicine = new CreateMedicineDto()
            //{
            //    DataExpiration = new DateTime(2017, 10, 1),
            //    Manufacturer = "cos",
            //    Name = "name",
            //    Perscription = true,
            //    Price = 20,
            //    Refunded = true,
            //    StorageMethod = "cos",
            //    Use = "cos"
            //};

            
            //pharmacyRepository.AddMedicine(medicine, _context);

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
