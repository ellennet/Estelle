using System;
using NUnit.Framework;
using Spring.Testing.NUnit;

namespace Estelle.Tests
{
    [TestFixture]    
    public abstract class AbstractDaoTests : AbstractDependencyInjectionSpringContextTests
    {
        protected override string[] ConfigLocations
        {
            get
            {
                return new string[]
                    {
                        "assembly://Estelle.SpringNetHelper/Estelle.SpringNetHelper.Config/Aop.xml",
                        "assembly://Estelle.Dao/Estelle.Dao.Config/DBServer.xml",
                        "assembly://Estelle.Dao/Estelle.Dao.Config/Dao.xml",
                        "assembly://Estelle.Service/Estelle.Service.Config/Service.xml"
                    };
            }
        }
    }
}