using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.IService
{
    public interface IVehicleService
    {        
        /// <summary>
        /// 新增一个品牌
        /// </summary>
        /// <param name="VehicleBrandModel">品牌信息</param>
        /// <returns></returns>
        object AddVehicleBrand(Models.VehicleBrand VehicleBrandModel);

        /// <summary>
        /// 新增一个型号
        /// </summary>
        /// <param name="VehicleTypeModel">型号信息</param>
        /// <returns></returns>
        object AddVehicleType(Models.VehicleType VehicleTypeModel);

        /// <summary>
        /// 列出所有型号
        /// </summary>
        /// <returns>集合</returns>
        List<Models.VehicleInfo> ListAllVehicle();
    }
}
