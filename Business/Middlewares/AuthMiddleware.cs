using Core.Abstracts;
using Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Business.Middlewares
{
    public class AuthMiddleware
    {
        private readonly IUnitOfWork unitOfWork = new UnitOfWork();

        public IPrincipal GetPrincipal(string username)
        {
            var user = unitOfWork.AppUserManager.FindByName(username);
            if (user == null) return null;

            var roles = unitOfWork.AppUserManager.GetRoles(user.Id).ToArray();

            return new GenericPrincipal(new GenericIdentity(user.UserName), roles);
        }

    }
}
