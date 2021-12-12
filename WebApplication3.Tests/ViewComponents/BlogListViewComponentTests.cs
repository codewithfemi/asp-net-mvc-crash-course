using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Core.Interfaces;
using WebApplication3.Core.Models;
using WebApplication3.Models;
using WebApplication3.ViewComponents;

namespace WebApplication3.Tests.ViewComponents
{
    internal class BlogListViewComponentTests
    {
        private BlogListViewComponent _blogListViewComponent;
        private Mock<IDataService> _dataServiceMock;

        [SetUp]
        public void Setup()
        {
            _dataServiceMock = new Mock<IDataService>();
            _blogListViewComponent = new BlogListViewComponent(_dataServiceMock.Object);
        }

        [Test]
        public async Task Can_Check_For_View_Component_Data()
        {
            // Arrange 
            var blogId1 = Guid.NewGuid();
            var blogId2 = Guid.NewGuid();
            var testName1 = "Me";
            var testName2 = "You";
            _dataServiceMock.Setup(service => service
            .GetBlogListAsync())
                .Returns(Task.FromResult(
                    new List<Blog> 
                    {
                        new Blog { Id = blogId1, Name = testName1, Ratings = 4 },
                        new Blog { Id = blogId2, Name = testName2, Ratings = 5 }
                    }));
            // Act
            var result = await _blogListViewComponent.InvokeAsync() as ViewViewComponentResult;
            var model = result.ViewData.Model as List<BlogListViewModel>;

            //Assert
            Assert.IsTrue(model.Count == 2);
            Assert.IsTrue(model.Any(x => x.Id == blogId1));
            Assert.IsTrue(model.Any(x => x.Id == blogId2));
            Assert.IsTrue(model.Any(x => x.Name == testName1));
            Assert.IsTrue(model.Any(x => x.Name == testName2));

            var blog1 = model.First(x => x.Id == blogId1);
            Assert.AreEqual("****", blog1.GetStarRatings());

            var blog2 = model.First(x => x.Id == blogId2);
            Assert.AreEqual("*****", blog2.GetStarRatings());
        }
    }
}
