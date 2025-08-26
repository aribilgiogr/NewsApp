using Business.Services;
using Core.Abstracts.IServices;
using System.Threading.Tasks;
using System.Web.Mvc;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMagazineService service = new MagazineService();
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var model = new HomeIndexViewModel();
            model.Categories = await service.GetCategories();
            model.LatestArticles = await service.GetArticlesAsync();
            return View(model);
        }

        public async Task<ActionResult> ByCategory(string slug, int id)
        {
            var model = new HomeIndexViewModel();
            model.Categories = await service.GetCategories();
            model.LatestArticles = await service.GetArticlesAsync(id);
            return View("index", model);
        }

        public async Task<ActionResult> ArticleDetail(string slug, int id)
        {
            return View(await service.GetArticleAsync(id));
        }
    }
}