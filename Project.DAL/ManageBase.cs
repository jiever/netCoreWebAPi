using System;
using System.Collections.Generic;
using Project.Common;
using Project.IDAL;
using Project.Model;
using Project.Model.Dtos;
using SqlSugar;

namespace Project.DAL
{
    /// <summary>
    ///     封装DB
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ManageBase<T> : IManageBase<T> where T : BaseField, new()
    {
        protected readonly IUserContext _userContext;
        protected SqlSugarClient Db;

        protected ManageBase(DbType dbType = DbType.MySql)
        {
            Db = MyDbFactory.GetDatabase(dbType);
            _userContext = new DefaultUserContext();
        }

        /// <summary>
        ///     统一新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(T entity)
        {
            entity.AddTime = DateTime.Now;
            entity.AddUser = _userContext.UserId;
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUser = _userContext.UserId;
            return Db.Insertable(entity).ExecuteReturnIdentity();
        }

        /// <summary>
        ///     批量插入(带事务)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool InsertWithTran(List<T> entitys)
        {
            var result = Db.Ado.UseTran(() =>
            {
                entitys.ForEach(entity =>
                {
                    entity.AddTime = DateTime.Now;
                    entity.AddUser = _userContext.UserId;
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUser = _userContext.UserId;
                    Db.Insertable(entity).ExecuteCommand();
                });
            });
            return result.IsSuccess;
        }

        /// <summary>
        ///     批量插入(不带事务)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool InsertWithNoTran(List<T> entitys)
        {
            entitys.ForEach(entity =>
            {
                entity.AddTime = DateTime.Now;
                entity.AddUser = _userContext.UserId;
                entity.UpdateTime = DateTime.Now;
                entity.UpdateUser = _userContext.UserId;
                Db.Insertable(entity).ExecuteCommand();
            });
            return true;
        }

        /// <summary>
        ///     统一更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            entity.UpdateTime = DateTime.Now;
            entity.UpdateUser = _userContext.UserId;
            return Db.Updateable(entity).IgnoreColumns(o => new {o.AddUser, o.AddTime}).ExecuteCommand() > -1;
        }

        /// <summary>
        ///     批量更新(带事务)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool UpdateWithTran(List<T> entitys)
        {
            var result = Db.Ado.UseTran(() =>
            {
                entitys.ForEach(entity =>
                {
                    entity.UpdateTime = DateTime.Now;
                    entity.UpdateUser = _userContext.UserId;
                    Db.Updateable(entity).IgnoreColumns(o => new {o.AddUser, o.AddTime}).ExecuteCommand();
                });
            });
            return result.IsSuccess;
        }

        /// <summary>
        ///     批量更新(不带事务)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool UpdateWithNoTran(List<T> entitys)
        {
            entitys.ForEach(entity =>
            {
                entity.UpdateTime = DateTime.Now;
                entity.UpdateUser = _userContext.UserId;
                Db.Updateable(entity).IgnoreColumns(o => new {o.AddUser, o.AddTime}).ExecuteCommand();
            });
            return true;
        }

        /// <summary>
        ///     逻辑删除
        /// </summary>
        /// <returns></returns>
        public bool SoftDelete(int id)
        {
            return Db.Updateable<T>(
                           new {Marks = false, UpdateTime = DateTime.Now, UpdateUser = _userContext.UserId, id})
                       .ExecuteCommand() > -1;
        }

        /// <summary>
        ///     批量逻辑删除(带事务)
        /// </summary>
        /// <returns></returns>
        public bool SoftDeleteWithTran(List<int> ids)
        {
            var result = Db.Ado.UseTran(() =>
            {
                Db.Updateable<T>(new { Marks = false, UpdateTime = DateTime.Now, UpdateUser = _userContext.UserId, ids })
                    .ExecuteCommand();
            });
            return result.IsSuccess;
        }

        /// <summary>
        ///     批量逻辑删除(不带事务)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool SoftDeleteWithNoTran(List<int> ids)
        {
            return Db.Updateable<T>(
                           new { Marks = false, UpdateTime = DateTime.Now, UpdateUser = _userContext.UserId, ids })
                       .ExecuteCommand() > -1;
        }

        /// <summary>
        ///     物理删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return Db.Deleteable<T>().In(id).ExecuteCommand() > -1;
        }

        /// <summary>
        ///     批量物理删除(带事务)
        /// </summary>
        /// <returns></returns>
        public bool DeleteWithTran(List<int> ids)
        {
            var result = Db.Ado.UseTran(() => { Db.Deleteable<T>().In(ids).ExecuteCommand(); });
            return result.IsSuccess;
        }

        /// <summary>
        ///     批量物理删除(不带事务)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteWithNoTran(List<int> ids)
        {
            return Db.Deleteable<T>().In(ids).ExecuteCommand() > -1;
        }

        /// <summary>
        ///     判断主键是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return Db.Queryable<T>().In(id).Any();
        }

        /// <summary>
        ///     根据主键获取id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T GetByPk(int id)
        {
            return Db.Queryable<T>().In(id).First();
        }

        /// <summary>
        ///     根据主键获取列表
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<T> GetList(List<int> ids)
        {
            return Db.Queryable<T>().In(ids).ToList();
        }

        /// <summary>
        ///     分页方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sort"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public PageModel<T> GetByPage(int page, int size, string sort, List<DbCondition<T>> condition)
        {
            var result = new PageModel<T>();
            var count = 0;
            var query = Db.Queryable<T>();
            condition.ForEach(item => { query = query.WhereIF(item.IsWhere, item.Expression); });
            query = query
                .OrderByIF(!string.IsNullOrEmpty(sort), sort)
                .OrderByIF(string.IsNullOrEmpty(sort), o => o.AddTime, OrderByType.Desc);
            var list = query.ToPageList(page, size, ref count);
            result.Data = list;
            result.Total = count;
            return result;
        }
    }
}