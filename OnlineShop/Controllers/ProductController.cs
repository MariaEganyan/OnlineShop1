using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;
using OnlineShop.Services;
using Serilog;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
               return Ok(_productService.GetProducts());
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex);
            }
        }
        [HttpGet("{ID}")]
        public IActionResult GetbyId(int id)
        {
            try
            {
                return Ok(_productService.GetProductByID(id));
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            try
            {
                _productService.AddProduct(product);
                return Ok(_productService.GetProducts());
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _productService.DeleteById(id);
                return Ok(_productService.GetProducts());
            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
                return BadRequest(ex);
            }
        }
    }
}