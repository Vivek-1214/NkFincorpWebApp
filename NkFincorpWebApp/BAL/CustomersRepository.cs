using NkFincorpWebApp.DAL;
using NkFincorpWebApp.Models;
using Microsoft.EntityFrameworkCore;
using NkFincorpWebApp.Utility;

namespace NkFincorpWebApp.BAL
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly NkFincorpMvcprojectContext db;
        public CustomersRepository(NkFincorpMvcprojectContext _db)
        {
            this.db = _db;
        }
        public List<Position> GetAllPositions()
        {

            var positions = db.Positions.ToList();

            return positions;
        }

        public void CreateCustomer(CustomersRegistrationVM RegistrationVm)
        {


            Customer customer = new Customer();
            customer.ConvertVm_To_DTO(RegistrationVm);


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
            // var customer = db.Customers.Find(id);    old method
            var singleCustomer = GetCustomer(id);

            if (singleCustomer != null)
            {
                db.Customers.Remove(singleCustomer);
                db.SaveChanges();
            }
        }

        public Customer GetCustomer(int id)
        {

            var customer = db.Customers.FirstOrDefault(C => C.Id == id);

            return customer;
        }

        public CustomersUpdateVM GetSingleCustomer(int id)
        {

            var customer = db.Customers.Find(id);
            CustomersUpdateVM UpdateVM = null;
            if (customer != null)
            {
                UpdateVM = new CustomersUpdateVM(customer);
            }
            return UpdateVM;




        }

        public void UpdateCustomer(CustomersUpdateVM updateVM)
        {
             var customer=db.Customers.Find(updateVM);
            if (customer != null)
            {

                customer.FirstName = updateVM.FirstName;
                customer.LastName = updateVM.LastName;
                customer.PositionId= updateVM.PositionId;
                customer.MobileNumber = updateVM.MobileNumber;
                customer.AadharCard= updateVM.AadharCard;
                customer.City= updateVM.City;
                customer.MaritalStatus= updateVM.MaritalStatus;

                db.Update(customer);
                db.SaveChanges();
            }

        }

          
    }
}
