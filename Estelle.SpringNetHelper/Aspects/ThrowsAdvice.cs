using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Spring.Aop;
using log4net;
using log4net.Core;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"bin\\Log4Net.config", Watch = true)]
namespace Estelle.SpringNetHelper
{
    public class ThrowsAdvice : IThrowsAdvice
    {
        private ILog logger;
        public ThrowsAdvice()
        {
            logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("Log4Net.config"));
        }

        public void AfterThrowing(Exception ex)
        {
            logger.Warn(String.Format("异常的内容为: {0}", ex));            
        }
    }
}
