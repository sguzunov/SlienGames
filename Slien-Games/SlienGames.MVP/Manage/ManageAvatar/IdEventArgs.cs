using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.MVP.Manage.ManageAvatar
{
    public class IdEventArgs : EventArgs
    {
        public IdEventArgs(object id)
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
