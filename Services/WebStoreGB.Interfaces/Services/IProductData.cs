using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.Domain;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Domain.Entities.Base;

namespace WebStoreGB.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();
        IEnumerable<Brand> GetBrands();
        ProductsPage GetProducts(ProductFilter filter = null);
        Product GetProductById(int Id);
        Section GetSectionById(int Id);
        Brand GetBrandById(int Id);
    }
}
