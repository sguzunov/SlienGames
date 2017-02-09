using System;
using WebFormsMvp;

namespace SlienGames.Web.Factories
{
    public interface ICustomPresenterFactory
    {
        IPresenter GetPresenter(Type presenterType, IView viewInstance); 
    }
}
