using System;
using System.Collections.Generic;
using System.Text;

namespace NicWrites.Models
{
    public enum MenuItemType
    {
        Browse,
        Stories,
        About,
        ScreenPlays,
        SocialMedia,
        Copy
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
