using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Member")]
        public ActionResult MemberArea()
        {
            return View();
        }

        [Authorize(Roles = "Editor")]
        public ActionResult EditorArea()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AdminArea()
        {
            return View();
        }
    }
}