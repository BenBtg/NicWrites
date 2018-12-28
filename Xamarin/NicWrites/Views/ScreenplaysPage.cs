using System;
using Microsoft.MobCAT;
using Microsoft.MobCAT.Forms.Pages;
using NicWrites.Services;
using NicWrites.ViewModels;
using Xamarin.Forms;

namespace NicWrites.Views
{
    public class ScreenplaysPage : BaseContentPage<ScreenplaysViewModel>
    {

        public ScreenplaysPage()
        {
            var webView = new WebView();
            webView.SetBinding(WebView.SourceProperty, "WebContent");
            Content = new StackLayout
            {
                Children = {
                    webView
                }
            };
        }
    }
}

