﻿using System;

namespace MobilePoll.Infrastructure.Logging
{
    public static class LogFactory
    {
        /// <summary>
        /// Initializes static members of the LogFactory class.
        /// </summary>
        static LogFactory()
        {
            var logger = new NullLogger();
            BuildLogger = type => logger;
        }

        /// <summary>
        /// Gets or sets the log builder of the configured logger.  This should be invoked to return a new logging instance.
        /// </summary>
        public static Func<Type, ILogger> BuildLogger { get; set; }

        private class NullLogger : ILogger
        {
            private readonly Type typeToLog;

            public NullLogger()
            {
                typeToLog = GetType();
            }

            public void Debug(string message, params object[] values)
            {
                System.Diagnostics.Debug.WriteLine(message.FormatMessage(typeToLog, values));
            }

            public void Info(string message, params object[] values)
            {
                System.Diagnostics.Debug.WriteLine(message.FormatMessage(typeToLog, values));
            }

            public void Warn(string message, params object[] values)
            {
                System.Diagnostics.Debug.WriteLine(message.FormatMessage(typeToLog, values));
            }

            public void Error(string message, params object[] values)
            {
                System.Diagnostics.Debug.WriteLine(message.FormatMessage(typeToLog, values));
            }

            public void Fatal(string message, params object[] values)
            {
                System.Diagnostics.Debug.WriteLine(message.FormatMessage(typeToLog, values));
            }

            private void Log(string message, params object[] values)
            {
                System.Diagnostics.Debug.WriteLine(message.FormatMessage(typeToLog, values));
            }
        }
    }
}