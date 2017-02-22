using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlienGames.MVP.Manage.AddReview
{
    public class AddReviewEventArgs : EventArgs
    {
        public AddReviewEventArgs(
            string coverImageName,
            string coverImageExtension,
            string coverImagePath,
            byte[] coverImageallBytes,
            object userId,
            string title,
            string videoUrl,
            string description)
        {
            if (coverImageName==null)
            {
                throw new ArgumentNullException(nameof(coverImageName));
            }

            if (coverImageExtension == null)
            {
                throw new ArgumentNullException(nameof(coverImageExtension));
            }

            if (coverImagePath == null)
            {
                throw new ArgumentNullException(nameof(coverImagePath));
            }

            if (coverImageallBytes == null)
            {
                throw new ArgumentNullException(nameof(coverImageallBytes));
            }

            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId));
            }

            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }
            
            if (videoUrl == null)
            {
                throw new ArgumentNullException(nameof(videoUrl));
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description));
            }
            this.CoverImageName = coverImageName;
            this.CoverImageExtension = coverImageExtension;
            this.CoverImagePath = coverImagePath;
            this.CoverImageAllBytes = coverImageallBytes;
            this.UserId = userId;
            this.Title = title;
            this.VideoUrl = videoUrl;
            this.Description = description;
        }

        public string CoverImageName { get; private set; }

        public string CoverImageExtension { get; private set; }

        public string CoverImagePath { get; private set; }

        public byte[] CoverImageAllBytes { get; private set; }

        public object UserId { get; private set; }

        public string Title { get; private set; }

        public string VideoUrl { get; private set; }

        public string Description { get; private set; }
    }
}
