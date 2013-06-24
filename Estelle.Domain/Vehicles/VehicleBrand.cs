using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Domain.Vehicles
{
    public class VehicleBrand
    {
        /// <summary>
        /// 品牌ID
        /// </summary>
        public virtual Guid BrandID { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public virtual string BrandName { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public virtual string Nationality { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public virtual DateTime DateCreated { get; set; }

        /// <summary>
        /// 下属型号
        /// </summary>
        public virtual IList<VehicleType> VehicleTypeList { get; set; }
    }
}
