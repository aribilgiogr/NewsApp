using Business.Services;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities.Extensions;

namespace Web.UI.Areas.Profile.Controllers
{
    [Authorize(Roles = "Admin,Editor")]
    public class EditorAreaController : Controller
    {
        private readonly IEditorialService service = new EditorialService();
        // GET: Profile/EditorArea
        public async Task<ActionResult> Index()
        {
            var articles = await service.GetArticlesAsync();
            return View(articles);
        }

        public async Task<ActionResult> Create()
        {
            var categories = await service.GetCategoriesAsync();
            // ViewBag.Categories = categories.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewArticle newArticle, HttpPostedFileBase CoverImage)
        {
            var categories = await service.GetCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", newArticle.CategoryId);

            if (!ModelState.IsValid || CoverImage == null || CoverImage.ContentLength == 0)
                return View(newArticle);

            var extension = Path.GetExtension(CoverImage.FileName).ToLower();
            if (new[] { ".jpg", ".jpeg", ".png" }.Contains(extension))
            {
                var filename = newArticle.Title.Slugify() + "-" + DateTime.Now.ToString("ddMMyyyyHHmmss") + extension;
                var path = Path.Combine(Server.MapPath("~/content/uploads"), filename);
                CoverImage.SaveAs(path);
                newArticle.CoverImage = path;
                await service.CreateArticleAsync(newArticle);
                return RedirectToAction("index");
            }
            return View(newArticle);
        }

        [HttpPost]
        public async Task<bool?> ToggleDraft(int articleId)
        {
            return await service.PublishToggleArticleAsync(articleId);
        }

        [HttpPost]
        public async Task<bool?> ToggleDelete(int articleId)
        {
            return await service.DeleteToggleArticleAsync(articleId);
        }

        public async Task<ActionResult> Detail(int id)
        {
            var model = await service.GetArticleAsync(id);
            if (model != null)
            {
                var categories = await service.GetCategoriesAsync();
                ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                return View(model);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Detail(EditArticle model, HttpPostedFileBase CoverImage)
        {
            var categories = await service.GetCategoriesAsync();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
            return View(model);
        }
    }
}