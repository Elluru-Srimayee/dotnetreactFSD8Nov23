using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shopping_App.Exceptions;
using Shopping_App.Interfaces;
using Shopping_App.Models;
using System.Net.Mime;

namespace Shopping_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(IProductService productService,ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
        }
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.GetProducts();
                _logger.LogInformation("Product Listed");
                return Ok(result);
            }
            catch (NoProductsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
        
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(Product),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create(Product product)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _productService.Add(product);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}
