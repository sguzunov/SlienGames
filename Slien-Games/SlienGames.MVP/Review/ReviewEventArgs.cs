using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.MVP.Review
{
    public class ReviewEventArgs : EventArgs
    {
        public ReviewEventArgs(object id)
        {
            this.Id = id;
        }
        public object Id { get; set; }
    }
}
