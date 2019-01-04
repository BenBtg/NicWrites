using System;
using System.Collections.Generic;
using Microsoft.MobCAT.Forms.Pages;
using Xamarin.Forms;

namespace NicWrites.Views
{
    public class DocumentContentPage : BaseContentPage<ViewModels.DocumentContentViewModel>
    {
        FountainView.FountainContentView _fountainContentView;
        public DocumentContentPage()
        {
            _fountainContentView = new FountainView.FountainContentView();
            Content = _fountainContentView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "WebContent")
            {
                await _fountainContentView.SetContent(ViewModel.WebContent);
            }
        }
    }
}
