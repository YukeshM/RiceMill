using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserViewModel
    {

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "First name cannot be greater than 100")]
        public string FirstName
        {
            get; set;
        }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(25, ErrorMessage = "Last name cannot be greater than 25")]
        public string LastName
        {
            get; set;
        }

        [Required(ErrorMessage = "Age is required")]
        public int Age
        {
            get; set;
        }

        [Required(ErrorMessage = "Gender is required")]
        public int GenderId
        {
            get; set;
        }

        [Required(ErrorMessage = "Phone number is required")]

        public string PhoneNumber
        {
            get; set;
        }

        [Required(ErrorMessage = "Email is required")]

        public string Email
        {
            get; set;
        }

        [Required(ErrorMessage = "Password is required")]

        public string PasswordHash
        {
            get; set;
        }
    }
}
