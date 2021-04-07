using HBCase.Business.Interface;
using HBCase.Entity;
using Microsoft.AspNetCore.Mvc;

namespace HBCase.API.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("get_product_info")]
        public IActionResult Get(string productCode)
        {
            if (productCode == null)
            {
                return BadRequest();
            }
            var result = _productService.Get(productCode);
            return Ok(result);
        }

        [HttpPost("create_product")]
        public IActionResult Create(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }
            var result = _productService.Create(product);
            return Ok(result);
        }
    }
}