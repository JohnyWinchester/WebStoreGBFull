using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Interfaces;

namespace WebStoreGB.WebAPI.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTests
    {
        private readonly WebApplicationFactory<Startup> _Host = new(); // псевдо веб-приложение 

        [TestMethod]
        public async Task GetValues_IntegriryTest()
        {
            var client = _Host.CreateClient(); // создаём http клиет, запросы будут не сетевыми, а виртуальными которые будет ввести внутрь клиента

            var response = await client.GetAsync(WebAPIAddresses.Values);
            response.EnsureSuccessStatusCode();

            var values = await response.Content.ReadFromJsonAsync<IEnumerable<string>>();

            //var parser = new HtmlParser();
            //var html = parser.ParseDocument(await response.Content.ReadAsStreamAsync());
        }
    }
}
