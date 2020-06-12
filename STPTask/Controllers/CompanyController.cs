namespace STPTask.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}