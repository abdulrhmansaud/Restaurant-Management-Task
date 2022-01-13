using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant_Management_Task.Dtos
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "Email is needed.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }
        [Required]
        [StringLength(8,MinimumLength=6,ErrorMessage ="the password shuold be more than 6")]
        public string password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is needed.")]
        public string Moblie { get; set; }

    }
}
