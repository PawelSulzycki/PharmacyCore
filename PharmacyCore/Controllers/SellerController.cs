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
    public class SellerController : Controller
    {
        private readonly PharmacyContext _context;
        private readonly PharmacyService _pharmacyService;

        public SellerController(PharmacyContext context)
        {
            _context = context;
            _pharmacyService = new PharmacyService();
        }
        public ActionResult Index()
        {
            var viewModel = _pharmacyService.GetAllOrderViewModel(_context);
            return View(viewModel);
        }

        public ActionResult DoneOrder(int orderId, int quantity)
        {
            _pharmacyService.DoneOreder(_context, orderId, quantity);
            return RedirectToAction("Index");
        }

        public ActionResult Information(int id)
        {
            var viewModel = _pharmacyService.InformationSellerViewModel(_context, id);
            return View(viewModel);
        }
    }
}