using ProductsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsAPI.ProductData
{
    public class SqlProductData : IProductData
    {
        private ProductContext _productContext;

        public SqlProductData(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public Product AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(Product product)
        {
           _productContext.Products.Remove(product);
            _productContext.SaveChanges();
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = _productContext.Products.Find(product.Id);
            if(existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.Stock = product.Stock;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                existingProduct.Specifications = product.Specifications;
                existingProduct.FlagActive = product.FlagActive;
                existingProduct.Category = product.Category;
                existingProduct.Image = product.Image;
                _productContext.Products.Update(existingProduct);
                _productContext.SaveChanges();
            }
            
            return product;
        }

        public Product GetProduct(Guid id)
        {
            var product = _productContext.Products.Find(id);
            return product;
        }

        public List<Product> GetProductByCategory(string category)
        {
            return _productContext.Products.Where(a => a.Category == category).ToList();          
        }

        public List<Product> GetProducts()
        {
            return _productContext.Products.ToList();
        }
    }
}
