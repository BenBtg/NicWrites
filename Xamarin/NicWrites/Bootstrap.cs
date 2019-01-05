using System;
using System.Reflection;
using Microsoft.MobCAT;
using Microsoft.MobCAT.Converters;
using Microsoft.MobCAT.Forms.Services;
using Microsoft.MobCAT.MVVM.Abstractions;
using NicWrites.Services;
using NicWrites.Views;

namespace NicWrites
{
    public static class Bootstrap
    {
        public static void Begin(Action platformSpecificBegin = null)
        {
            ServiceContainer.Register<INicWritesService>(() => new NicWritesService($"https://nicwrites.azurewebsites.net/api/", $"CfDJ8AAAAAAAAAAAAAAAAAAAAACpRztfyANVnluz9F8v0I8FciKY9zhzajf8D5U79StiK8Kf1E8iqPCPzS - i8nzDoa6bPZR2bCndxyJ7dao5zJfvZCHlm_58RR6eshNesHGIqtqregXHVZYFzvTvlNwmpsO3xiCegULkXmjbgTJ - sXjGJ1LcsyQa6Jk5vkCmFoRyENn_Wwm1THfgLw99IXcJ_DNqI6zc8viRA4qHWLXzNKaJUykqt3zYhD1UpDgrfJqUUfCvPz_syPJI27K1GYEl9BaA8ODjqZUm55vzzaifg09ce7s_5JjjD0c2exOWeQiQC6RH0ABiBe_My6_76CASs2AaHaLrsb49S54l1gR6jlVQ2UiTD02yrdmp2kRTkapj2A"));
            ServiceContainer.Register<INicWritesBlobService>(() => new NicWritesBlobService($"https://nicwritessa.blob.core.windows.net", $"CfDJ8AAAAAAAAAAAAAAAAAAAAACpRztfyANVnluz9F8v0I8FciKY9zhzajf8D5U79StiK8Kf1E8iqPCPzS - i8nzDoa6bPZR2bCndxyJ7dao5zJfvZCHlm_58RR6eshNesHGIqtqregXHVZYFzvTvlNwmpsO3xiCegULkXmjbgTJ - sXjGJ1LcsyQa6Jk5vkCmFoRyENn_Wwm1THfgLw99IXcJ_DNqI6zc8viRA4qHWLXzNKaJUykqt3zYhD1UpDgrfJqUUfCvPz_syPJI27K1GYEl9BaA8ODjqZUm55vzzaifg09ce7s_5JjjD0c2exOWeQiQC6RH0ABiBe_My6_76CASs2AaHaLrsb49S54l1gR6jlVQ2UiTD02yrdmp2kRTkapj2A"));
          
            var navigationService = new NavigationService();
            navigationService.RegisterViewModels(typeof(MainPage).GetTypeInfo().Assembly);
            navigationService.RegisterViewModels(typeof(DocumentListPage).GetTypeInfo().Assembly);
            navigationService.RegisterViewModels(typeof(SocialMediaPage).GetTypeInfo().Assembly);

            ServiceContainer.Register<INavigationService>(navigationService);

            platformSpecificBegin?.Invoke();
        }
    }
}