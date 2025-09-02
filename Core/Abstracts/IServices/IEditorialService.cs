using Core.Concretes.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IEditorialService
    {
        Task<IEnumerable<ArticleEditorialItem>> GetArticlesAsync();
        Task<IEnumerable<CategoryListItem>> GetCategoriesAsync();
        Task CreateArticleAsync(NewArticle newArticle);
        Task DeleteToggleArticleAsync(string articleSlug);
        Task PublishToggleArticleAsync(string articleSlug);
        Task UpdateArticleAsync(EditArticle editArticle);
    }
}
