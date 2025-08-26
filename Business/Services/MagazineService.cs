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
using Utilities.Extensions;

namespace Business.Services
{
    public class MagazineService : IMagazineService
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        //Örnek Slug: lorem-ipsum-dolor-sit-amet-a-123 => <article title>-a-<article id>
        public async Task<ArticleDetail> GetArticleAsync(int articleId)
        {
            var article = await unitOfWork.ArticleRepository.FindByKeyAsync(articleId);
            if (article != null)
            {
                if (!article.Deleted && article.Active && !article.Draft)
                {
                    var tags = await unitOfWork.TagRepository.FindManyAsync(x => x.ArticleId == article.Id);

                    var category = new CategoryMenuItem
                    {
                        Name = article.Category.Name,
                        Slug = article.Category.Name.Slugify(article.CategoryId.ToString(), "c")
                    };

                    var relatedArticles = await GetArticlesAsync(article.CategoryId);
                    relatedArticles = relatedArticles.Where(x => !x.Slug.EndsWith(article.Id.ToString())).Take(3);

                    return new ArticleDetail
                    {
                        Title = article.Title,
                        HtmlContent = article.HtmlContent,
                        PublishDate = (DateTime)article.PublishDate,
                        SubTitle = article.SubTitle,
                        CoverImage = article.CoverImage,
                        Tags = tags.Select(x => x.Name),
                        CategoryInfo = category,
                        Slug = article.Title.Slugify(article.Id.ToString(), "a"),
                        RelatedArticles = relatedArticles
                    };
                }
            }
            return null;
        }

        public async Task<IEnumerable<ArticlesListItem>> GetArticlesAsync(int? categoryId = null)
        {
            IEnumerable<Article> articles;

            if (categoryId != null)
            {
                articles = await unitOfWork.ArticleRepository.FindManyAsync(x => x.CategoryId == categoryId && x.Active && !x.Deleted && !x.Draft);
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
                       Slug = article.Title.Slugify(article.Id.ToString(), "a"),
                       Tags = article.Tags.Select(x => x.Name),
                       CategoryInfo = new CategoryMenuItem { Name = article.Category.Name, Slug = article.Category.Name.Slugify(article.CategoryId.ToString(), "c") }
                   };
        }

        public async Task<IEnumerable<CategoryMenuItem>> GetCategories()
        {
            var categories = await unitOfWork.CategoryRepository.FindManyAsync(x => x.Active && !x.Deleted);
            return from category in categories
                   select new CategoryMenuItem
                   {
                       Name = category.Name,
                       Slug = category.Name.Slugify(category.Id.ToString(), "c")
                   };
        }
    }
}
