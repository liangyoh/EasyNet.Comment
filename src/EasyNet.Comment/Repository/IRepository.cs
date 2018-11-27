using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EasyNet.Comment.Repository
{
    public interface IRepository<T> where T:class
    {
        #region Query
        /// <summary>
        /// 查找单个数据记录
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        T FindSingle(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 查找数据记录
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="count"></param>
        /// <param name="expression"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        IQueryable<T> GetPage(out int count, Expression<Func<T, bool>> expression, string orderby="", int pageSize=10, int pageIndex=1);
        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        int GetCount(Expression<Func<T, bool>> expression);

        #endregion

        #region Update
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
        /// <summary>
        /// 更新实体，按照指定key
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="entity"></param>
        void Update(Expression<Func<T, object>> expression, T entity);
        /// <summary>
        /// 根据条件更新实体
        /// </summary>
        /// <param name="where"></param>
        /// <param name="entity"></param>
        void Update(Expression<Func<T, bool>> where, Expression<Func<T, T>> entity);
        #endregion

        #region Delete
        /// <summary>
        /// 删除数据实体
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="expression"></param>
        void Delete(Expression<Func<T, bool>> expression);
        #endregion
    }
}
