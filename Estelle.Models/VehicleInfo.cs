using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Models
{
    /// <summary>
    /// 型号列表
    /// </summary>
    [Serializable]
    public class VehicleInfo
    {
        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 排量
        /// </summary>
        public double EngineDisplacement { get; set; }

        /// <summary>
        /// 是否增压
        /// </summary>
        public bool Turbo { get; set; }
    }
}
