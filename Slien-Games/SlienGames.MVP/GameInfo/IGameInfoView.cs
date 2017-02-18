using System;

using WebFormsMvp;

namespace SlienGames.MVP.GameInfo
{
    public interface IGameInfoView : IView<GameInfoModel>
    {
        event EventHandler<GetGameInfoEventArgs> MyInit;
    }
}