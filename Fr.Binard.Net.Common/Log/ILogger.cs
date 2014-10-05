using System;

namespace Fr.Binard.Net.Common.Log
{
    public interface ILogger
    {
        void Debug(string message);
        void Info(string message);
        void Error(string message);
        void Error(Exception ex);
        void Fatal(string message);
        void Fatal(Exception ex);
    }
}