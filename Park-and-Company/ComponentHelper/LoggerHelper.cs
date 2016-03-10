using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;

namespace Park_and_Company.ComponentHelper
{
    public class LoggerHelper
    {
        #region Fields

        private static ILog _logger;
        private static ConsoleAppender _consoleAppender;
        private static RollingFileAppender _rollingFileAppender;

        #endregion

        #region MyRegion

        internal static string Pattern { get; set; } = "%date{ABSOLUTE} [%level] [%method] - %message%newline";

        internal static PatternLayout GetPatternLayout()
        {
            var patternLayout = new PatternLayout()
            {
                ConversionPattern = Pattern
            };

            patternLayout.ActivateOptions();
            return patternLayout;
        }

        #endregion

        #region Private

        private static ConsoleAppender GetConsoleAppender()
        {
            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = GetPatternLayout(),
                Threshold = Level.Info
            };

            consoleAppender.ActivateOptions();
            return consoleAppender;
        }

        private static RollingFileAppender GetRollingFileAppender()
        {
            var rollingFileAppender = new RollingFileAppender()
            {
                Name = "RollingFileAppender",
                AppendToFile = true,
                Threshold = Level.Info,
                Layout = GetPatternLayout(),
                File = "Selenium.log",
                MaximumFileSize = "10MB",
                MaxSizeRollBackups = 10,
                ImmediateFlush = true,
            };

            rollingFileAppender.ActivateOptions();
            return rollingFileAppender;
        }

        #endregion

        #region Public

        public static ILog GetLogger(Type type)
        {
            if (_consoleAppender == null)
                _consoleAppender = GetConsoleAppender();

            if (_rollingFileAppender == null)
                _rollingFileAppender = GetRollingFileAppender();

            if (_logger != null)
                return _logger;

            BasicConfigurator.Configure(_consoleAppender, _rollingFileAppender);
            _logger = LogManager.GetLogger(type);
            return _logger;
        }

        #endregion
    }
}
