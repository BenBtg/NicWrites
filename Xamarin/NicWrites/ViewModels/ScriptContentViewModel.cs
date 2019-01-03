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
    public class ScriptContentViewModel: BaseNicWritesViewModel
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

        public ScriptContentViewModel()
        {
            _nicWritesService = ServiceContainer.Resolve<INicWritesService>();
        }

        public async override Task InitAsync()
        {

            try
            {
                IsBusy = true;
                var result = await _nicWritesService.GetScreenplaysAsync();
                var sourceText = result[2].content;

                Analytics.TrackEvent("ViewScript " + result[2].title);

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Code to run on the main thread
                    WebContent = sourceText;
                    ;
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
