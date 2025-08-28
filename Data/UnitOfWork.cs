using Core.Abstracts;
using Core.Abstracts.IRepositories;
using Data.Contexts;
using Data.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NewsContext context = NewsContext.Instance;
        public UserManager<IdentityUser> AppUserManager => new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        public RoleManager<IdentityRole> AppRoleManager => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


        //Prototype Design Pattern: Repository örneği varsa onu kullanır yoksa veya değişmişse yenisini oluşturur.
        private IArticleRepository articleRepository;
        public IArticleRepository ArticleRepository => articleRepository = articleRepository ?? new ArticleRepository(context);

        private ICategoryRepository categoryRepository;
        public ICategoryRepository CategoryRepository => categoryRepository = categoryRepository ?? new CategoryRepository(context);

        private ITagRepository tagRepository;
        public ITagRepository TagRepository => tagRepository = tagRepository ?? new TagRepository(context);

        private ISettingsRepository settingsRepository;
        public ISettingsRepository SettingsRepository => settingsRepository = settingsRepository ?? new SettingsRepository(context);

        private IMemberRepository memberRepository;
        public IMemberRepository MemberRepository => memberRepository = memberRepository ?? new MemberRepository(context);

        public async Task CommitAsync()
        {
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
