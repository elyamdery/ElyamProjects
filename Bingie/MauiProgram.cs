using Microsoft.Extensions.Logging;
using Bingie.Logging;
using Bingie.Services;
using Bingie.Views;
using Bingie.Views.Auth;
using Serilog;

namespace Bingie
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Configure Serilog
            LoggingConfiguration.ConfigureLogging();

            builder.Logging.AddSerilog();

            // Register services
            builder.Services.AddSingleton<IAuthService, AuthService>();
            builder.Services.AddSingleton<IDataStore, DataStore>();

            // Register pages
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<HistoryPage>();
            builder.Services.AddTransient<DayStatisticsPage>();

            return builder.Build();
        }
    }
}