using Business.Services;
using Core.Abstracts.IServices;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.UI.Areas.Profile.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAreaController : Controller
    {
        private readonly IMembershipService service = new MembershipService();
        // GET: Profile/AdminArea
        public async Task<ActionResult> Index()
        {
            var members = await service.GetMemberList();
            return View(members);
        }


        [HttpPost]
        public async Task<JsonResult> ChangeRole(string role, string username)
        {
            var result = await service.ChangeRoleAsync(role, username);
            if (result)
            {
                return Json(new
                {
                    success = true,
                    message = username + " kullanıcısının rolü " + role + " olarak değiştirildi!"
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = username + " kullanıcısının rolü " + role + " olarak değiştirilemedi!"
                });
            }
        }
    }
}