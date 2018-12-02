using System;
using Microsoft.MobCAT;
using NicWrites.Services;

namespace NicWrites
{
    public static class Bootstrap
    {
        public static void Begin(Action platformSpecificBegin = null)
        {
            ServiceContainer.Register<INicWritesService>(() => new NicWritesService($"https://nicwritessa.blob.core.windows.net/"));

            platformSpecificBegin?.Invoke();
        }
    }
}