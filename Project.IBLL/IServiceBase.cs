using System;
using System.Collections.Generic;
using System.Text;

namespace Project.IBLL
{
    public interface IServiceBase<T>
    {
        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Insert(T entity);

        /// <summary>
        ///     批量新增产品
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        bool Insert(List<T> entitys);

        /// <summary>
        /// 更新产品
        /// </summary>
        /// <returns></returns>
        bool Update(T entity);

        /// <summary>
        /// 批量更新(不使用事务)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        bool Update(List<T> entitys);

        /// <summary>
        /// 逻辑删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool SoftDelete(int id);

        /// <summary>
        /// 批量逻辑删除产品(不使用事务)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        bool SoftDelete(List<int> ids);

        /// <summary>
        /// 判断产品是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Exists(int id);

        /// <summary>
        ///     根据主键获取id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetByPk(int id);
    }
}
