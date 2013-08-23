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
        /// 根据ID得到品牌数据
        /// </summary>
        /// <param name="BrandID">品牌ID</param>
        /// <returns></returns>
        Models.VehicleBrand GetVehicleBrandByID(Guid BrandID);

        /// <summary>
        /// 更新品牌信息
        /// </summary>
        /// <param name="VehicleBrandModel"></param>
        void UpdateVehicleBrand(Models.VehicleBrand VehicleBrandModel);

        /// <summary>
        /// 新增一个型号
        /// </summary>
        /// <param name="VehicleTypeModel">型号信息</param>
        /// <returns></returns>
        object AddVehicleType(Models.VehicleType VehicleTypeModel);

        /// <summary>
        /// 列出所有品牌
        /// </summary>
        /// <returns></returns>
        List<Models.VehicleBrand> ListAllBrand();

        /// <summary>
        /// 列出所有型号
        /// </summary>
        /// <returns>集合</returns>
        List<Models.VehicleInfo> ListAllInfo();

        /// <summary>
        /// 列出所有德国品牌且排量大于等于1.8的型号
        /// </summary>
        /// <returns></returns>        
        List<Models.VehicleInfo> ListAllTypeWithGermanyGT18();
    }
}
