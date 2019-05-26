using System;
using Xamarin.Forms;

namespace NicWrites.Controls
{
    public class ScriptNavigationPage : NavigationPage
    {
        public ScriptNavigationPage(Page root) : base(root)
        {
            BarTextColor = Color.Black;
            BackgroundColor = Color.White;
        }
    }
}
