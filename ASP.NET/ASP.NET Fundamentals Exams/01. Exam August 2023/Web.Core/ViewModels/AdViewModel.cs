﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core.ViewModels
{
    public class AdViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public string Owner { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}
