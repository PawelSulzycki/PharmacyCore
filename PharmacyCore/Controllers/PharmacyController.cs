using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyCore.Dtos;
using PharmacyCore.Repositories;
using PharmacyCore.DBContexts;
using PharmacyCore.Services;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            
            CreateMedicineDto medicine = new CreateMedicineDto()
            {
                DataExpiration = new DateTime(2017, 10, 1),
                Manufacturer = "cos",
                Name = "name",
                Perscription = true,
                Price = 20,
                Refunded = true,
                StorageMethod = "cos",
                Use = "cos"
            };

            
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
