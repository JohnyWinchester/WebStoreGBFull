using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Domain.ViewModels;
using WebStoreGB.Interfaces.Services;
using WebStoreGB.Interfaces.TestAPI;
using Assert = Xunit.Assert;

namespace WebStoreGB.WebAPI.Tests.Controllers
{
    [TestClass]
    public class WebAPIIntegrationTest
    {
        private readonly string[] _ExpectedValues 
            = Enumerable.Range(1, 10).Select(x => $"TestValue - {x}").ToArray();

        private WebApplicationFactory<Startup> _Host;

        [TestInitialize]
        public void Initialize()
        {
            var values_service_mock = new Mock<IValuesService>();
            values_service_mock.Setup(x => x.GetAll()).Returns(_ExpectedValues);

            var cart_service_mock = new Mock<ICartService>();
            cart_service_mock.Setup(c => c.GetViewModel()).Returns(() => new CartViewModel { Items = Enumerable.Empty<(ProductViewModel,int)>() });

            _Host = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(host => host
                .ConfigureServices(services => services
                .AddSingleton(values_service_mock.Object)
                .AddSingleton(cart_service_mock.Object)));
        }

        [TestMethod]
        public async Task GetValues()
        {
            var client = _Host.CreateClient();
            var response = await client.GetAsync("/WebAPI");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var parser = new HtmlParser();

            var content_stream = await response.Content.ReadAsStreamAsync();
            var html = parser.ParseDocument(content_stream);

            var items = html.QuerySelectorAll(".container table.table tbody tr td:last-child");

            var actual_values = items.Select(item => item.Text());

            Assert.Equal(_ExpectedValues, actual_values);
        }
    }
}
