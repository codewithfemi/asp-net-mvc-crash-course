using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using WebApplication3.Controllers;
using WebApplication3.Models;

namespace WebApplication3.Tests.Controllers
{
    internal class AboutControllerTests
    {
        private AboutController _aboutController;

        [SetUp]
        public void Setup()
        {
            _aboutController = new AboutController();
        }

        [Test]
        public void Can_Check_For_View_Result()
        {
            // Act
            var result = _aboutController.Index();

            //Assert
            Assert.IsTrue(result.GetType() == typeof(ViewResult));
        }

        [Test]
        public void Can_Check_For_View_Result_Data()
        {
            // Act
            var result = _aboutController.Index() as ViewResult;
            var model = result.Model as AboutViewModel;

            //Assert
            Assert.AreEqual("Code with Femi", model.Name);
            Assert.AreEqual("I love coding on YouTube", model.Description);
        }
    }
}
