using Microsoft.AspNetCore.Mvc;
using NkFincorpWebApp.BAL;
using NkFincorpWebApp.DAL;
using NkFincorpWebApp.Models;

namespace NkFincorpWebApp.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            CustomersRepository CustomersRepository = new CustomersRepository();
           var customers= CustomersRepository.GetAllCustomers();

            return View(customers);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            CustomersRegistrationVM RegistrationVm = new CustomersRegistrationVM();

            CustomersRepository CustomersRepository = new CustomersRepository();
            ViewBag.AllPosition = CustomersRepository.GetAllPositions();
            ViewBag.maritalstatus = CustomersRepository.GetMaritalStatus();

            return View(RegistrationVm);
        }

        [HttpPost]
        public IActionResult Registration(CustomersRegistrationVM RegistrationVm)
        {
               

            CustomersRepository CustomersRepository = new CustomersRepository();

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
            CustomersRepository CustomersRepository = new CustomersRepository();
            CustomersRepository.DeleteCustomer(id);
            return RedirectToAction("Index"); ;
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            CustomersRegistrationVM RegistrationVm = new CustomersRegistrationVM();
           
            CustomersRepository CustomersRepository = new CustomersRepository();
          var customer =  CustomersRepository.GetSingleCustomer(id);
            CustomersRegistrationVM registrationVM = new CustomersRegistrationVM();


            ViewBag.AllPosition = CustomersRepository.GetAllPositions();
            ViewBag.maritalstatus = CustomersRepository.GetMaritalStatus();

            return View(RegistrationVm);
        }

    }
}
