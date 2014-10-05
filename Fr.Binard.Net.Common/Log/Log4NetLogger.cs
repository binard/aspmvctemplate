using System;
using System.IO;
using Fr.Binard.Net.Utils;
using Fr.Binard.Net.Utils.Web;
using log4net;
using log4net.Config;

namespace Fr.Binard.Net.Common.Log
{
    public class Log4NetLogger : ILogger, IDisposable
    {
        private readonly ILog _logger;

        public Log4NetLogger()
        {
            _logger = LogManager.GetLogger(this.GetType());
        }

        public static void Configure()
        {
            var fileConfigPath = AppSettingsHelper.GetValue<string>("log4net.Config");
            var fileInfo = new FileInfo(WebPathHelper.GetPhysicalPath(fileConfigPath));
            XmlConfigurator.Configure(fileInfo);
        }

        public void Debug(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(message);
            }
        }


        public void Info(string message)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Info(message);
            }
        }

        public void Error(string message)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(message);
            }
        }

        public void Error(Exception ex)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(ex);
            }
        }

        public void Fatal(string message)
        {
            if (_logger.IsFatalEnabled)
            {
                _logger.Fatal(message);
            }
        }

        public void Fatal(Exception ex)
        {
            if (_logger.IsFatalEnabled)
            {
                _logger.Fatal(ex);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
