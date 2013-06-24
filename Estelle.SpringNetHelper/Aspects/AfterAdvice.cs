using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Spring.Aop;

namespace Estelle.SpringNetHelper
{
    public class AfterAdvice : IAfterReturningAdvice
    {
        public void AfterReturning(object returnValue, MethodInfo method, object[] args, object target)
        {
            
        }
    }
}
