using System;

using WebFormsMvp;

using SlienGames.Web.CustomEventArgs;
using SlienGames.Web.Models;

namespace SlienGames.Web.Views
{
    public interface IGameInfoView : IView<GameInfoModel>
    {
        event EventHandler<GetGameInfoEventArgs> MyInit;
    }
}