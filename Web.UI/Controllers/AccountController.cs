using Business.Services;
using Core.Abstracts.IServices;
using System.Threading.Tasks;
using System.Web.Mvc;
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
            if (ModelState.IsValid)
            {
                if (await service.LoginAsync(model.Username, model.Password, model.RememberMe))
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
            if (ModelState.IsValid && await service.RegisterAsync(model.Email, model.Username, model.Password))
            {
                return Redirect(returnUrl ?? "/");
            }
            return View(model);
        }

        public async Task<ActionResult> Logout(string returnUrl)
        {
            await service.LogoutAsync();
            return Redirect(returnUrl ?? "/");
        }
    }
}