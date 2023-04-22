using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NkFincorpWebApp.Models
{
    public class CustomersRegistrationVM
    {
        public int Id { get; set; }
        [Required]
       
        public string? Email { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [Required]
        public int? PositionId { get; set; }
        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Mobile number is not valid")]
        public string? MobileNumber { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and confirm password is not matched")]
        [Display(Name = "Confirm Password")]
        public string? ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"/(^[0-9]{4}[0-9]{4}[0-9]{4}$)|(^[0-9]{4}\s[0-9]{4}\s[0-9]{4}$)|(^[0-9]{4}-[0-9]{4}-[0-9]{4}$)/",ErrorMessage ="formate of adhar no is invalid")]
        public string? AadharCard { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? MaritalStatus { get; set; }
        [Required]
        public bool? TermsAndCondition { get; set; }
    }
}
