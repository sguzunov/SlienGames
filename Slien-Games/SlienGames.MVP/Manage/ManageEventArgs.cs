using System;

namespace SlienGames.MVP.Manage
{
    public class ManageEventArgs : EventArgs
    {

        public ManageEventArgs(object id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            this.Id = id;
        }
        public object Id { get; private set; }
    }
}