using System;
using System.ComponentModel.DataAnnotations;

namespace Andreys.Data.Models
{
    public class Product
    {
        [Key]
        [Required]
        public string Id { get; set; }
           = Guid.NewGuid().ToString();

        [Required]
        [MinLength(DataConstants.ProductNameMinLength)]
        [MaxLength(DataConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
