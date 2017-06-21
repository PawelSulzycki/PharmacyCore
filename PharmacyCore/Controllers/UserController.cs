using Microsoft.AspNetCore.Mvc;
using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Services;
using System;

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

        public ActionResult Index(int UserId)
        {
            _userId = UserId;
            return View();
        }

        public ActionResult Medicine()
        {
            var viewModel = _pharmacyService.GetAllMedicineForUserViewModel(_context);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Medicine([Bind(Prefix = "ConditionsMedicinesListDto")] ConditionsMedicinesListDto dto)
        {
            var viewModel = _pharmacyService.GetMedicineViewModel(_context, dto);
            return View(viewModel);
        }

        public ActionResult CreateOrder()
        {
            var viewModel = _pharmacyService.GetAllMedicineByUserViewModel(_context);
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
            dto.Price = dto.Quantity * medicine.Price;
            _pharmacyService.CreateOrder(dto, _context);
            return View("Successful");
        }

        public ActionResult Order()
        {
            var viewModel = _pharmacyService.GetAllOrderByUserIdViewModel(_context, _userId);
            return View(viewModel);
        }
    }
}