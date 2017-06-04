using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyCore.Dtos;
using PharmacyCore.Repositories;
using PharmacyCore.DBContexts;

namespace PharmacyCore.Controllers
{
    public class PharmacyController : Controller
    {
        private readonly PharmacyContext _context;
        private readonly PharmacyRepository pharmacyRepository = new PharmacyRepository();

        public PharmacyController(PharmacyContext context)
        {
            _context = context;
        }

        public ActionResult CreateMedicine([Bind(Prefix = "CreateBoardFormDto")] CreateMedicineDto dto)
        {
            return RedirectToAction("Index");
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

            
            pharmacyRepository.AddMedicine(medicine, _context);

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
