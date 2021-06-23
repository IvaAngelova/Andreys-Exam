using System.Collections.Generic;

using Andreys.Models.Products;
using Andreys.Models.Users;

namespace Andreys.Services
{
    public interface IValidator
    {
        ICollection<string> ValidateUserRegistration(RegisterUserFormModel model);

        ICollection<string> ValidateAddProduct(AddProductViewModel model);
    }
}
