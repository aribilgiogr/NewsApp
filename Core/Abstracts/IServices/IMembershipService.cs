using Core.Concretes.DTOs;
using System.Threading.Tasks;

namespace Core.Abstracts.IServices
{
    public interface IMembershipService
    {
        Task<bool> LoginAsync(string username,string password, bool rememberMe);
        Task LogoutAsync();
        Task<bool> RegisterAsync(string email, string username, string password);

        Task<MemberProfile> GetProfile(string userId);
        Task<bool> UpdateProfile(MemberProfile profile);
    }
}
