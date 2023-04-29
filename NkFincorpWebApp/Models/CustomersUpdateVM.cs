using Microsoft.AspNetCore.Mvc;
using NkFincorpWebApp.DAL;
using System.ComponentModel.DataAnnotations;

namespace NkFincorpWebApp.Models
{
    public class CustomersUpdateVM
    {
        public CustomersUpdateVM()
        {

        }
        public CustomersUpdateVM(Customer Customer)
        {
           
            this.FirstName = Customer.FirstName;
            this.LastName = Customer.LastName;
            this.PositionId = Customer.PositionId;
          
            this.MobileNumber = Customer.MobileNumber;
            this.AadharCard = Customer.AadharCard;
            this.City = Customer.City;
            this.MaritalStatus = Customer.MaritalStatus;
        }



 


        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public string? Position { get; set; }

        [Required]
        public int? PositionId { get; set; }
        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Mobile number is not valid")]

        public string? MobileNumber { get; set; }
     

     
        [Required]
        [RegularExpression(@"/(^[0-9]{4}[0-9]{4}[0-9]{4}$)|(^[0-9]{4}\s[0-9]{4}\s[0-9]{4}$)|(^[0-9]{4}-[0-9]{4}-[0-9]{4}$)/", ErrorMessage = "formate of adhar no is invalid")]
        public string? AadharCard { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? MaritalStatus { get; set; }
        
    }
}
