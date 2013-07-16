using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Mapping.Attributes;

namespace Estelle.Domain.Vehicles
{
    [Class(Table = "VehicleBrand", NameType = typeof(VehicleBrand), Lazy = false)]
    public class VehicleBrand
    {
        /// <summary>
        /// 品牌ID
        /// </summary> 
        [Id(0, Name = "BrandID", Column = "BrandID", TypeType = typeof(Guid))]
        [Generator(1, Class = "guid")]
        public virtual Guid BrandID { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        [PropertyAttribute(Column = "Version ", TypeType = typeof(Int32))]
        public virtual int Version { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        [PropertyAttribute(Column = "BrandName ", Length = 50, TypeType = typeof(String))]
        public virtual string BrandName { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        [PropertyAttribute(Column = "Nationality ", Length = 50, TypeType = typeof(String))]
        public virtual string Nationality { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        [PropertyAttribute(Column = "DateCreated ", TypeType = typeof(DateTime))]
        public virtual DateTime DateCreated { get; set; }

        /// <summary>
        /// 下属型号
        /// </summary>
        [Bag(0, Name = "VehicleTypeList", Inverse = true, Lazy = CollectionLazy.False)]
        [Key(1, Column = "BrandID")]
        [OneToMany(1, ClassType = typeof(VehicleType))]
        public virtual IList<VehicleType> VehicleTypeList { get; set; }
    }
}
