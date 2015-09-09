using System.Web.Mvc;

namespace Insurance.Web.Controllers
{
    public class HomeController : InsuranceControllerBase
    {

        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}