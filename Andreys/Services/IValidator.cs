using System.Collections.Generic;

using Andreys.Models.Users;

namespace Andreys.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUserRegistration(RegisterUserFormModel model);
    }
}
