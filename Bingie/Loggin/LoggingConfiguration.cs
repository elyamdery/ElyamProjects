using Serilog;
using Serilog.Events;
using Serilog.Sinks.File;  // Added for the File sink

namespace Bingie.Logging
{
    public static class LoggingConfiguration
    {
        public static void ConfigureLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.File(Path.Combine(FileSystem.AppDataDirectory, "logs", "bingie-.log"),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: 7)
                .CreateLogger();
        }
    }
}
