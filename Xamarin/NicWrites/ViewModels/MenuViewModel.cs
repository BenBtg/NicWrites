using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.MobCAT;
using Microsoft.MobCAT.MVVM;
using NicWrites.Models;
using NicWrites.Services;
using Xamarin.Essentials;

namespace NicWrites.ViewModels
{
    public class MenuViewModel : BaseNicWritesViewModel
    {
        private INicWritesService _nicWritesService;

        //public Command StoriesCommand => new Command(async () => await Navigation.PushAsync(new DocumentListViewModel("stories")));
        //public Command SocialCommand => new Command(async () => await Navigation.PushAsync(new SocialMediaViewModel()));
        //public Command ScriptsCommand => new Command(async () => await Navigation.PushAsync(new DocumentListViewModel("scripts")));
        //public Command ArticlesCommand => new Command(async () => await Navigation.PushAsync(new ScriptContentViewModel()));

        public ObservableCollection<DocumentListViewModel> Categories { get; set; } = new ObservableCollection<DocumentListViewModel>();

        public Command CategoryTappedCommand
        {
            get
            {
                return new Command<DocumentListViewModel>(async (user) => await OnCategorySelected(user));
            }
        }

        public override async Task InitAsync()
        {
            IsBusy = true;

             _nicWritesService = ServiceContainer.Resolve<INicWritesService>();

            await AddCategory("Articles", () => _nicWritesService.GetScreenplaysAsync());
            await AddCategory("Play Scripts", () => _nicWritesService.GetScriptsAsync());
            await AddCategory("Promotional Copy", () => _nicWritesService.GetPromoCopyAsync());
            await AddCategory("Screenplays", () => _nicWritesService.GetScreenplaysAsync());
            await AddCategory("Reviews", () => _nicWritesService.GetReviewsAsync());
            await AddCategory("ShortStories", () => _nicWritesService.GetShortStoriesAsync());
            await AddCategory("Social Media", () => _nicWritesService.GetSocialPhotosAsync());

            IsBusy = false;
        }

        private async Task AddCategory(string categoryName, Func<Task<List<Document>>> getDocuments)
        {
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Categories.Add(new DocumentListViewModel() { Title = categoryName, GetData = getDocuments});
            });
        }

        Task OnCategorySelected(DocumentListViewModel user)
        {
            return Navigation.PushAsync(user);
        }
    }
}
