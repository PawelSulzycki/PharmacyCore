using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyCore.DBContexts;
using PharmacyCore.Services;
using PharmacyCore.Dtos;

namespace PharmacyCore.Controllers
{
    public class UserController : Controller
    {
        private static int _userId;
        private readonly PharmacyContext _context;
        private readonly PharmacyService _pharmacyService;

        public UserController(PharmacyContext context)
        {
            _context = context;
            _pharmacyService = new PharmacyService();
        }

        public ActionResult Home(int UserId)
        {
            _userId = UserId;
            return View();
        }

        public ActionResult ListOfMedicine()
        {
            var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ListOfMedicine([Bind(Prefix = "ConditionsMedicinesListDto")] ConditionsMedicinesListDto dto)
        {
            var viewModel = _pharmacyService.GetMedicineViewModel(_context, dto);
            return View(viewModel);
        }

        public ActionResult CreateOrder()
        {
            var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrder([Bind(Prefix = "OrderDto")] OrderDto dto)
        {
            var medicine = _pharmacyService.GetMedicineById(_context, dto.MedicineId);
            if (dto.DeliveryMethod == "Wysylka" && medicine.StorageMethod == "Warunki chlodnicze")
            {
                ViewBag.Error = "Odbiór tylko osobisty, poniewa¿ lek jest przechowywany w warunkach chlodniczych";
                var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
                return View(viewModel);
            }
            else if (dto.DeliveryMethod == "Wysylka" && medicine.Perscription == true)
            {
                ViewBag.Error = "Odbiór tylko osobisty, poniewa¿ jest potrzebne okazanie recepty";
                var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
                return View(viewModel);
            }
            dto.UserID = _userId;
            dto.DataOfOrder = DateTime.Now;
            dto.StatusOfOrder = "Zamówienie w czasie realizacji";
            _pharmacyService.CreateOrder(dto, _context);
            return View("Successful");
        }
    }
}