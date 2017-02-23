using System;

namespace SlienGames.MVP.Manage.ManageAvatar
{
    public class ManageAvatarEventArgs : EventArgs
    {
        public ManageAvatarEventArgs(string fileName, string fileExtension, string filePath, byte[] allBytes, object userId)
        {
            if (fileName == null)
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (fileExtension == null)
            {
                throw new ArgumentNullException(nameof(fileExtension));
            }

            if (filePath == null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            if (allBytes == null)
            {
                throw new ArgumentNullException(nameof(allBytes));
            }

            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

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

        public object UserId { get; private set; }
    }
}