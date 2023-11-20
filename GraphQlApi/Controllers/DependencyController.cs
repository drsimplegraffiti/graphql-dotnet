using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQlApi.Enitities;
using GraphQlApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GraphQlApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DependencyController : ControllerBase
    {


        [HttpGet(Name = "GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var services = this.HttpContext.RequestServices;
            var productService = (IProductService)services.GetService(typeof(IProductService))!;
            var products = await productService.GetAllProducts();

            return Ok(products);
        }


        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var services = this.HttpContext.RequestServices;
            var productService = (IProductService)services.GetService(typeof(IProductService))!;
            var product = await productService.GetProductDetailByIdAsync(id);

            return Ok(product);
        }


        [HttpPost(Name = "AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDetails productDetails)
        {
            var services = this.HttpContext.RequestServices;
            var productService = (IProductService)services.GetService(typeof(IProductService))!;
            var result = await productService.AddProductAsync(productDetails);
            return Ok(result);
        }

        [HttpPut(Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductDetails productDetails)
        {
            var services = this.HttpContext.RequestServices;
            var productService = (IProductService)services.GetService(typeof(IProductService))!;
            var result = await productService.UpdateProductAsync(productDetails);
            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var services = this.HttpContext.RequestServices;
            var productService = (IProductService)services.GetService(typeof(IProductService))!;
            var result = await productService.DeleteProductAsync(id);
            return Ok(result);
        }




    }
}