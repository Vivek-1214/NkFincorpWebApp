using NkFincorpWebApp.DAL;
using NkFincorpWebApp.Models;

namespace NkFincorpWebApp.BAL
{
    public interface ICustomersRepository
    {
        public List<Position> GetAllPositions();
         public void CreateCustomer(CustomersRegistrationVM RegistrationVm);
       public List<MaritalStatus> GetMaritalStatus();
       public List<CustomersRegistrationVM> GetAllCustomers();
         public void DeleteCustomer(int id);
        public Customer GetCustomer(int id);

        CustomersUpdateVM GetSingleCustomer(int id);

        void UpdateCustomer(CustomersUpdateVM updateVM);


    }
}
