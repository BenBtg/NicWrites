using System;

using Xamarin.Forms;

namespace NicWrites.Views
{
    public class ScreenplaysPage : ContentPage
    {
        public ScreenplaysPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Screenplays" }
                }
            };
        }
    }
}

