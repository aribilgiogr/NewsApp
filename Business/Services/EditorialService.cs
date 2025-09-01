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

        public Task<IEnumerable<ArticlesListItem>> GetArticlesAsync()
        {
            throw new NotImplementedException();
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
