using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Mapping.Attributes;
using Spring.Data.NHibernate;

namespace Estelle.Dao
{
    public class MyLocalSessionFactoryObject : LocalSessionFactoryObject
    {
        /// <summary>
        /// 实体类所在的程序集的名称
        /// </summary>
        public string[] ModelAssemblyName { get; set; }

        protected override void PostProcessConfiguration(Configuration config)
        {
            base.PostProcessConfiguration(config);

            MemoryStream stream = new MemoryStream();
            HbmSerializer.Default.Validate = true;
            foreach (string modelAssemblyName in ModelAssemblyName)
            {
                Assembly assembly = Assembly.Load(modelAssemblyName);
                HbmSerializer.Default.Serialize(stream, assembly);
                stream.Position = 0;
                config.AddInputStream(stream);
            }
        }
    }

}
