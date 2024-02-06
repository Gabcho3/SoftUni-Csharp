using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Infrastructure.Models;

namespace Web.Core.ViewModels
{
    public class CreateAdViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(250, MinimumLength = 15)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string OwnerId { get; set; } = null!;

        [Required]
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
