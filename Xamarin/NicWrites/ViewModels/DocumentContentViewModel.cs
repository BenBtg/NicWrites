using System;
using System.Collections.ObjectModel;
using Microsoft.MobCAT;
using NicWrites.Models;
using NicWrites.Services;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;

namespace NicWrites.ViewModels
{
    public class DocumentContentViewModel: BaseNicWritesViewModel
    { 
        public object ViewModel
        {
            get;
            set;
        }
        public Document Document { get; set; }
        public string DocText
        {
            get => _webContent;
            set { RaiseAndUpdate(ref _webContent, value); }
        }

        private INicWritesBlobService _nicWritesService;

        string _webContent;

        public DocumentContentViewModel()
        {

        }

        public async override Task InitAsync()
        {
            try
            {
                _nicWritesService = ServiceContainer.Resolve<INicWritesBlobService>();
                IsBusy = true;
                Title = Document.title;

                Analytics.TrackEvent("ViewScript " + Document.title);

                var docText = await _nicWritesService.GetDocContentAsync(Document.url.PathAndQuery);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Code to run on the main thread
                    DocText = docText;
        
                });
            
            }
            catch (Exception ex)
            {
                Logger.Debug(ex.Message, ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
