using NkFincorpWebApp.DAL;
using NkFincorpWebApp.Models;

namespace NkFincorpWebApp.Utility
{
    public static class ExtensionDemo
    {
        
        public static void ConvertVm_To_DTO(this Customer Customer, CustomersRegistrationVM RegistrationVm)
        {
            Customer.Id = RegistrationVm.Id;
            Customer.Email = RegistrationVm.Email;
            Customer.FirstName = RegistrationVm.FirstName;
            Customer.LastName = RegistrationVm.LastName;
            Customer.PositionId = RegistrationVm.PositionId;
            Customer.Password = RegistrationVm.Password;
            Customer.MobileNumber = RegistrationVm.MobileNumber;
            Customer.AadharCard = RegistrationVm.AadharCard;
            Customer.City = RegistrationVm.City;
            Customer.MaritalStatus = RegistrationVm.MaritalStatus;
            Customer.TermsAndCondition = RegistrationVm.TermsAndCondition;

        }
        public static void ConvertVm_To_DTOforUpdate(this Customer Customer, CustomersUpdateVM UpdateVm)
        {
            
            Customer.FirstName = UpdateVm.FirstName;
            Customer.LastName = UpdateVm.LastName;
            Customer.PositionId = UpdateVm.PositionId;
            Customer.MobileNumber = UpdateVm.MobileNumber;
            Customer.AadharCard = UpdateVm.AadharCard;
            Customer.City = UpdateVm.City;
            Customer.MaritalStatus = UpdateVm.MaritalStatus;
    

        }
    }
}
