using Pass_It_Out.Services.UserServices;
using System.ComponentModel.DataAnnotations;
using Pass_It_Out.Models;
namespace Pass_It_Out.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class UniqueUserAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userService = (IUser)validationContext.GetService(typeof(IUser));
            var user = new User();
            user.UserId = (string)value;
            if (userService.IsUserExit(user))
            {
                return new ValidationResult("User Id is already taken.");
            }
            return ValidationResult.Success;

        }
    }

}
