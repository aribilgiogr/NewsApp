using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI.Areas.Profile.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class EditorAreaController : Controller
    {
        // GET: Profile/EditorArea
        public ActionResult Index()
        {
            return View();
        }
    }
}