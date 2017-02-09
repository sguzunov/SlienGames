using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.Web.Services.Contracts
{
    public interface IFileSaver
    {
        void SaveFile(string filePath, byte[] allBytes);
    }
}
