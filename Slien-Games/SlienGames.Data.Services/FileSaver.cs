using SlienGames.Data.Services.Contracts;
using System;
using System.IO;

namespace SlienGames.Data.Services
{
    public class FileSaver : IFileSaver
    {
        public void SaveFile(string filePath, byte[] allBytes)
        {
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;
            string actualPath = currentDir + filePath;
            File.WriteAllBytes(actualPath, allBytes);
        }
    }
}