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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(NewArticle newArticle, HttpPostedFileBase CoverImage)
        {
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
    }
}