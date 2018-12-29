using System;
using System.Collections.ObjectModel;
using Microsoft.MobCAT;
using NicWrites.Models;
using NicWrites.Services;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace NicWrites.ViewModels
{
    public class ScreenplaysViewModel: BaseNicWritesViewModel
    { 
        public object ViewModel
        {
            get;
            set;
        }

        public string WebContent
        {
            get => _webContent;
            set { RaiseAndUpdate(ref _webContent, value); }
        }

        private INicWritesService _nicWritesService;

        string _webContent;

        public ScreenplaysViewModel()
        {
            _nicWritesService = ServiceContainer.Resolve<INicWritesService>();
        }

        public async override Task InitAsync()
        {
            await GetPhotos();
        }

        private async Task GetPhotos()
        {
            try
            {
                var result = await _nicWritesService.GetScreenplaysAsync();
                var sourceText = result[1].content;

                var fountainDoc = await FountainSharp.FountainDocument.ParseAsync(sourceText);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Code to run on the main thread
                    WebContent = FountainSharp.HtmlFormatter.WriteHtml(fountainDoc);
                });
            }
            catch(Exception ex)
            {
                Logger.Debug(ex.Message, ex);
            }
        }

    }
}
