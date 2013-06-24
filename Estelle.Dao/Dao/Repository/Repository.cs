using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Data;
using Spring.Data.NHibernate.Generic;
using Spring.Data.NHibernate.Generic.Support;
using Spring.Stereotype;
using Spring.Transaction.Interceptor;

namespace Estelle.Dao
{
    [Repository]
    public abstract class Repository<T> : HibernateDaoSupport, IDao.IRepository<T> where T : class
    {
        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [Transaction(ReadOnly = true)]
        public virtual T Get(object id)
        {                        
            return this.HibernateTemplate.Get<T>(id);
        }

        /// <summary>
        /// 根据主键获取实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [Transaction(ReadOnly = true)]
        public virtual T Load(object id)
        {
            return this.HibernateTemplate.Load<T>(id);
        }

        /// <summary>
        /// 获取全部集合
        /// </summary>
        /// <returns>集合</returns>
        [Transaction(ReadOnly = true)]
        public virtual IList<T> LoadAll()
        {
            return this.HibernateTemplate.LoadAll<T>();
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>ID</returns>
        [Transaction(ReadOnly = false)]
        public virtual object Save(T entity)
        {
            return this.HibernateTemplate.Save(entity);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        [Transaction(ReadOnly = false)]
        public virtual void Update(T entity)
        {
            this.HibernateTemplate.Update(entity);
        }

        /// <summary>
        /// 修改或保存实体
        /// </summary>
        /// <param name="entity">实体</param>
        [Transaction(ReadOnly = false)]
        public virtual void SaveOrUpdate(T entity)
        {
            this.HibernateTemplate.SaveOrUpdate(entity);
        }

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="id">ID</param>
        [Transaction(ReadOnly = false)]
        public virtual void Delete(object id)
        {
            var entity = this.HibernateTemplate.Get<T>(id);
            if (entity == null)
            {
                return;
            }

            this.HibernateTemplate.Delete(entity);
        }

        /// <summary>
        /// 根据多个主键删除实体
        /// </summary>
        /// <param name="idList">ID集合</param>
        [Transaction(ReadOnly = false)]
        public virtual void Delete(IList<object> idList)
        {
            foreach (var item in idList)
            {
                var entity = this.HibernateTemplate.Get<T>(item);
                if (entity == null)
                {
                    return;
                }

                this.HibernateTemplate.Delete(entity);
            }
        }

        /// <summary>
        /// 分页获取全部集合
        /// </summary>
        /// <param name="count">返回的记录总数</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">每页大小</param>
        /// <returns>集合</returns>
        [Transaction(ReadOnly = true)]
        public virtual IList<T> LoadAllWithPage(out long count, int pageIndex, int pageSize)
        {
            var result = this.HibernateTemplate.LoadAll<T>();
            count = result.LongCount();

            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}
