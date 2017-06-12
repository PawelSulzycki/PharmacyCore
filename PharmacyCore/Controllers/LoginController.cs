using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PharmacyCore.Dtos;

namespace PharmacyCore.Controllers
{
    public class LoginController : Controller
    {
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
    }
}