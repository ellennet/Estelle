using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;

namespace Estelle.Dao
{
    [Repository]
    public class VehicleBrandDao : Repository<Domain.Vehicles.VehicleBrand>, IDao.IVehicleBrandDao
    {        
        /// <summary>
        /// 根据品牌名称得到品牌ID
        /// </summary>
        /// <param name="BrandName">品牌名称</param>
        /// <returns></returns>
        [Transaction(ReadOnly = true)]
        public Guid GetVehicleBrandID(string BrandName)
        {            
            IList<Domain.Vehicles.VehicleBrand> VehicleBrandList = base.Session.QueryOver<Domain.Vehicles.VehicleBrand>().Where(w => w.BrandName == BrandName).List().ToList();            
            Guid ret = (VehicleBrandList.Count == 1) ? VehicleBrandList[0].BrandID : Guid.Empty;
            return ret;            
        }
    }
}
