using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using NicWrites.Models;
using NicWrites.Services;
using Microsoft.MobCAT.MVVM;

namespace NicWrites.ViewModels
{
    public class BaseNicWritesViewModel : BaseNavigationViewModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore();

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { RaiseAndUpdate(ref title, value); }
        }

    }
}
