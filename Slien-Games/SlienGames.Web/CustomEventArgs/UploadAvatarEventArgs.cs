using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SlienGames.Web.CustomEventArgs
{
    public class UploadAvatarEventArgs : EventArgs
    {
        public UploadAvatarEventArgs(string fileName, string fileExtension,string filePath, byte[] allBytes, object userId)
        {
            this.FileName = fileName;
            this.FileExtension = fileExtension;
            this.AllBytes = allBytes;
            this.FilePath = filePath;
            this.UserId = userId;
        }
        public string FileName { get; private set; }

        public string FileExtension { get; private set; }

        public byte[] AllBytes { get; private set; }

        public string FilePath { get; private set; }

        public object UserId { get; set; }

    }
}