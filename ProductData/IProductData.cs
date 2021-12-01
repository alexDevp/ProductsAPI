using ProductsAPI.Models;
using System;
using System.Collections.Generic;


namespace ProductsAPI.ProductData
{
    public interface IProductData
    {
        List<Product> GetProducts();

        Product GetProduct(Guid id);

        List<Product> GetProductByCategory(string category);

        Product AddProduct(Product product);

        Product EditProduct(Product product);

        void DeleteProduct(Product product);
    }

}
