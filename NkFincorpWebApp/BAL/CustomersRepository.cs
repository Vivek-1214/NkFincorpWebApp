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

        }
    }
}
