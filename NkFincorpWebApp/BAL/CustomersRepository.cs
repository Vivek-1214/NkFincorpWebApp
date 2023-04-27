using NkFincorpWebApp.DAL;
using NkFincorpWebApp.Models;
using Microsoft.EntityFrameworkCore;
using NkFincorpWebApp.Utility;

namespace NkFincorpWebApp.BAL
{
    public class CustomersRepository: ICustomersRepository
    {
        private readonly NkFincorpMvcprojectContext database;
     
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
            customer.InsertDetails(RegistrationVm);


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

           List<Customer> customers = db.Customers.Include(C => C.Position).ToList();

            List<CustomersRegistrationVM> CustomersRegistrationVM = new List<CustomersRegistrationVM>();
            foreach (var Customer in customers)
            {
                CustomersRegistrationVM registrationVM = new CustomersRegistrationVM(Customer);
              

                CustomersRegistrationVM.Add(registrationVM);
            }

            return CustomersRegistrationVM;
        }
        public void DeleteCustomer(int id)
        {
            NkFincorpMvcprojectContext db = new NkFincorpMvcprojectContext();
            // var customer = db.Customers.Find(id);    old method
            var singleCustomer= GetSingleCustomer(id);

            if (singleCustomer != null)
            {
                db.Customers.Remove(singleCustomer);
                db.SaveChanges();
            }
        }

    public Customer GetSingleCustomer(int id)
        {
            NkFincorpMvcprojectContext db = new NkFincorpMvcprojectContext();
          var customer= db.Customers.FirstOrDefault(C => C.Id == id);

            return customer;
        }

    }
}
