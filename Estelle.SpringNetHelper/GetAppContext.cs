using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Core;
using Spring.Context;
using Spring.Context.Support;
using Spring.Core.IO;
using Spring.Objects.Factory;
using Spring.Objects.Factory.Xml;
using System.Configuration;

namespace Estelle.SpringNetHelper
{
    public class GetAppContext
    {
        private static IApplicationContext applicationContext = null;

        public GetAppContext()
        {            
        }

        public static IApplicationContext ApplicationContext
        {
            get
            {
                applicationContext = ConfigurationManager.GetSection("spring/context") as IApplicationContext;                              
                return applicationContext;
            }
        }
    }    
}
