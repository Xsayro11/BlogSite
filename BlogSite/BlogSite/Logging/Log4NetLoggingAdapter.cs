using log4net;
using log4net.Core;
using System;
using System.Reflection;

namespace BlogSite.Logging
{
    public class Log4NetLoggingAdapter : ILogger
    {
        private readonly ILog _internalLogger;

        public Log4NetLoggingAdapter(ILog internalLogger)
        {
            this._internalLogger = internalLogger;
        }

        public void Write(string message, EventSeverity severity)
        {
            Write(message, null, severity);
        }

        public void Write(string message, Exception exception, EventSeverity severity)
        {
            var level = GetLevelFromSeverity(severity);
            _internalLogger.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, level, message, exception);
        }

        private Level GetLevelFromSeverity(EventSeverity severity)
        {
            switch (severity)
            {
                case EventSeverity.Info:
                    return Level.Info;
                case EventSeverity.Debug:
                    return Level.Debug;
                case EventSeverity.Warning:
                    return Level.Warn;
                case EventSeverity.Fatal:
                    return Level.Fatal;
                case EventSeverity.Error:
                    return Level.Error;
                default:
                    return Level.Info;
            }
        }
    }
}