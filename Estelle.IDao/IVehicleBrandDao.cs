using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.IDao
{
    public interface IVehicleBrandDao : IRepository<Domain.Vehicles.VehicleBrand>
    {
        /// <summary>
        /// 根据品牌名称得到品牌ID
        /// </summary>
        /// <param name="BrandName">品牌名称</param>
        /// <returns></returns>
        Guid GetVehicleBrandID(string BrandName);
    }
}
