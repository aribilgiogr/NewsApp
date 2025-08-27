using Business.Services;
using Core.Abstracts.IServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using Utilities.Helpers;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMembershipService service = new MembershipService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            ViewBag.Response = ResponseHelper.Error("Zorunlu alanları doldurunuz!");
            if (ModelState.IsValid)
            {
                var response = await service.LoginAsync(model.Username, model.Password, model.RememberMe);
                ViewBag.Response = response;
                if (response.Status)
                {
                    return Redirect(returnUrl ?? "/");
                }
            }
            return View(model);
        }

        public ActionResult Register(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model, string returnUrl)
        {
            ViewBag.Response = ResponseHelper.Error("Zorunlu alanları doldurunuz!");
            if (ModelState.IsValid)
            {
                var response = await service.RegisterAsync(model.Email, model.Username, model.Password);
                ViewBag.Response = response;
                if (response.Status)
                {
                    return Redirect(returnUrl ?? "/");
                }
            }
            return View(model);
        }

        public ActionResult Logout(string returnUrl)
        {
            service.Logout();
            return Redirect(returnUrl ?? "/");
        }
    }
}