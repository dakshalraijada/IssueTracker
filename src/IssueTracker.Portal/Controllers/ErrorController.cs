using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Portal.Controllers
{
    public class ErrorController : Controller
    {
        [Route("error/{id}")]
        public IActionResult Error(int id)
        {
            if (id == 404)
            {
                var statusFeature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
                if (statusFeature != null)
                {
                    //log.LogWarning("handled 404 for url: {OriginalPath}", statusFeature.OriginalPath);
                }
            }
            return View(id);
        }
    }
}