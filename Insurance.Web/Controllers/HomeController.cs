using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Insurance.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : InsuranceControllerBase
    {

        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}