using SlienGames.Data.Models;

namespace SlienGames.Data.Services.Contracts
{
    public interface IGameProfileServices
    {
        GameDetails GetProfileInfoByName(string gameName);
    }
}
