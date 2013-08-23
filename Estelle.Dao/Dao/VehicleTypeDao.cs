using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;
using Common.Logging;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;

namespace Estelle.Dao
{
    [Repository]
    public class VehicleTypeDao : Repository<Domain.Vehicles.VehicleType>, IDao.IVehicleTypeDao
    {
        [Transaction(ReadOnly = true)]
        public IList<Domain.Vehicles.VehicleType> ListAllTypeWithGermanyGT18()
        {
            throw new Exception();

            IList<Domain.Vehicles.VehicleType> list = base.Session.QueryOver<Domain.Vehicles.VehicleType>()
             .Where(x => x.EngineDisplacement >= 1.8)
             .Inner.JoinQueryOver<Domain.Vehicles.VehicleBrand>(t => t.CurrentVehicleBrand)
             .Where(y => y.Nationality == "德国")
             .List();

            return list;
        }
    }
}
