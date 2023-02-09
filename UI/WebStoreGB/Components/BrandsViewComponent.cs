using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.Components
{
    //[ViewComponent( Name = "BrandsView")]
    public class BrandsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;
        public BrandsViewComponent(IProductData productData)
        {
            _ProductData = productData;
        }
        //public async Task<IViewComponentResult> InvokeAsync() => View();
        public IViewComponentResult Invoke(string BrandId)
        {
            ViewBag.BrandId = int.TryParse(BrandId, out var id) ? id : (int?)null;
            return View(GetBrands());
        }
        private IEnumerable<BrandViewModel> GetBrands() =>
            _ProductData.GetBrands()
            .OrderBy(x => x.Order)
            .Select(b => new BrandViewModel
            {
                Id = b.Id,
                Name = b.Name,
            });
    }
}
