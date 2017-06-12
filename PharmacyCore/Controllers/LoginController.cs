using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyCore.Dtos;
using PharmacyCore.DBContexts;
using PharmacyCore.Services;

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
        public ActionResult Login([Bind(Prefix ="LoginDto")] LoginDto dto)
        {
            if(dto.Name=="Admin" && dto.Password == "Admin")
            {
                return RedirectToAction("Home", "Admin");
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