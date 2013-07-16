using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace Estelle.Domain.Vehicles
{
    [Class(Table = "VehicleType", NameType = typeof(VehicleType), Lazy = false)]
    public class VehicleType
    {
        /// <summary>
        /// 型号ID
        /// </summary>
        [Id(0, Name = "TypeID", Column = "TypeID", TypeType = typeof(Guid))]
        [Generator(1, Class = "guid")]
        public virtual Guid TypeID { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [PropertyAttribute(Column = "Version ", TypeType = typeof(Int32))]
        public virtual int Version { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        [PropertyAttribute(Column = "Type ", Length = 50, TypeType = typeof(String))]
        public virtual string Type { get; set; }

        /// 排量
        /// <summary>
        /// </summary>
        [PropertyAttribute(Column = "EngineDisplacement ", TypeType = typeof(Double))]
        public virtual double EngineDisplacement { get; set; }

        /// <summary>
        /// 是否增压
        /// </summary>
        [PropertyAttribute(Column = "Turbo ", TypeType = typeof(Boolean))]
        public virtual bool Turbo { get; set; }

        /// <summary>
        /// 品牌信息
        /// </summary>
        [ManyToOne(0, Name = "CurrentVehicleBrand", ClassType = typeof(VehicleBrand), Column = "BrandID")]
        [KeyManyToOne(1, Column = "BrandID")]
        public virtual VehicleBrand CurrentVehicleBrand { get; set; }
    }
}
