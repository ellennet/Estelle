using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Common
{
    /// <summary>
    /// 简单对象映射
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TDestination"></typeparam>
    public class SimpleObjectMapper<TSource, TDestination>
    {
        /// <summary>
        /// 集合映射
        /// </summary>
        public List<TDestination> ListMap(List<TSource> TSourceList)
        {
            AutoMapper.Mapper.CreateMap<TSource, TDestination>();
            List<TDestination> TDestinationList = AutoMapper.Mapper.Map<List<TSource>, List<TDestination>>(TSourceList);
            return TDestinationList;
        }


    }
}
