using System;
using WebFormsMvp;

namespace SlienGames.MVP.Home
{
    public interface IHomeView : IView<HomeModel>
    {
        event EventHandler GetTopUsers;
    }
}
