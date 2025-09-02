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

        public Task DeleteToggleArticleAsync(string articleSlug)
        {
            throw new NotImplementedException();
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

        public Task PublishToggleArticleAsync(string articleSlug)
        {
            throw new NotImplementedException();
        }

        public Task UpdateArticleAsync(EditArticle editArticle)
        {
            throw new NotImplementedException();
        }
    }
}
