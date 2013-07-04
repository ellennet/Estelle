﻿using System;
using NUnit.Framework;
using Spring.Testing.NUnit;

namespace Estelle.Tests
{
    [TestFixture]
    public class ServiceTests : AbstractDaoTests
    {
        public IService.IVehicleService VehicleService { get; set; }        

        [Test]
        public void ServiceInjectionTest()
        {
            Assert.IsNotNull(VehicleService);            
        }

        [Test]
        public void ServiceDataTest()
        {
            Assert.Greater(VehicleService.ListAllInfo().Count, 0);            
        }
    }
}
