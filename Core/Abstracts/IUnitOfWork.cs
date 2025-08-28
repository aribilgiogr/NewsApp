using Core.Abstracts.IRepositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
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

        UserManager<IdentityUser> AppUserManager { get; }
        RoleManager<IdentityRole> AppRoleManager { get; }

        Task CommitAsync();
    }
}
