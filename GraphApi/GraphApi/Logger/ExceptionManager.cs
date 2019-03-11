using log4net;
using System;
using System.IO;
using System.Reflection;
using System.Web.Http.ExceptionHandling;

namespace GraphApi.Logger
{
    public interface IExceptionManager
    {
        void Log(string ex);
    }
    public class ExceptionManager : ExceptionLogger, IExceptionManager
    {

        ILog _logger = null;
        public ExceptionManager()
        {
            // directory path  
            var log4NetConfigFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");

            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigFilePath));
        }
        public override void Log(ExceptionLoggerContext context)
        {
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(context.Exception.ToString() + Environment.NewLine);

        }
        public void Log(string ex)
        {
            _logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            _logger.Error(ex);

        }

    }
}