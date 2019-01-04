using System;
using System.Collections.Generic;
using Microsoft.MobCAT.Forms.Pages;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace NicWrites.Views
{
    public partial class MainPage : BaseContentPage<ViewModels.MenuViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);
        }
    }
}
