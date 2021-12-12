using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Core.Constants;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = RoleConstants.Admin)]
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var model = new AboutViewModel();
            return View(model);
        }
    }
}
