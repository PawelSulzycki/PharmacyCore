using Microsoft.AspNetCore.Mvc;
using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Services;

namespace PharmacyCore.Controllers
{
    public class SupplierController : Controller
    {
        private readonly PharmacyContext _context;
        private readonly PharmacyService _pharmacyService;

        public SupplierController(PharmacyContext context)
        {
            _context = context;
            _pharmacyService = new PharmacyService();
        }

        public ActionResult Index()
        {
            var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
            return View(viewModel);
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
            return RedirectToAction("Index");
        }

        public ActionResult AddQuantity()
        {
            var viewModel = _pharmacyService.GetAllMedicineViewModel(_context);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddQuantity([Bind(Prefix = "QuantityDto")] QuantityDto dto)
        {
            _pharmacyService.UpdateQuantityInMedicine(_context, dto.Quantity, dto.MedicineId);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteMedicine(int id)
        {
            _pharmacyService.DeleteMedicine(_context, id);
            return RedirectToAction("Index");
        }
    }
}