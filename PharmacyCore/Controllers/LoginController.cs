using Microsoft.AspNetCore.Mvc;
using PharmacyCore.DBContexts;
using PharmacyCore.Dtos;
using PharmacyCore.Services;
using System;

namespace PharmacyCore.Controllers
{
    public class LoginController : Controller
    {
        private readonly PharmacyContext _context;
        private readonly PharmacyService _pharmacyService;

        public LoginController(PharmacyContext context)
        {
            _context = context;
            _pharmacyService = new PharmacyService();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Prefix = "LoginDto")] LoginDto dto)
        {
            try
            {
                var user = _pharmacyService.GetUserByNameAndPassword(_context, dto.Name, dto.Password);
                if (user.Role == "Uzytkownik")
                {
                    return RedirectToAction("Index", "User", new { UserId = user.Id });
                }
                else if (user.Role == "Dostawca")
                {
                    return RedirectToAction("Index", "Supplier");
                }
                else if (user.Role == "Sprzedawca")
                {
                    return RedirectToAction("Index", "Seller");
                }
            }
            catch (InvalidOperationException exception)
            {
                if (dto.Name == "Admin" && dto.Password == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }

            }
            return View();
        }

        public ActionResult CreateUser()
        {
            var viewModel = _pharmacyService.GetCreateUserViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateUser([Bind(Prefix = "UserDto")] UserDto dto)
        {
            dto.Role = "Uzytkownik";
            if (ModelState.IsValid)
            {
                _pharmacyService.CreateUser(dto, _context);
                return RedirectToAction("Login");
            }
            return View("CreateUser");
        }
    }
}