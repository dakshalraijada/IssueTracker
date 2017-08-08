using Microsoft.AspNetCore.Mvc;
using IssueTracker.Core;
using IssueTracker.Core.Data;
using SaasKit.Multitenancy;

namespace IssueTracker.Portal.Controllers
{
    public class HomeController : BaseController
    {
       
        public HomeController(IUow uow, ITenant<Company> company) : base(uow, company){
            
        }

        public IActionResult Index()
        {
            if (HttpContext.Response.StatusCode == 404)
            {
                return View("~/Views/Error/Error.cshtml", 404);
            }

            if (Company != null)
            {
                return View("~/Views/Company/Index.cshtml", Company);
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
