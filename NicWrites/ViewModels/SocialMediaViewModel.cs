using System;
using System.Collections.ObjectModel;
using Microsoft.MobCAT;
using NicWrites.Models;
using NicWrites.Services;
using System.Linq;

namespace NicWrites.ViewModels
{
    public class SocialMediaViewModel: BaseViewModel
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
            set { SetProperty(ref _currentPosition, value); }
        }

        public ObservableCollection<SocialPost> SocialPosts { get; set; }

        private INicWritesService _nicWritesService;

        public SocialMediaViewModel()
        {
            SocialPosts = new ObservableCollection<SocialPost>();

            _nicWritesService = ServiceContainer.Resolve<INicWritesService>();

            GetPhotos();
        }

        private async void GetPhotos()
        {
            var result = await _nicWritesService.GetSocialPhotosAsync();
            foreach (Blob blob in result.Blobs.Blob)
            {
                SocialPosts.Add(new SocialPost(blob.Url));
            }
        }

    }
}
