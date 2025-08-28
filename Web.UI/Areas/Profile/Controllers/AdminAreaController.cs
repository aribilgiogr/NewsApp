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
    }
}