using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain;
using WebStoreGB.Domain.DTO;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Interfaces;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.WebAPI.Clients.Base;

namespace WebStoreGB.WebAPI.Clients.Products
{
    public class ProductsClient : BaseClient, IProductData
    {
        public ProductsClient(HttpClient Client) : base(Client, WebAPIAddresses.Products){}

        public Brand GetBrandById(int Id)
        {
            var result = Get<BrandDTO>($"{Address}/brands/{Id}");
            return result.FromDTO();
        }

        public IEnumerable<Brand> GetBrands()
        {
            var brands = Get<IEnumerable<BrandDTO>>($"{Address}/brands");
            return brands.FromDTO();
        }

        public Product GetProductById(int Id)
        {
            var result = Get<ProductDTO>($"{Address}/{Id}");
            return result.FromDTO();
        }

        public ProductsPage GetProducts(ProductFilter Filter = null)
        {
            var response = Post(Address, Filter ?? new());
            var products_dtos = response.Content.ReadFromJsonAsync<ProductsPageDTO>().Result;
            return products_dtos.FromDTO();
        }

        public Section GetSectionById(int Id)
        {
            var result = Get<SectionDTO>($"{Address}/sections/{Id}");
            return result.FromDTO();
        }

        public IEnumerable<Section> GetSections()
        {
            var sections = Get<IEnumerable<SectionDTO>>($"{Address}/sections");
            return sections.FromDTO();
        }
    }
}
