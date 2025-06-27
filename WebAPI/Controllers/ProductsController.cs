using Microsoft.AspNetCore.Mvc;
using Model;
using Model.SearchObjects;
using Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
           _productService = productService;
        }

        [HttpGet("")]
        public IEnumerable<Product> Get([FromQuery]ProductSearchObject? search)
        {
            return _productService.Get(search);
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return _productService.GetById(id);
        }
    }
}
