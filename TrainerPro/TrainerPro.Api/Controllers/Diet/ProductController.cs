using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainerPro.Core.DTOs;
using TrainerPro.Services.Interfaces;

namespace TrainerPro.Api.Controllers.Diet
{
    //[Authorize]
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

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

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

        [HttpPut]
        public async Task<ActionResult> PutProductAsync([FromBody] AddProductDTO model)
        {
            var product = await _productService.UpdateProductAsync(model);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProductByIdAsync(int id)
        {
            await _productService.DeleteProductByIdAsync(id);

            return new ObjectResult("Product has been deleted.");
        }
    }
}
