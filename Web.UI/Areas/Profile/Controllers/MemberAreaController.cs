using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI.Areas.Profile.Controllers
{
    [Authorize]
    public class MemberAreaController : Controller
    {
        // GET: Profile/MemberArea
        public ActionResult Index()
        {
            return View();
        }
    }
}