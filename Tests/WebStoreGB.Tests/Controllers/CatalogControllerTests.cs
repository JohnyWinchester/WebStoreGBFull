using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = Xunit.Assert;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebStoreGB.Controllers;
using Moq;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.Domain.Entities;
using WebStoreGB.Domain.ViewModels;
using Microsoft.Extensions.Configuration;

namespace WebStoreGB.Tests.Controllers
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void Detail_Returns_with_Correct_View()
        {
            const int expected_id = 321;
            const string expected_name = "Test product";
            const int expected_order = 5;
            const decimal expected_price = 13.5m;
            const string expected_img_url = "/img/product.img";

            const int expected_brand_id = 7;
            const string expected_brand_name = "Test brand";
            const int expected_brand_order = 10;

            const int expected_section_id = 14;
            const string expected_section_name = "Test section";
            const int expected_section_order = 10;

            var product_data_mock = new Mock<IProductData>();

            product_data_mock
                //.Setup(c => c.GetProductById(It.IsAny<int>()))
                .Setup(c => c.GetProductById(It.Is<int>(id => id > 0)))
                .Returns<int>(id => new Product()
                {
                    Id = expected_id,
                    Name = expected_name,
                    Order = expected_order,
                    Price = expected_price,
                    ImageUrl = expected_img_url,
                    BrandId = expected_brand_id,
                    Brand = new Brand
                    {
                        Id = expected_brand_id,
                        Name = expected_brand_name,
                        Order = expected_brand_order
                    },
                    SectionId = expected_section_id,
                    Section = new Section
                    {
                        Id = expected_section_id,
                        Name = expected_section_name,
                        Order = expected_section_order
                    },
                });

            var configuration_mock = new Mock<IConfiguration>();
            configuration_mock.Setup(c => c["CatalogPageSize"]).Returns("4");

            var controller = new CatalogController(product_data_mock.Object,configuration_mock.Object);

            var result = controller.Details(expected_id);
            var view_result = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<ProductViewModel>(view_result.Model);
            Assert.Equal(expected_id, model.Id);
            Assert.Equal(expected_name, model.Name);
            Assert.Equal(expected_price, model.Price);
            Assert.Equal(expected_img_url, model.ImageUrl);
            Assert.Equal(expected_section_name, model.Section);
            Assert.Equal(expected_brand_name, model.Brand);

            product_data_mock.Verify(x => x.GetProductById(It.Is<int>(Id => Id > 0)));
            product_data_mock.VerifyNoOtherCalls();
        }
    }
}
