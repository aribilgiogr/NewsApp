using Core.Concretes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IMagazineService
    {
        Task<IEnumerable<ArticlesListItem>> GetArticlesAsync(int? categoryId = null);
        Task<ArticleDetail> GetArticleAsync(int articleId);
        Task<IEnumerable<CategoryMenuItem>> GetCategories();
    }

    public interface IEditorialService
    {
        Task CreateArticleAsync(NewArticle newArticle);
        Task DeleteToggleArticleAsync(string articleSlug);
        Task PublishToggleArticleAsync(string articleSlug);
        Task UpdateArticleAsync(EditArticle editArticle);
    }

    public interface IMembershipService
    {

    }
}
