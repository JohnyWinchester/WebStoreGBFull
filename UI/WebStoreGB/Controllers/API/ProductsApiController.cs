using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.Controllers.API
{
    [ApiController, Route("api/products")]
    public class ProductsApiController : ControllerBase
    {
        private readonly IProductData _ProductData;

        public ProductsApiController(IProductData ProductData)
        {
            _ProductData = ProductData;
        }

        private class ProductInfo
        {
            public int Id { get; set; }

            public string Title { get; set; }

            public decimal Price { get; set; }

            public string Image { get; set; }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(3500);
            var products = _ProductData.GetProducts();

            var infos = products.Products.Select(p => new ProductInfo
            {
                Id = p.Id,
                Image = p.ImageUrl,
                Price = p.Price,
                Title = p.Name,
            });


            return Ok(infos);
        }
    }
}
