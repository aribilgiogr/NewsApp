using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Data;
using Data.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using System.Web.Security;

namespace Business.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();
        private readonly UserManager<IdentityUser> userManager;

        public MembershipService()
        {
            var userStore = new UserStore<IdentityUser>(NewsContext.Instance);
            userManager = new UserManager<IdentityUser>(userStore);
        }

        public Task<MemberProfile> GetProfile(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> LoginAsync(string username, string password, bool rememberMe)
        {
            var user = await userManager.FindAsync(username, password);
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(username, rememberMe);
                return true;
            }
            return false;
        }

        public async Task LogoutAsync()
        {
            await Task.Run(() => FormsAuthentication.SignOut());
        }

        public async Task<bool> RegisterAsync(string email, string username, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            var result = userManager.Create(user, password);
            if (result.Succeeded)
            {
                var member = new Member { UserId = user.Id };
                await unitOfWork.MemberRepository.InsertOneAsync(member);
                await unitOfWork.CommitAsync();
                return true;
            }
            return false;
        }

        public Task<bool> UpdateProfile(MemberProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}
