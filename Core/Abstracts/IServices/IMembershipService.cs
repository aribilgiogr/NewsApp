using Core.Concretes.DTOs;
using System.Threading.Tasks;
using Utilities.Models;

namespace Core.Abstracts.IServices
{
    public interface IMembershipService
    {
        Task<ResponseModel<object>> LoginAsync(string username,string password, bool rememberMe);
        void Logout();
        Task<ResponseModel<object>> RegisterAsync(string email, string username, string password);

        Task<MemberProfile> GetProfile(string userId);
        Task<bool> UpdateProfile(MemberProfile profile);
    }
}
