using System.Linq;
using System.Collections.Generic;

using Andreys.Data;
using Andreys.Models.Users;

namespace Andreys.Services
{
    public class Validator : IValidator
    {
        public ICollection<string> ValidateUserRegistration(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < DataConstants.UsernameMinLength
                || model.Username.Length > DataConstants.UsernameMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid! It must be between {DataConstants.UsernameMinLength} and { DataConstants.UsernameMaxLength}.");
            }

            if (model.Password.Length < DataConstants.PassowrdMinLength
                || model.Username.Length > DataConstants.PassowrdMaxLength)
            {
                errors.Add($"The provided password is not valid! It must be between {DataConstants.PassowrdMinLength} and {DataConstants.PassowrdMaxLength}.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add($"The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add($"Parssword and its confirmation are different.");
            }

            return errors;
        }
    }
}
