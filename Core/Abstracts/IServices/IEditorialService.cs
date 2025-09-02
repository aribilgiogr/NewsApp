using Core.Concretes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IEditorialService
    {
        Task<IEnumerable<ArticleEditorialItem>> GetArticlesAsync();
        Task<EditArticle> GetArticleAsync(int id);
        Task<IEnumerable<CategoryListItem>> GetCategoriesAsync();
        Task CreateArticleAsync(NewArticle newArticle);
        Task<bool?> DeleteToggleArticleAsync(int articleId);
        Task<bool?> PublishToggleArticleAsync(int articleId);
        Task UpdateArticleAsync(EditArticle editArticle);
    }
}
