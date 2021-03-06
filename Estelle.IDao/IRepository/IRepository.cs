﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estelle.IDao
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        T Get(object id);

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        T Load(object id);

        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns>集合</returns>
        IList<T> LoadAll();

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>ID</returns>
        object Save(T entity);

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        void Update(T entity);

        /// <summary>
        /// 修改或保存实体
        /// </summary>
        /// <param name="entity">实体</param>
        void SaveOrUpdate(T entity);

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="id">ID</param>
        void Delete(object id);

        /// <summary>
        /// 根据多个主键删除实体
        /// </summary>
        /// <param name="idList">ID集合</param>
        void Delete(IList<object> idList);

        /// <summary>
        /// 分页获取全部集合
        /// </summary>
        /// <param name="count">返回的记录总数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>集合</returns>
        IList<T> LoadAllWithPage(out long count, int pageIndex, int pageSize);
    }
}
