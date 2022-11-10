using Microsoft.AspNetCore.Mvc;

namespace ImobiliariaDL.Areas.Admin.Controllers
{
    public class ImovelAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
