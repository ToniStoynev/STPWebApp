namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class OfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}