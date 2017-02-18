using System;

namespace SlienGames.MVP.Manage
{
    public class ManageEventArgs : EventArgs
    {
        public ManageEventArgs(object id)
        {
            this.Id = id;
        }
        public object Id { get; private set; }
    }
}