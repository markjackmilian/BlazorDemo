using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Models
{
    public class User
    {
        [Required, Display(Name = "First Name")]
        public string FirstName { get; set; } = "Saachi";

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; } = "Roye";

        [Required, Display(Name = "Email Address"), EmailAddress, RegularExpression("@domain=methodist.org")]
        public string EmailAddress { get; set; }

        [Required, Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required, Display(Name = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Display(Name = "Re-enter your Password"), DataType(DataType.Password), Compare("Password")]
        public string ComparePassword { get; set; }

        [Required, Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
    }
}
