using Pass_It_Out.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Pass_It_Out.View_Models
{
    public class UserVM
    {
        [Required (ErrorMessage ="User Id cannot be empty!!!")]
        [UniqueUser(ErrorMessage = "User Id is already taken.")]
        public String UserId { get; set; }

        [Required (ErrorMessage ="First Name should have less than 20 charecters!!!")]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name should have less than 20 charecters!!!")]
        [MaxLength(20)]
        public string LastName { get; set; }

        //[Required (ErrorMessage ="Email cannot be empty!!!")]
        //public string Email { get; set; }
        public string Location { get; set; }

        [Required ]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { set; get; }
    }
}
