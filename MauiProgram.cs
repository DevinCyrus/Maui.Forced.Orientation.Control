using Maui.Forced.Orientation.Control.Controls;
using Maui.Forced.Orientation.Control.ViewModels;
using Microsoft.Extensions.Logging;

namespace Maui.Forced.Orientation.Control
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Register services and view models
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddSingleton<MainPage>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                }).ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler(typeof(OrientationControl), typeof(Maui.Forced.Orientation.Control.Platforms.Android.Handlers.OrientationControlHandler));
#elif IOS
                    handlers.AddHandler(typeof(OrientationControl), typeof(Maui.Forced.Orientation.Control.Platforms.iOS.Handlers.OrientationControlHandler));
#endif
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
