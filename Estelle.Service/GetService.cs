using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Service
{
    /// <summary>
    /// 从IOC容器中得到服务实例
    /// </summary>
    public class GetService
    {        
        /// <summary>
        /// 得到可以AOP的实例
        /// </summary>
        /// <typeparam name="T">服务接口</typeparam>
        /// <param name="name">服务名称</param>
        /// <returns></returns>
        public static T GetAopService<T>(string name) 
        {
            T command = (T)SpringNetHelper.GetAppContext.ApplicationContext.GetObject(name);            
            return command;
        }
    }
}
