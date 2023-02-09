using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebStoreGB.Domain;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.Services.Mapping;

namespace WebStoreGB.Controllers
{
    public class CatalogController : Controller
    {
        private const string _PageSizeConfig = "CatalogPageSize";
        private readonly IProductData _ProductData;
        private readonly IConfiguration _Configuration;

        public CatalogController(IProductData productData, IConfiguration Configuration)
        {
            _ProductData = productData;
            _Configuration = Configuration;
        }
        public IActionResult Index(int? BrandId,int? SectionId, int Page = 1, int? PageSize = null)
        {
            var page_size = PageSize
                ?? (int.TryParse(_Configuration[_PageSizeConfig], out var value) ? value : null);

            var filter = new ProductFilter
            {
                BrandId = BrandId,
                SectionId = SectionId,
                PageSize = page_size,
                Page= Page,
            };

            var (products, total_count) = _ProductData.GetProducts(filter);

            var view_model = new CatalogViewModel
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Products = products.OrderBy(x => x.Order).ToView(),
                PageViewModel = new()
                {
                    Page = Page,
                    PageSize = page_size ?? 0,
                    TotalItems = total_count,
                }
            };

            return View(view_model);
        }
        public IActionResult Details(int Id)
        {
            var product = _ProductData.GetProductById(Id);

            if (product is null) return NotFound();

            return View(product.ToView());
        }

        public IActionResult GetProductsView(int? BrandId, int? SectionId, int Page = 1, int? PageSize = null)
        {
            var products = GetProducts(BrandId, SectionId, Page, PageSize);

            return PartialView("Partial/_Products",products);
        }

        private IEnumerable<ProductViewModel> GetProducts(int? BrandId, int? SectionId, int Page, int? PageSize)
        {
            var products = _ProductData.GetProducts(new()
            {
                BrandId = BrandId,
                SectionId = SectionId,
                Page = Page,
                PageSize = PageSize ?? _Configuration.GetValue(_PageSizeConfig,6),
            });

            return products.Products.OrderBy(x => x.Order).ToView();
        }
    }
}
