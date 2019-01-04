using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.MobCAT;
using NicWrites.Models;
using NicWrites.Services;
using Xamarin.Essentials;

namespace NicWrites.ViewModels
{
    public class DocumentListViewModel : BaseNicWritesViewModel
    {
        //private INicWritesService _nicWritesService;

        public DocType _docType;

        public Func<Task<List<Document>>> GetData { get; internal set; }

        public List<Document> _docList = new List<Document>();

        public List<Document> DocList
        {
            get => _docList;
            set { RaiseAndUpdate(ref _docList, value); }
        }

        public async override Task InitAsync()
        {
            IsBusy = true;
            Analytics.TrackEvent("Navigating " + Title);

            try
            {
                DocList = await GetData.Invoke();
            }
            catch (Exception ex)
            {
                Logger.Debug(ex.Message, ex);
            }
            finally
            {
                IsBusy = false;
            }

          /*  var _nicWritesService = ServiceContainer.Resolve<INicWritesService>();
            try
            {
                IsBusy = true;
                switch (_docType)
                {
                    case DocType.Articles:
                        { docList = await _nicWritesService.GetScreenplaysAsync(); }
                        break;
                    case DocType.PlayScripts:
                        { docList = await _nicWritesService.GetScreenplaysAsync(); }
                        break;
                    case DocType.PromoCopy:
                        { docList = await _nicWritesService.GetScreenplaysAsync(); }
                        break;
                    case DocType.Reviews:
                        { docList = await _nicWritesService.GetScreenplaysAsync(); }
                        break;
                    case DocType.Screenplays:
                        { docList = await _nicWritesService.GetScreenplaysAsync(); }
                        break;
                    case DocType.ShortStories:
                        { docList = await _nicWritesService.GetScreenplaysAsync(); }
                        break;
                }


                //var sourceText = result[2].content;

                //

                //MainThread.BeginInvokeOnMainThread(() =>
                //{
                //    // Code to run on the main thread
                //    WebContent = sourceText;
                //    ;
                //});
                */
            
         
        }
    }
}