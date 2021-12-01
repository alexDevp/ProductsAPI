
using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductsAPI.ProductData
{
    public class MockProductData : IProductData
    {
        private List<Product> products = new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = "Smartphone X",
                Stock = 10,
                Price = 250,
                Description = "Smartphone grande com 2 camaras.",
                Specifications = "Resol 5x5",
                FlagActive = true,
                Category = "Smartphones"
            },

            new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = "Smartphone Y",
                Stock = 10,
                Price = 750,
                Description = "Smartphone grande com 4 camaras.",
                Specifications = "Resol 10x10",
                FlagActive = true,
                Category = "Smartphones"
            },

            new Product()
            {
                Id = Guid.NewGuid(),
                ProductName = "Smartphone Z",
                Stock = 10,
                Price = 1250,
                Description = "Smartphone grande com 6 camaras.",
                Specifications = "Resol 20x20",
                FlagActive = true,
                Category = "Smartphones"
            }
        };

        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            products.Add(product);
            return product;
        }

        public void DeleteProduct(Product product)
        {
            products.Remove(product);
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = GetProduct(product.Id);
            existingProduct.ProductName = product.ProductName;
            existingProduct.Stock = product.Stock;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.Specifications = product.Specifications;
            existingProduct.FlagActive = product.FlagActive;
            existingProduct.Category = product.Category;
            return existingProduct;
        }

        public Product GetProduct(Guid id)
        {
            return products.SingleOrDefault(x => x.Id == id);
        }

        public List<Product> GetProductByCategory(string category)
        {
            //return products.Where(x => x.Category == category);
            return null;
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}
