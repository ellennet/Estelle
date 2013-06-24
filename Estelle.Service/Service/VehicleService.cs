using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estelle.SpringNetHelper;

namespace Estelle.Service
{
    public class VehicleService : IService.IVehicleService
    {
        //被注入的Dao
        public IDao.IVehicleBrandDao VehicleBrandDao { get; set; } 
        public IDao.IVehicleTypeDao VehicleTypeDao { get; set; }

        /// <summary>
        /// 新增一个品牌
        /// </summary>
        /// <param name="VehicleBrandModel">品牌信息数据</param>
        /// <returns></returns>
        [LoggingAttributes]
        public object AddVehicleBrand(Models.VehicleBrand VehicleBrandModel)
        {
            Domain.Vehicles.VehicleBrand VehicleBrand = new Domain.Vehicles.VehicleBrand();

            VehicleBrand.BrandName = VehicleBrandModel.BrandName;
            VehicleBrand.Nationality = VehicleBrandModel.Nationality;
            VehicleBrand.DateCreated = VehicleBrandModel.DateCreated;
            VehicleBrand.BrandID = VehicleBrandModel.BrandID;

            return VehicleBrandDao.Save(VehicleBrand);
        }

        /// <summary>
        /// 新增一个型号
        /// </summary>
        /// <param name="VehicleTypeModel">型号信息</param>
        /// <returns></returns>
        [LoggingAttributes]
        public object AddVehicleType(Models.VehicleType VehicleTypeModel)
        {            
            //根据品牌名称得到品牌ID
            Guid VehicleBrandID = VehicleBrandDao.GetVehicleBrandID(VehicleTypeModel.BrandName);

            if (VehicleBrandID != Guid.Empty)
            {
                Domain.Vehicles.VehicleType VehicleType = new Domain.Vehicles.VehicleType();

                VehicleType.TypeID = VehicleTypeModel.TypeID;
                VehicleType.BrandID = VehicleBrandID;
                VehicleType.Type = VehicleTypeModel.Type;
                VehicleType.EngineDisplacement = VehicleTypeModel.EngineDisplacement;
                VehicleType.Turbo = VehicleTypeModel.Turbo;

                return VehicleTypeDao.Save(VehicleType);
            }
            else
            {
                return null;
            }            
        }

        /// <summary>
        /// 列出所有型号
        /// </summary>
        /// <returns>集合</returns>
        [LoggingAttributes]
        public List<Models.VehicleInfo> ListAllVehicle()
        {
            List<Models.VehicleInfo> VehicleList = new List<Models.VehicleInfo>();            
            List<Domain.Vehicles.VehicleType> VehicleTypeList = VehicleTypeDao.LoadAll().ToList();

            VehicleTypeList.ForEach(list =>
            {
                Models.VehicleInfo VehicleInfo = new Models.VehicleInfo();
                                
                VehicleInfo.BrandName = list.CurrentVehicleBrand.BrandName;
                VehicleInfo.Nationality = list.CurrentVehicleBrand.Nationality;

                VehicleInfo.Type = list.Type;
                VehicleInfo.EngineDisplacement = list.EngineDisplacement;
                VehicleInfo.Turbo = list.Turbo;

                VehicleList.Add(VehicleInfo);
            });

            return VehicleList;
        }
    }
}
