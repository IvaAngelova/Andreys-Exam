using MyWebServer.Controllers;

using Andreys.Data;
using Andreys.Services;
using MyWebServer.Http;
using System.Linq;
using Andreys.Models.Products;
using Andreys.Data.Models;
using System;

namespace Andreys.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IValidator validator;
        private readonly AndreysDbContext contex;

        public ProductsController(IValidator validator, AndreysDbContext contex)
        {
            this.validator = validator;
            this.contex = contex;
        }


        [Authorize]
        public HttpResponse Add()
        {
            if (this.User.IsAuthenticated)
            {
                return View();
            }

            return Error("Only users can create repositories.");
        }

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddProductViewModel model)
        {
            var modelErrors = this.validator.ValidateAddProduct(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var product = new Product
            {
                Name= model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Category = (Category)Enum.Parse(typeof(Category), model.Category),
                Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender)
            };

            this.contex.Products.Add(product);
            this.contex.SaveChanges();

           return Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            var currentProduct = this.contex
                .Products
                .Where(p => p.Id == id)
                .Select(p => new ProductViewModel
                {
                    Id=p.Id,
                    Name = p.Name,
                    Description=p.Description,
                    ImageUrl = p.ImageUrl,
                    Price=p.Price,
                    Category = p.Category.ToString(),
                    Gender = p.Gender.ToString()
                })
                .FirstOrDefault();

            return View(currentProduct);
        }

        public HttpResponse Delete(string id)
        {
            var product = this.contex
                .Products
                .FirstOrDefault(p => p.Id == id);

            this.contex.Products.Remove(product);
            this.contex.SaveChanges();

            return Redirect("/");
        }
    }
}
