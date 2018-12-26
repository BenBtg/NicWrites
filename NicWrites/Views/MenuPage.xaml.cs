using Microsoft.MobCAT.Forms.Pages;
using NicWrites.Models;
using NicWrites.ViewModels;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NicWrites.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : BaseContentPage<MenuViewModel>
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.About, Title="About Nic" },
                new HomeMenuItem {Id = MenuItemType.Stories, Title="Short Stories" },
                new HomeMenuItem {Id = MenuItemType.ScreenPlays, Title="Screenplays" },
                new HomeMenuItem {Id = MenuItemType.SocialMedia, Title="Social Media" },
                new HomeMenuItem {Id = MenuItemType.Copy, Title="Copy" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}