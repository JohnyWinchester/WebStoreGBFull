using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStoreGB.DAL.Context;
using WebStoreGB.Domain;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Interfaces.Services;

namespace WebStoreGB.Services.Services.InSQL
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreGBDB _db;
        public SqlProductData(WebStoreGBDB db)
        {
            _db = db;
        }
        public IEnumerable<Brand> GetBrands()
        {
            return _db.Brands;
        }

        public Product GetProductById(int Id) => _db.Products
            .Include(x => x.Brand)
            .Include(x => x.Section)
            .FirstOrDefault(x => x.Id == Id);

        public Section GetSectionById(int Id) => _db.Sections.FirstOrDefault(x => x.Id == Id);

        public Brand GetBrandById(int Id) => _db.Brands.FirstOrDefault(x => x.Id == Id);

        public ProductsPage GetProducts(ProductFilter Filter = null)
        {
            IQueryable<Product> query = _db.Products
                .Include(x => x.Brand)
                .Include(x => x.Section);

            if (Filter?.Ids?.Length > 0)
            {
                query = query.Where(product => Filter.Ids.Contains(product.Id));
            }
            else
            {
                if (Filter?.SectionId is { } section_id)
                    query = query.Where(x => x.SectionId == section_id);

                if (Filter?.BrandId is { } brand_id)
                    query = query.Where(x => x.BrandId == brand_id);
            }

            var total_count = query.Count();
            if (Filter is { PageSize: > 0 and var page_size, Page: > 0 and var page_number })
                query = query
                    .OrderBy(v => v.Order)
                    .Skip((page_number - 1) * page_size)
                    .Take(page_size);

            return new ProductsPage(query.AsEnumerable(), total_count);
        }

        public IEnumerable<Section> GetSections()
        {
            return _db.Sections;
        }
    }
}
