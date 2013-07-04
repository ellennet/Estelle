using System;
using NUnit.Framework;
using Spring.Testing.NUnit;

namespace Estelle.Tests
{
    [TestFixture]
    public class DaoTests : AbstractDaoTests
    {
        public IDao.IVehicleBrandDao VehicleBrandDao { get; set; }
        public IDao.IVehicleTypeDao VehicleTypeDao { get; set; }

        [Test]
        public void DaoInjectionTest()
        {
            Assert.IsNotNull(VehicleBrandDao);
            Assert.IsNotNull(VehicleTypeDao);
        }
    }
}
