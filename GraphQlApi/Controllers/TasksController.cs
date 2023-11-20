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
    public class TasksController : ControllerBase
    {
        private readonly IProductService productService;

        public TasksController(IProductService productService)
        {
            this.productService = productService;
        }

        /// <summary>
        /// Get All Products using Task
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsingTask()
        {
            return Ok(await productService.ProductListAsync());
        }


        /// <summary>
        /// Create Product using Task
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUsingTask([FromBody] ProductDetails productDetails)
        {
            await productService.CreateUsingTask(productDetails);
            return Ok("Product Created Successfully");
        }
    }

}