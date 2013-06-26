using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.IDao
{
    public interface IVehicleTypeDao : IRepository<Domain.Vehicles.VehicleType>
    {
        /// <summary>
        /// 列出所有排量大于等于1.8的型号及品牌
        /// </summary>
        /// <returns></returns>
        IList<Domain.Vehicles.VehicleType> ListAllTypeWithGermanyGT18();
    }
}
