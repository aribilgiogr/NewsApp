using Core.Concretes.DTOs;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IEditorialService
    {
        Task CreateArticleAsync(NewArticle newArticle);
        Task DeleteToggleArticleAsync(string articleSlug);
        Task PublishToggleArticleAsync(string articleSlug);
        Task UpdateArticleAsync(EditArticle editArticle);
    }
}
