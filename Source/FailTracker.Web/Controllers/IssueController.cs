using FailTracker.Web.Data;
using System.Web.Mvc;

namespace FailTracker.Web.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IssueController(ApplicationDbContext context)
        {
            _context = context;
        }

        public ActionResult IssueWidget()
        {
            return Content("Here's where issues would go!");
        }
        public ActionResult IssueWidget2()
        {
            return Content("Here's where issues would go!");
        }
    }
}