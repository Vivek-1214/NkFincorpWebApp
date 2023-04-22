using Microsoft.AspNetCore.Mvc;
using NkFincorpWebApp.BAL;
using NkFincorpWebApp.Models;

namespace NkFincorpWebApp.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            CustomersRegistrationVM RegistrationVm = new CustomersRegistrationVM();

            CustomersRepository CustomersRepository = new CustomersRepository();
            ViewBag.AllPosition = CustomersRepository.GetAllPositions();
          
            return View(RegistrationVm);
        }

        [HttpPost]
        public IActionResult Registration(CustomersRegistrationVM RegistrationVm)
        {
               

            CustomersRepository CustomersRepository = new CustomersRepository();
            CustomersRepository.CreateCustomer(RegistrationVm);

            ViewBag.AllPosition = CustomersRepository.GetAllPositions();
            ViewBag.maritalStatus = CustomersRepository.GetMaritalStatus();

            return View(RegistrationVm);
        }


    }
}
