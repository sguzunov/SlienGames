using System;

namespace SlienGames.Web.CustomEventArgs
{
    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(object id)
        {
            this.Id = id;
        }
        public object Id { get; private set; }
    }
}