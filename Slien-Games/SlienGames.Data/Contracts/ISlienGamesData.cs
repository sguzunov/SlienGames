using System;

namespace SlienGames.Data.Contracts
{
    public interface ISlienGamesData : IDisposable
    {
        void Commit();
    }
}
