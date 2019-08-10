using System.Collections.Generic;
using System.Threading.Tasks;
using Allo.Model;

namespace Allo.Services
{
    public interface IUserProfileStore
    {
        Task<IEnumerable<UserProfile>> GetUserCardsAsync(string email);

        Task<UserProfile> GetCardAsync(string id);

        Task<UserProfile> StoreCardAsync(UserProfile card);

        Task<bool> RemoveCardAsync(string id);
    }
}