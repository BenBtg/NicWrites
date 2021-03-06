﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NicWrites.Views;
using NicWrites.ViewModels;
using NicWrites.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NicWrites
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new ScriptNavigationPage(new MainPage() { ViewModel = new MenuViewModel() }) { Title = "Nic Writes", BarTextColor=Color.Black };
            //new ScriptContentPage() { ViewModel = new ViewModels.ScriptContentViewModel() }; //new MainPage() { ViewModel = new SocialMediaViewModel() };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
