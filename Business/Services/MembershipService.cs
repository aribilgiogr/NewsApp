using Core.Abstracts;
using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Data;
using Data.Contexts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using System.Web.Security;
using Utilities.Helpers;
using Utilities.Models;

namespace Business.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public MembershipService()
        {
            userManager = unitOfWork.AppUserManager;
            roleManager = unitOfWork.AppRoleManager;

            if (!roleManager.RoleExists("Member")) roleManager.Create(new IdentityRole("Member"));
            if (!roleManager.RoleExists("Admin")) roleManager.Create(new IdentityRole("Admin"));
            if (!roleManager.RoleExists("Editor")) roleManager.Create(new IdentityRole("Editor"));
        }

        public Task<MemberProfile> GetProfile(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<object>> LoginAsync(string username, string password, bool rememberMe)
        {
            var user = await userManager.FindAsync(username, password);
            if (user == null) return ResponseHelper.Error("Geçersiz kullanıcı adı veya şifre!");

            FormsAuthentication.SetAuthCookie(username, rememberMe);

            return ResponseHelper.Success<object>(user, "Giriş başarılı!");
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        public async Task<ResponseModel<object>> RegisterAsync(string email, string username, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            var result = userManager.Create(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user.Id, "Member");
                var member = new Member { UserId = user.Id };
                await unitOfWork.MemberRepository.InsertOneAsync(member);
                await unitOfWork.CommitAsync();
                return ResponseHelper.Success<object>(null, "Kayıt başarılı.");
            }
            else
            {
                return ResponseHelper.Error(string.Join("\n", result.Errors));
            }
        }

        public Task<bool> UpdateProfile(MemberProfile profile)
        {
            throw new NotImplementedException();
        }
    }
}
