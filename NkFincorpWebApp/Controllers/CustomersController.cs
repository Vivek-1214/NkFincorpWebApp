using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

using NkFincorpWebApp.BAL;
using NkFincorpWebApp.DAL;
using NkFincorpWebApp.Models;

namespace NkFincorpWebApp.Controllers
{
    public class CustomersController : Controller
    {
      private readonly ICustomersRepository CustomersRepository;
        public CustomersController(ICustomersRepository _customerRepository)
        {
            this.CustomersRepository = _customerRepository;
        }
        public IActionResult Index()
        {
           
           var customers= CustomersRepository.GetAllCustomers();

            return View(customers);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            CustomersRegistrationVM RegistrationVm = new CustomersRegistrationVM();


            ViewBag.AllPosition = CustomersRepository.GetAllPositions();
            ViewBag.maritalstatus = CustomersRepository.GetMaritalStatus();

            return View(RegistrationVm);
        }

        [HttpPost]
        public IActionResult Registration(CustomersRegistrationVM RegistrationVm)
        {
               

           

            if(RegistrationVm.TermsAndCondition == false)
            {
                ModelState.AddModelError("TermsAndCondition", "please accept terms and conditions");
            }

            if (RegistrationVm.MaritalStatus == null)
            {
                ModelState.AddModelError("MaritalStatus", "please select MaritalStatus");
            }



            if (ModelState.IsValid == true)
            {
                CustomersRepository.CreateCustomer(RegistrationVm);

                return RedirectToAction("Index");
            }

            ViewBag.AllPosition = CustomersRepository.GetAllPositions();
            ViewBag.maritalStatus = CustomersRepository.GetMaritalStatus();

            return View(RegistrationVm);
        }

        public IActionResult IsEmailValid(String email)
        {
            NkFincorpMvcprojectContext db = new NkFincorpMvcprojectContext();
            var EmailIsPresent = db.Customers.Any(C => C.Email == email);
            if (EmailIsPresent == true)
            {
                return Json("thise Email is Already used enter another Email..");
            }
            else
            {
                return Json(true);
            }
        }

        public IActionResult Delete(int id)
        {
           
            CustomersRepository.DeleteCustomer(id);
            return RedirectToAction("Index"); ;
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var customerVm =  CustomersRepository.GetSingleCustomer(id);

               ViewBag.AllPosition = CustomersRepository.GetAllPositions();
            ViewBag.maritalstatus = CustomersRepository.GetMaritalStatus();

            return View(customerVm);
        }
        [HttpPost]
        public IActionResult Update(CustomersUpdateVM updateVM)
        {
            if (ModelState.IsValid == true) {

               CustomersRepository.UpdateCustomer(updateVM);
            }
           

            ViewBag.AllPosition = CustomersRepository.GetAllPositions();
            ViewBag.maritalstatus = CustomersRepository.GetMaritalStatus();

            return View(updateVM);
        }

    }
}
