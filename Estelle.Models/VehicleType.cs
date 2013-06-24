using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Models
{
    /// <summary>
    /// 型号信息
    /// </summary>
    [Serializable]
    public class VehicleType
    {
        /// <summary>
        /// 型号ID
        /// </summary>
        public Guid TypeID { get; set; }

        /// <summary>
        /// 品牌名称
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string Type { get; set; }

        /// 排量
        /// <summary>
        /// </summary>
        public string EngineDisplacement { get; set; }

        /// <summary>
        /// 是否增压
        /// </summary>
        public bool Turbo { get; set; }
    }
}
