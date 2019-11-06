using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Api.Controllers.Diet
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var products = await _productService.GetProductsAsync();
            if (products == null || products.Count() == 0)
                return new ObjectResult("There are no products") { StatusCode = 400 };

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(string id)
        {
            var product = await _productService.GetProductByNameAsync(id);

            if(product == null)
                return new ObjectResult("This product does not exist") { StatusCode = 400 };

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddProductDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.Values);
            try
            {
                await _productService.AddProductAsync(model);
            }
            catch (Exception e)
            {
                return Ok(new { message = e.Message });
            }
            return Ok();
        }
    }
}
