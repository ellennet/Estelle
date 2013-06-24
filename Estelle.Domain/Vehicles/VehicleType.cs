using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Domain.Vehicles
{
    public class VehicleType
    {
        /// <summary>
        /// 型号ID
        /// </summary>
        public virtual Guid TypeID { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        public virtual Guid BrandID { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public virtual string Type { get; set; }

        /// 排量
        /// <summary>
        /// </summary>
        public virtual string EngineDisplacement { get; set; }

        /// <summary>
        /// 是否增压
        /// </summary>
        public virtual bool Turbo { get; set; }

        /// <summary>
        /// 品牌信息
        /// </summary>
        public virtual VehicleBrand CurrentVehicleBrand { get; set; }

    }
}
