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
    public class EditorialService : IEditorialService
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        public async Task CreateArticleAsync(NewArticle newArticle)
        {
            var article = new Article
            {
                Title = newArticle.Title,
                SubTitle = newArticle.SubTitle,
                HtmlContent = newArticle.HtmlContent,
                CoverImage = newArticle.CoverImage,
                CategoryId = newArticle.CategoryId
            };
            await unitOfWork.ArticleRepository.InsertOneAsync(article);
            await unitOfWork.CommitAsync();
        }

        public async Task<bool?> DeleteToggleArticleAsync(int articleId)
        {
            var article = await unitOfWork.ArticleRepository.FindByKeyAsync(articleId);
            if (article != null)
            {
                article.Active = article.Deleted;
                article.Deleted = !article.Deleted;
                article.Draft = true;
                article.PublishDate = null;
                await unitOfWork.ArticleRepository.UpdateOneAsync(article);
                await unitOfWork.CommitAsync();
                return article.Deleted;
            }
            return null;
        }

        public async Task<EditArticle> GetArticleAsync(int id)
        {
            var article = await unitOfWork.ArticleRepository.FindByKeyAsync(id);
            if (article != null)
            {
                return new EditArticle
                {
                    ArticleId = article.Id,
                    CategoryId = article.CategoryId,
                    CoverImage = article.CoverImage,
                    HtmlContent = article.HtmlContent,
                    SubTitle = article.SubTitle,
                    Title = article.Title
                };
            }
            return null;
        }

        public async Task<IEnumerable<ArticleEditorialItem>> GetArticlesAsync()
        {
            var articles = await unitOfWork.ArticleRepository.FindManyAsync();
            return from a in articles
                   select new ArticleEditorialItem
                   {
                       Id = a.Id,
                       Title = a.Title,
                       Deleted = a.Deleted,
                       Draft = a.Draft,
                       PublishDate = a.PublishDate,
                       CategoryInfo = new CategoryListItem { Id = a.CategoryId, Name = a.Category.Name }
                   };
        }

        public async Task<IEnumerable<CategoryListItem>> GetCategoriesAsync()
        {
            var categories = await unitOfWork.CategoryRepository.FindManyAsync();
            return from c in categories
                   select new CategoryListItem
                   {
                       Id = c.Id,
                       Name = c.Name
                   };
        }

        // ?: Nullable yani boş olabilir anlamına gelir.
        public async Task<bool?> PublishToggleArticleAsync(int articleId)
        {
            var article = await unitOfWork.ArticleRepository.FindByKeyAsync(articleId);
            if (article != null)
            {
                article.Draft = !article.Draft;
                article.PublishDate = !article.Draft ? (DateTime?)DateTime.Now : null;
                await unitOfWork.ArticleRepository.UpdateOneAsync(article);
                await unitOfWork.CommitAsync();
                return article.Draft;
            }
            return null;
        }

        public Task UpdateArticleAsync(EditArticle editArticle)
        {
            throw new NotImplementedException();
        }
    }
}
