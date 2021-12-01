using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = "Max 50 Chars!")]
        public string ProductName { get; set; }

        public int Stock { get; set; }

        public int Price { get; set; }

        [MaxLength(10000, ErrorMessage = "Max 10000 Chars!")]
        public string Description { get; set; }

        [MaxLength(10000, ErrorMessage = "Max 10000 Chars!")]
        public string Specifications { get; set; }

        [MaxLength(10000, ErrorMessage = "Max 10000 Chars!")]
        public string Image { get; set; }

        public bool FlagActive { get; set; }

        public string Category { get; set; }

    }
}
