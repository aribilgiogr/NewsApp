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
}
