using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estelle.SpringNetHelper;
using Spring.Transaction.Interceptor;

namespace Estelle.Service
{
    public class VehicleService : IService.IVehicleService
    {
        //被注入的Dao
        public IDao.IVehicleBrandDao VehicleBrandDao { get; set; } 
        public IDao.IVehicleTypeDao VehicleTypeDao { get; set; }

        //被注入的Service
        public IService.ICommonService CommonService { get; set; }

        [Transaction]
        public void test()
        {
            Domain.Vehicles.VehicleBrand VehicleBrand = new Domain.Vehicles.VehicleBrand();
            VehicleBrand.BrandName = "abc";
            VehicleBrand.Nationality = "nn";
            VehicleBrand.DateCreated = DateTime.Now;
            VehicleBrandDao.Save(VehicleBrand);

            Domain.Vehicles.VehicleType VehicleType = new Domain.Vehicles.VehicleType();            
            VehicleType.CurrentVehicleBrand = VehicleBrand;
            VehicleType.EngineDisplacement = 1;
            VehicleType.Turbo = false;
            VehicleType.Type = "abc";
            VehicleTypeDao.Save(VehicleType);
        }

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
            
            return VehicleBrandDao.Save(VehicleBrand);
        }

        /// <summary>
        /// 根据ID删除品牌信息
        /// </summary>
        /// <param name="guid"></param>
        [LoggingAttributes]
        public void DelVehicleBrand(object guid)
        {
            VehicleBrandDao.Delete(guid);
        }

        /// <summary>
        /// 根据ID得到品牌数据
        /// </summary>
        /// <param name="BrandID">品牌ID</param>
        /// <returns></returns>
        [LoggingAttributes]
        public Models.VehicleBrand GetVehicleBrandByID(Guid BrandID)
        {            
            Domain.Vehicles.VehicleBrand VehicleBrand = VehicleBrandDao.Load(BrandID);
            Common.SimpleObjectMapper<Domain.Vehicles.VehicleBrand, Models.VehicleBrand> SimpleObjectMapper = new Common.SimpleObjectMapper<Domain.Vehicles.VehicleBrand, Models.VehicleBrand>();
            Models.VehicleBrand VehicleBrandModel = SimpleObjectMapper.ObjectMap(VehicleBrand);
            return VehicleBrandModel;
        }

        /// <summary>
        /// 更新品牌信息
        /// </summary>
        /// <param name="VehicleBrandModel">品牌信息数据</param>
        [LoggingAttributes]
        public void UpdateVehicleBrand(Models.VehicleBrand VehicleBrandModel)
        {            
            Common.SimpleObjectMapper<Models.VehicleBrand, Domain.Vehicles.VehicleBrand> SimpleObjectMapper = new Common.SimpleObjectMapper<Models.VehicleBrand, Domain.Vehicles.VehicleBrand>();
            Domain.Vehicles.VehicleBrand VehicleBrand = SimpleObjectMapper.ObjectMap(VehicleBrandModel);            
            VehicleBrandDao.Update(VehicleBrand);
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

                //VehicleType.BrandID = VehicleBrandID; // 这里需要代入父级实体
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
        /// 列出所有品牌
        /// </summary>
        /// <returns></returns>
        [LoggingAttributes]
        public List<Models.VehicleBrand> ListAllBrand()
        {
            List<Domain.Vehicles.VehicleBrand> VehicleBrandDomainList = VehicleBrandDao.LoadAll().ToList();
            Common.SimpleObjectMapper<Domain.Vehicles.VehicleBrand, Models.VehicleBrand> SimpleObjectMapper = new Common.SimpleObjectMapper<Domain.Vehicles.VehicleBrand, Models.VehicleBrand>();
            List<Models.VehicleBrand> VehicleBrandList=SimpleObjectMapper.ListMap(VehicleBrandDomainList);

            return VehicleBrandList;
        }

        /// <summary>
        /// 列出所有型号
        /// </summary>
        /// <returns>集合</returns>
        [LoggingAttributes]
        public List<Models.VehicleInfo> ListAllInfo()
        {
            List<Domain.Vehicles.VehicleType> VehicleTypeList = VehicleTypeDao.LoadAll().ToList();
            List<Models.VehicleInfo> VehicleList = new List<Models.VehicleInfo>();

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

        /// <summary>
        /// 列出所有德国品牌且排量大于等于1.8的型号
        /// </summary>
        /// <returns></returns>
        [LoggingAttributes]
        public List<Models.VehicleInfo> ListAllTypeWithGermanyGT18()
        {
            List<Domain.Vehicles.VehicleType> VehicleTypeList = VehicleTypeDao.ListAllTypeWithGermanyGT18().ToList();
            List<Models.VehicleInfo> VehicleList = new List<Models.VehicleInfo>();

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
