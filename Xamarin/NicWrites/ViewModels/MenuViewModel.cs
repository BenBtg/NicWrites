using System;
using Microsoft.MobCAT.MVVM;

namespace NicWrites.ViewModels
{
    public class MenuViewModel: BaseNicWritesViewModel
    {
        public Command ScriptCommand => new Command(HandleAction);

        async void HandleAction(object obj)
        {
            await Navigation.PushAsync(new ScriptContentViewModel());
        }


        public MenuViewModel()
        {
        }
    }
}
