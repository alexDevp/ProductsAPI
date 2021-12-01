using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;
using ProductsAPI.ProductData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecuringWebApiUsingApiKey.Attributes;

namespace ProductsAPI.Controllers
{
    [ApiKey]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductData _productData;

        public ProductsController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetProducts()
        {
            return Ok(_productData.GetProducts());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetProduct(Guid id)
        {

            var product = _productData.GetProduct(id);

            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound($"Produto com o Id: {id} não foi encontrado!");
            }
            
        }

        [HttpGet]
        [Route("api/[controller]/category/{category}")]
        public IActionResult GetProductByCategory(String category)
        {

            var product = _productData.GetProductByCategory(category);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound($"A Categoria: {category} não foi encontrada!");
            }

        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult CreateProduct(Product product)
        {
            _productData.AddProduct(product);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + product.Id, product);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _productData.GetProduct(id);
            
            if(product != null)
            {
                _productData.DeleteProduct(product);
                return Ok();
            }

            return NotFound($"Produto com o Id: {id} não foi encontrado!");
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult EditProduct(Guid id, Product product)
        {
            var existingProduct = _productData.GetProduct(id);

            if (existingProduct != null)
            {
                product.Id = existingProduct.Id;
                _productData.EditProduct(product);
                
            }

            return Ok(product);
        }

    }
}
