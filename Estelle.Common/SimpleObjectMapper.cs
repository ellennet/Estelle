using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.Common
{
    /// <summary>
    /// 简单对象映射
    /// </summary>
    /// <typeparam name="TSource">源类型</typeparam>
    /// <typeparam name="TDestination">目标类型</typeparam>
    public class SimpleObjectMapper<TSource, TDestination>
    {
        /// <summary>
        /// 集合对象映射
        /// </summary>
        /// <param name="TSourceList">原类型的集合</param>
        /// <returns></returns>
        public List<TDestination> ListMap(List<TSource> TSourceList)
        {
            AutoMapper.Mapper.CreateMap<TSource, TDestination>();
            List<TDestination> TDestinationList = AutoMapper.Mapper.Map<List<TSource>, List<TDestination>>(TSourceList);
            return TDestinationList;
        }

        /// <summary>
        /// 对象映射
        /// </summary>
        /// <param name="SourceObj">原类型的对象</param>
        /// <returns></returns>
        public TDestination ObjectMap(TSource SourceObj)
        {
            AutoMapper.Mapper.CreateMap<TSource, TDestination>();
            TDestination DestObj = default(TDestination);
            DestObj = AutoMapper.Mapper.Map<TSource, TDestination>(SourceObj);

            return DestObj;
        }
    }  
}
