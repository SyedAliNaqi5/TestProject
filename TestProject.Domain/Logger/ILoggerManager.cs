using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Domain.Logger
{
    public interface ILoggerManager
    {
        //Useful while developing the application.
        void LogDebug(string message);

        //A general Message
        void LogInfo(string message);

        // Used for unexpected events.
        void LogWarn(string message);

        //The entire trace of the codebase.
        void LogTrace(string message);

        //When something breaks.
        void LogException(Exception exception, string message = null);

        //When something very crucial breaks
        void LogFatal(string message);
    }
}
