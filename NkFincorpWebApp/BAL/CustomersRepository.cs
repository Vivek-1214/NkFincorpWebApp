using NkFincorpWebApp.DAL;
using NkFincorpWebApp.Models;

namespace NkFincorpWebApp.BAL
{
    public class CustomersRepository
    {

        public List<Position> GetAllPositions()
        {
            NkFincorpMvcprojectContext db = new NkFincorpMvcprojectContext();
            var positions=db.Positions.ToList();

            return positions;
        }

        public void CreateCustomer(CustomersRegistrationVM RegistrationVm)
        {
            NkFincorpMvcprojectContext db = new NkFincorpMvcprojectContext();
            Customer customer = new Customer();
           
            customer.Email = RegistrationVm.Email;
            customer.FirstName = RegistrationVm.FirstName;
            customer.LastName = RegistrationVm.LastName;
            customer.PositionId = RegistrationVm.PositionId;
            customer.Password = RegistrationVm.Password;
            customer.MobileNumber = RegistrationVm.MobileNumber;
            customer.AadharCard = RegistrationVm.AadharCard;
            customer.City = RegistrationVm.City;
            customer.MaritalStatus = RegistrationVm.MaritalStatus;
            customer.TermsAndCondition = RegistrationVm.TermsAndCondition;

             db.Customers.Add(customer);
            db.SaveChanges();
        

        }
        public List<MaritalStatus> GetMaritalStatus()
        {
            List<MaritalStatus> maritalStatuses = new List<MaritalStatus>();

            MaritalStatus ms1 = new MaritalStatus();
            ms1.Id = 1;
            ms1.Text = "Married";
            MaritalStatus ms2 = new MaritalStatus();
            ms2.Id = 2;
            ms2.Text = "UnMarried";

            maritalStatuses.Add(ms1);
            maritalStatuses.Add(ms2);

            return maritalStatuses;

        }

        public List<CustomersRegistrationVM> GetAllCustomers()
        {
            NkFincorpMvcprojectContext db = new NkFincorpMvcprojectContext();
            var customers=db.Customers.ToList();

            List<CustomersRegistrationVM> CustomersRegistrationVM = new List<CustomersRegistrationVM>();
            foreach (var Customer in customers)
            {
                CustomersRegistrationVM registrationVM = new CustomersRegistrationVM();

                registrationVM.Email = Customer.Email;
                registrationVM.FirstName = Customer.FirstName;
                registrationVM.LastName = Customer.LastName;
                registrationVM.PositionId = Customer.PositionId;
                registrationVM.MobileNumber = Customer.MobileNumber;
                registrationVM.AadharCard = Customer.AadharCard;
                registrationVM.City = Customer.City;
                registrationVM.MaritalStatus = Customer.MaritalStatus;

                CustomersRegistrationVM.Add(registrationVM);
            }

            return CustomersRegistrationVM;
        }


    }
}
