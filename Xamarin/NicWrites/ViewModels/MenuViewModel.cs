using System;
using Microsoft.MobCAT.MVVM;

namespace NicWrites.ViewModels
{
    public class MenuViewModel: BaseNicWritesViewModel
    {
        public Command StoriesCommand => new Command(async () => await Navigation.PushAsync(new ScriptContentViewModel()));
        public Command SocialCommand => new Command(async () => await Navigation.PushAsync(new SocialMediaViewModel()));
        public Command ScriptsCommand => new Command(async () => await Navigation.PushAsync(new ScriptContentViewModel()));
        public Command ArticlesCommand => new Command(async () => await Navigation.PushAsync(new ScriptContentViewModel()));
    }
}
