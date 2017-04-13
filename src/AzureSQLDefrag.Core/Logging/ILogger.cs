using System;


namespace AzureSQLDefrag.Logging
{
    public interface ILogger
    {
        void Information(string message);
        void Warning(string message);
        void Error(string message);
        void Debug(string message);
        
    }
}
