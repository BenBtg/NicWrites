using System;
using System.Collections.ObjectModel;
using Microsoft.MobCAT;
using NicWrites.Models;
using NicWrites.Services;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace NicWrites.ViewModels
{
    public class SocialMediaViewModel: BaseNicWritesViewModel
    { 
        public object ViewModel
        {
            get;
            set;
        }

        private int _currentPosition;
        public int CurrentPosition
        {
            get { return _currentPosition; }
            set { RaiseAndUpdate(ref _currentPosition, value); }
        }

        public ObservableCollection<SocialPost> SocialPosts { get; set; }

        private INicWritesService _nicWritesService;

        public SocialMediaViewModel()
        {
            SocialPosts = new ObservableCollection<SocialPost>();

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
                var result = await _nicWritesService.GetSocialPhotosAsync();

                MainThread.BeginInvokeOnMainThread(() =>
                {
                   
                foreach (Blob blob in result.Blobs.Blob)
                {
                    SocialPosts.Add(new SocialPost(blob.Url));
                }
                    // Code to run on the main thread
                });
            }
            catch(Exception ex)
            {
                Logger.Debug(ex.Message, ex);
            }
        }

    }
}
