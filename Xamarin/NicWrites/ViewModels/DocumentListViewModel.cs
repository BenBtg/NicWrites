using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AppCenter.Analytics;
using Microsoft.MobCAT;
using Microsoft.MobCAT.MVVM;
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

        public Command DocTappedCommand => new Command<DocumentContentViewModel>(async (doc) => await OnDocSelected(doc));

        public ObservableCollection<DocumentContentViewModel> _docList = new ObservableCollection<DocumentContentViewModel>();

        public ObservableCollection<DocumentContentViewModel> DocList
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
                var data = await GetData.Invoke();
                foreach(var doc in data)
                {
                    var docContent = new DocumentContentViewModel() { Document = doc };
                    DocList.Add(docContent);
                }
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

        Task OnDocSelected(DocumentContentViewModel doc)
        {
            return Navigation.PushAsync(doc);
        }
    }
}