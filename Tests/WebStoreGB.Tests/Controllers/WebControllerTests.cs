using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Controllers;
using WebStoreGB.Interfaces.TestAPI;
using Assert = Xunit.Assert;

namespace WebStoreGB.Tests.Controllers
{
    [TestClass]
    public class WebControllerTests
    {
        [TestMethod]
        public void Index_Returns_with_DataValues()
        {
            var data = Enumerable.Range(1,10)
                .Select( i => $"Value - {i}")
                .ToArray();

            var values_service_mock = new Mock<IValuesService>();
            values_service_mock
                .Setup(c => c.GetAll())
                .Returns(data);

            var controller = new WebAPIController(values_service_mock.Object);

            var result = controller.Index();

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<string>>(view_result.Model); // Для производных типов .IsAssignableFrom

            int i = 0;
            foreach(var actual_value in model )
            {
                var expected_value = data[i++];
                Assert.Equal(expected_value, actual_value);
            }

            values_service_mock.Verify(s => s.GetAll()); // проверяем вызывался ли метод, если не выхывался, то провал
            values_service_mock.VerifyNoOtherCalls(); // проверям что другие методы не вызывались
        }
    }
}
