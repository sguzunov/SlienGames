using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Data.Models
{
    public class ReviewImage : FileInfo
    {
        public int? ReviewId { get; set; }
        public virtual Review Review { get; set; }
    }
}
