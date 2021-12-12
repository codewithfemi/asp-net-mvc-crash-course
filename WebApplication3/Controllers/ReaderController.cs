using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Core.Constants;

namespace WebApplication3.Controllers
{
    [Authorize(Roles = RoleConstants.Reader)]
    public class ReaderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
