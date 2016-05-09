using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationwideNannies.Logging
{
    /// <summary> 
    /// Static class logger using Log4Net
    /// </summary> 
    public static class Log4NetLogger
    {
        #region Members

        /// <summary> 
        /// Create a logger for this static class
        /// </summary> 
        private static readonly ILog logger = LogManager.GetLogger(typeof(Log4NetLogger));

        #endregion Members

        #region Constructors

        /// <summary> 
        /// On construct - build logger object 
        /// </summary> 
        static Log4NetLogger()
        {
            XmlConfigurator.Configure();
        }

        #endregion Constructors

        #region Class Methods

        public static void ExceptionTrace(Exception ex, string message)
        {
            message = string.Format("{3} -- {0}{2}{1}{2}", ex.Message, ex.StackTrace, Environment.NewLine, message);
            if (ex.InnerException != null)
            {
                message = string.Format("{0}{1}{2}", message, ex.InnerException.ToString(), Environment.NewLine);
            }

            WriteLog(LogLevel.Error, message);

        }

        /// <summary> 
        /// Write information to log 
        /// </summary> 
        /// <param name="logLevel">Level of information to write</param> 
        /// <param name="message">Information to write to log</param> 
        public static void WriteLog(LogLevel logLevel, String message)
        {
            if (logLevel.Equals(LogLevel.Debug))
            {
                logger.Debug(message);
            }
            else if (logLevel.Equals(LogLevel.Error))
            {
                logger.Error(message);
            }
            else if (logLevel.Equals(LogLevel.Fatal))
            {
                logger.Fatal(message);
            }
            else if (logLevel.Equals(LogLevel.Info))
            {
                logger.Info(message);
            }
            else if (logLevel.Equals(LogLevel.Warn))
            {
                logger.Warn(message);
            }
        }

        #endregion Class Methods
    }

    /// <summary> 
    /// Priority level of the information to be logged 
    /// </summary> 
    public enum LogLevel
    {
        Debug = 1,
        Error,
        Fatal,
        Info,
        Warn
    }

}
