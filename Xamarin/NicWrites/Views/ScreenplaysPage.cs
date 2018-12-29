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
        WebView _webView;
        public ScreenplaysPage()
        {

            //_webView = new WebView() { HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.AliceBlue };

            //Content =
            _webView = new WebView();



            Content = _webView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "WebContent")
            {
                var htmlSource = new HtmlWebViewSource();
                htmlSource.Html = ViewModel.WebContent;

                _webView.Source = htmlSource;

                //_webView.Source = new HtmlWebViewSource
                //{
                //    Html = ViewModel.WebContent
                //};
            }
        }

    }
}

