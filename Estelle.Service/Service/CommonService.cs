using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estelle.IService;

namespace Estelle.Service
{
    public class CommonService : ICommonService
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}
