using System;

namespace ProjectReunionTemplate.Core.Interfaces
{
    public interface ILoggerService
    {
        void Verbose(Exception exception, string message);
        void Verbose(string message);
        void Warning(string message);
        void Error(string message);
        void Information(string message);
        void Debug(string message);
    }
}