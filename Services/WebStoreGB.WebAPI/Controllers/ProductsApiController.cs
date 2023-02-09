using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStoreGB.Domain;
using WebStoreGB.Domain.DTO;
using WebStoreGB.Interfaces;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.WebAPI.Controllers
{
    [Route(WebAPIAddresses.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductData _ProductData;
        public ProductsApiController(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        [HttpGet("sections")]
        public IActionResult GetSections()
        {
            var sections = _ProductData.GetSections();
            return Ok(sections.ToDTO());
        }

        [HttpGet("sections/{id}")]
        public IActionResult GetSection(int id)
        {
            var section = _ProductData.GetSectionById(id);
            return Ok(section.ToDTO());
        }

        [HttpGet("brands")]
        public IActionResult GetBrands()
        {
            var brands = _ProductData.GetBrands();
            return Ok(brands.ToDTO());
        }

        [HttpGet("brands/{id}")]
        public IActionResult GetBrand(int id)
        {
            var brand = _ProductData.GetBrandById(id);
            return Ok(brand.ToDTO());
        }

        [HttpPost] // делам Post потому что передаём сложный объект ProductFilter
        public IActionResult GetProducts([FromBody] ProductFilter Filter = null)
        {
            var products = _ProductData.GetProducts(Filter);
            return Ok(products.ToDTO());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _ProductData.GetProductById(id);
            if(product is null)
                return NotFound();
            return Ok(product.ToDTO());
        }
    }
}
