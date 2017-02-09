using System;

namespace SlienGames.Web.CustomEventArgs
{
    public class CurrentUserEventArgs : EventArgs
    {
        public CurrentUserEventArgs(object id)
        {
            this.Id = id;
        }
        public object Id { get; private set; }
    }
}