using Microsoft.AspNetCore.Mvc;
using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Services;

namespace PharmacyCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly PharmacyContext _context;
        private readonly PharmacyService _pharmacyService;

        public AdminController(PharmacyContext context)
        {
            _context = context;
            _pharmacyService = new PharmacyService();
        }

        public ActionResult Home()
        {
            var viewModel = _pharmacyService.GetAllUser(_context);
            return View(viewModel);
        }

        public ActionResult CreateUser()
        {
            var viewModel = _pharmacyService.GetCreateUserViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateUser([Bind(Prefix = "UserDto")] UserDto dto)
        {
            if (ModelState.IsValid)
            {
                _pharmacyService.CreateUser(dto, _context);
                return RedirectToAction("Home");
            }
            return View("CreateUser");
        }
    }
}