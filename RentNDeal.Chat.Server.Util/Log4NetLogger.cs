namespace RentNDeal.Chat.Server.Util
{
    using System;

    /// <summary>
    /// Represents logger implementation for Log 4 Net.
    /// </summary>
    [Serializable]
    public sealed class Log4NetLogger : ILogger 
    {
        /// <summary>
        /// Logging instance variable.
        /// </summary>
        private static readonly log4net.ILog LoggerObject = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The variable is declared to be volatile to ensure that assigment to the variable
        /// completes before the instance variable can be accessed.
        /// </summary>
        private static volatile Log4NetLogger log4NetInstance;

        /// <summary>
        /// The synchronization object.
        /// </summary>
        private static object syncObject = new object();

        private readonly bool isDebugEnabled;
        private readonly bool isErrorEnabled;
        private readonly bool isInfoEnabled;
        private readonly bool isWarningEnabled;
        private readonly bool isFatalEnabled;

        public Log4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.isDebugEnabled = LoggerObject.IsDebugEnabled;
            this.isInfoEnabled = LoggerObject.IsInfoEnabled;
            this.isWarningEnabled = LoggerObject.IsWarnEnabled;
            this.isErrorEnabled = LoggerObject.IsErrorEnabled;
            this.isFatalEnabled = LoggerObject.IsFatalEnabled;
        }

        public static Log4NetLogger Instance
        {
            get
            {
                if (log4NetInstance == null)
                {
                    lock (syncObject)
                    {
                        if (log4NetInstance == null)
                        {
                            log4NetInstance = new Log4NetLogger();
                        }
                    }
                }

                return log4NetInstance;
            }
        }

        #region ILogger Members

        public void Debug(object message)
        {
            if (this.isDebugEnabled)
            {
                LoggerObject.Debug(message);
            }
        }

        public void Error(string message)
        {
            if (this.isErrorEnabled)
            {
                LoggerObject.Error(message);
            }
        }

        public void Error(Exception exceptionToLog)
        {
            if (this.isErrorEnabled)
            {
                LoggerObject.Error(exceptionToLog);
            }
        }

        public void Error(object message, Exception exception)
        {
            if (this.isErrorEnabled)
            {
                LoggerObject.Error(message, exception);
            }
        }

        public void Info(object message)
        {
            if (this.isInfoEnabled)
            {
                LoggerObject.Info(message);
            }
        }

        public void Warning(object message)
        {
            if (this.isWarningEnabled)
            {
                LoggerObject.Warn(message);
            }
        }

        public void Fatal(object message, string systemAdminEmail)
        {
            if (this.isFatalEnabled && message != null && !string.IsNullOrEmpty(message.ToString()))
            {
                LoggerObject.Fatal(message);

                //// Send email to system admin
                ////EmailNotification email = new EmailNotification(
                ////                                    systemAdminEmail,
                ////                                    systemAdminEmail,
                ////                                    null,
                ////                                    null,
                ////                                    "Fatal Exception in CCSS",
                ////                                    message.ToString(),
                ////                                    "CCSS System",
                ////                                    null,
                ////                                    null,
                ////                                    null);
                ////EmailNotificationManager.Process(email);
            }
        }

        #endregion
    }
}
