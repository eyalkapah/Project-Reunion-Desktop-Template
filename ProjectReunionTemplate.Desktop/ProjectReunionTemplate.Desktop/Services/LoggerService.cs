using System;
using Windows.Storage;
using ProjectReunionTemplate.Core.Interfaces;
using Serilog;

namespace ProjectReunionTemplate.Desktop.Services
{
    public class LoggerService : ILoggerService
    {
        public LoggerService()
        {
            var folder = ApplicationData.Current.LocalFolder;
            var fullPath = System.IO.Path.Combine(folder.Path, "Logs", "App.log");

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console()
                .WriteTo.File(fullPath)
                .CreateLogger();
        }

        public void Verbose(Exception exception, string message)
        {
            Log.Verbose(exception, message);
        }

        public void Verbose(string message)
        {
            Log.Verbose(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }

        public void Error(string message)
        {
            Log.Error(message);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }
    }
}
