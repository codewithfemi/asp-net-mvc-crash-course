using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Core.Interfaces;
using WebApplication3.Models;

namespace WebApplication3.ViewComponents
{
    public class BlogListViewComponent : ViewComponent
    {
        private readonly IDataService _dataService;
        public BlogListViewComponent(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new List<BlogListViewModel>();
            var dataServiceResult = await _dataService.GetBlogListAsync();
            dataServiceResult.ForEach(x =>
            model.Add(new BlogListViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Ratings = x.Ratings
            }));

            return View("Index", model);
        }
    }
}
