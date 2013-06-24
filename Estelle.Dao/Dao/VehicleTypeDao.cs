using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;
using Common.Logging;
using Spring.Stereotype;

namespace Estelle.Dao
{
    [Repository]
    public class VehicleTypeDao : Repository<Domain.Vehicles.VehicleType>, IDao.IVehicleTypeDao
    {
        
    }
}
