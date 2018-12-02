using System;

namespace NicWrites.Models
{
    public class SocialPost
    {
        public SocialPost(string url)
        {
            Photo = url ?? throw new ArgumentNullException(nameof(url));
        }

        public string Title { get; set; }
        public string Photo { get; set; }
    }
}