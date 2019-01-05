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

        public ObservableCollection<BaseNavigationViewModel> Categories { get; set; } = new ObservableCollection<BaseNavigationViewModel>();

        public Command CategoryTappedCommand => new Command<BaseNavigationViewModel>(async (category) => await OnCategorySelected(category));
            
        public override async Task InitAsync()
        {
            IsBusy = true;

             _nicWritesService = ServiceContainer.Resolve<INicWritesService>();

            await AddCategory("Articles", () => _nicWritesService.GetArticlesAsync());
            await AddCategory("Play Scripts", () => _nicWritesService.GetScriptsAsync());
            await AddCategory("Promotional Copy", () => _nicWritesService.GetPromoCopyAsync());
            await AddCategory("Screenplays", () => _nicWritesService.GetScreenplaysAsync());
            await AddCategory("Reviews", () => _nicWritesService.GetReviewsAsync());
            await AddCategory("ShortStories", () => _nicWritesService.GetShortStoriesAsync());
            await AddSocialMediaCategory();

            IsBusy = false;
        }

        private async Task AddSocialMediaCategory()
        {
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {

                Categories.Add(new SocialMediaViewModel() { Title = "Social Media" });//, GetData = getDocuments });
            });

        }

        private async Task AddCategory(string categoryName, Func<Task<List<Document>>> getDocuments)
        {
            await Task.Delay(500);
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Categories.Add(new DocumentListViewModel() { Title = categoryName, GetData = getDocuments});
            });
        }

        Task OnCategorySelected(BaseNavigationViewModel user)
        {
            return Navigation.PushAsync(user);
        }
    }
}
