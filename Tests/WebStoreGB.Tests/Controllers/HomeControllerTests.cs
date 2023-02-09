using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoreGB.Controllers;
using Assert = Xunit.Assert;

namespace WebStoreGB.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void Index_Returns_View()
        {
            var controller = new HomeController();

            var result = controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void ContactUs_Returns_View()
        {
            var controller = new HomeController();

            var result = controller.ContactUs();

            Assert.IsType<ViewResult>(result);
        }

        [TestMethod]
        public void Status_with_id_404_Returns_View()
        {
            #region Arrange
            const string id = "404";
            const string expected_view_name = "NotFound";
            var controller = new HomeController();
            #endregion

            #region Act
            var result = controller.Status(id);
            #endregion

            #region Assert
            var view_result = Assert.IsType<ViewResult>(result);
            var actual_view_name = view_result.ViewName;
            Assert.Equal(expected_view_name, actual_view_name);
            #endregion
        }

        [TestMethod]
        public void Status_with_id_123_Returns_View()
        {
            #region Arrange
            const string id = "123";
            const string expected_content = "Status code ---" + id;
            var controller = new HomeController();
            #endregion

            #region Act
            var result = controller.Status(id);
            #endregion

            #region Assert
            var content_result = Assert.IsType<ContentResult>(result);
            var actual_result = content_result.Content;
            Assert.Equal(expected_content, actual_result); 
            #endregion
        }

        //[DataRow("123")] дата ров если нам нужны параметры
        [TestMethod]
        [DataRow("124")]
        [DataRow("QWE")]
        public void Status_with_id_124_Returns_View(string id)
        {
            #region Arrange
            //const string id = "123";
            var expected_content = "Status code ---" + id;
            var controller = new HomeController();
            #endregion

            #region Act
            var result = controller.Status(id);
            #endregion

            #region Assert
            var content_result = Assert.IsType<ContentResult>(result);
            var actual_result = content_result.Content;
            Assert.Equal(expected_content, actual_result);
            #endregion
        }

        #region Exception
        //AssertFailedException сигнал о том что в модульном тесте был exception при проверке Assert
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Status_with_id_null_Returns_View_1()
        {
            #region Arrange;
            var controller = new HomeController();
            #endregion

            #region Act
            _ = controller.Status(null);
            #endregion
        }

        [TestMethod]
        public void Status_with_id_null_Returns_View_2()
        {
            #region Arrange;
            const string expected_param_name = "id";
            var controller = new HomeController();
            Exception error = null;
            #endregion

            #region Act
            try
            {
                _ = controller.Status(null);

            }
            catch (ArgumentNullException e)
            {
                error = e;
            }
            #endregion

            #region Assert
            var actual_exception = Assert.IsType<ArgumentNullException>(error);
            var actual_parameter_name = actual_exception.ParamName;
            Assert.Equal(expected_param_name, actual_parameter_name);
            #endregion
        }

        [TestMethod]
        public void Status_with_id_null_Returns_View_3()
        {
            const string expected_param_name = "id";
            var controller = new HomeController();

            var actual_exception = Assert.Throws<ArgumentNullException>(() => controller.Status(null)); 
            Assert.Equal(expected_param_name,actual_exception.ParamName);

        }
        #endregion
    }
}
