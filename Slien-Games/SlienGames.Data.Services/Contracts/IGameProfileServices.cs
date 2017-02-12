using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface IGameProfileServices
    {
        GameProfile GetProfileInfoByName(string gameName);
    }
}
