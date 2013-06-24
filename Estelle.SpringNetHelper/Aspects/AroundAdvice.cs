using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;

namespace Estelle.SpringNetHelper
{
    public class AroundAdvice : IMethodInterceptor
    {
        public object Invoke(IMethodInvocation invocation)
        {            
            //开始 ...
            object result = invocation.Proceed();            
            //结束 ...

            return result;
        }
    }
}
