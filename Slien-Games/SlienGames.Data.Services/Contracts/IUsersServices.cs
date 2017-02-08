using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface IUsersServices
    {
        User GetUserInfo(int id);
    }
}
