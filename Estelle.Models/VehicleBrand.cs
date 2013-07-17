using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Models
{
    /// <summary>
    /// 品牌信息
    /// </summary>
    public class VehicleBrand
    {
        /// <summary>
        /// 品牌ID
        /// </summary>
        public Guid BrandID { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public virtual int Version { get; set; }
    }
}
