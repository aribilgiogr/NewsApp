using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        //Örnek Slug: lorem-ipsum-dolor-sit-amet-123 => <article title>-<article id>
        public async Task<ArticleDetail> GetArticleAsync(string articleSlug)
        {
            string suffix = articleSlug.Split('-').LastOrDefault();
            int.TryParse(suffix, out int id);
            var article = await unitOfWork.ArticleRepository.FindByKeyAsync(id);
            if (article != null)
            {
                if (!article.Deleted && article.Active && !article.Draft)
                {
                    var tags = await unitOfWork.TagRepository.FindManyAsync(x => x.ArticleId == article.Id);

                    var category = new CategoryMenuItem
                    {
                        Name = article.Category.Name,
                        Slug = article.Category.Name
                    };

                    return new ArticleDetail
                    {
                        Title = article.Title,
                        HtmlContent = article.HtmlContent,
                        PublishDate = (DateTime)article.PublishDate,
                        SubTitle = article.SubTitle,
                        CoverImage = article.CoverImage,
                        Tags = tags.Select(x => x.Name),
                        CategoryInfo = category,
                        Slug = article.Title
                    };
                }
            }
            return null;
        }

        public async Task<IEnumerable<ArticlesListItem>> GetArticlesAsync(string categorySlug = null)
        {
            IEnumerable<Article> articles;

            if (categorySlug != null)
            {
                string suffix = categorySlug.Split('-').LastOrDefault();
                int.TryParse(suffix, out int id);
                articles = await unitOfWork.ArticleRepository.FindManyAsync(x => x.CategoryId == id && x.Active && !x.Deleted && !x.Draft);
            }
            else
            {
                articles = await unitOfWork.ArticleRepository.FindManyAsync(x => x.Active && !x.Deleted && !x.Draft);
            }

            return from article in articles
                   select new ArticlesListItem
                   {
                       Title = article.Title,
                       PublishDate = (DateTime)article.PublishDate,
                       SubTitle = article.SubTitle,
                       CoverImage = article.CoverImage,
                       Slug = article.Title,
                       Tags = article.Tags.Select(x => x.Name),
                       CategoryInfo = new CategoryMenuItem { Name = article.Category.Name, Slug = article.Category.Name }
                   };
        }

        public async Task<IEnumerable<CategoryMenuItem>> GetCategories()
        {
            var categories = await unitOfWork.CategoryRepository.FindManyAsync(x => x.Active && !x.Deleted);
            return from category in categories
                   select new CategoryMenuItem
                   {
                       Name = category.Name,
                       Slug = category.Name
                   };
        }
    }
}
