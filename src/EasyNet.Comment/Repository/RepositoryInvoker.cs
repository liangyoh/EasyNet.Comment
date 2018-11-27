using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EasyNet.Comment.Repository
{
    public class RepositoryInvoker<T> where T:class
    {
        public static IRepository<T> Current;

        public RepositoryInvoker(IRepository<T> repository)
        {
            Current = repository;
        }


        #region Query
        /// <summary>
        /// 查找单个数据记录
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static T FindSingle(Expression<Func<T, bool>> expression)
        {
            return Current.FindSingle(expression);
        }
        /// <summary>
        /// 查找数据记录
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Current.Find(expression);
        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="expression"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public IQueryable<T> GetPage(out int count, Expression<Func<T, bool>> expression, string orderby = "", int pageSize = 10, int pageIndex = 1)
        {
            return Current.GetPage(out count, expression, orderby, pageSize, pageIndex);
        }
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<T, bool>> expression)
        {
            return Current.GetCount(expression);
        }

        #endregion

        #region Update
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            Current.Update(entity);
        }
        /// <summary>
        /// 更新实体，按照指定key
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="entity"></param>
        public void Update(Expression<Func<T, object>> expression, T entity)
        {
            Current.Update(expression, entity);
        }

        /// <summary>
        /// 根据条件更新实体
        /// </summary>
        /// <param name="where"></param>
        /// <param name="entity"></param>
        public void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity)
        {
            Current.Update(where, entity);
        }
        #endregion

        #region Delete
        /// <summary>
        /// 删除数据实体
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            Current.Delete(entity);
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="expression"></param>
        public void Delete(Expression<Func<T, bool>> expression)
        {
            Current.Delete(expression);
        }
        #endregion
    }
}
