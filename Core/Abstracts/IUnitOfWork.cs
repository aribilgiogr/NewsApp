using Core.Abstracts.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        ISettingsRepository SettingsRepository { get; }
        IMemberRepository MemberRepository { get; }
        Task CommitAsync();
    }
}
