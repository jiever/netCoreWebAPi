//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//     生成时间 05/03/2018 18:58:49 By 朱峰
//     对此文件的更改可能会导致不正确的行为，并且如果
//     文件已存在，不会覆盖。
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using Project.Common;
using Project.IDAL;
using Project.Model;
using Project.Model.Conditions;
using Project.Model.Dtos;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.DAL
{
    public class AreasManage : IAreasManage
    {
        protected readonly IUserContext _userContext;
        protected SqlSugarClient Db;
        public AreasManage(DbType dbType = DbType.MySql)
		{
            Db = MyDbFactory.GetDatabase(dbType);
            _userContext = new DefaultUserContext();
		}
        public bool Update(Areas entity)
        {
            //entity.UpdateTime = DateTime.Now;
            //entity.UpdateUser = _userContext.UserId;
            return Db.Updateable(Mapper.Map<Areas>(entity)).ExecuteCommand() > -1;
        }

        /// <summary>
        ///     根据主键获取id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Areas GetByPk(int id)
        {
            return Db.Queryable<Areas>().In(id).First();
        }
        public List<Areas> GetAreasByParentAreaID(int parentAreaID)
        {
            return Db.Queryable<Areas>().Where(x => x.ParentID == parentAreaID).ToList();
        }

        public List<Areas> GetByParameters (AreasCondition condition)
        {
            var list = Db.Queryable<Areas>().WhereIF(!string.IsNullOrEmpty(condition.Name), x => x.Name.Contains(condition.Name))
                .WhereIF(condition.ParentID!=null, x=>x.ParentID == condition.ParentID)
                .WhereIF(condition.Type!=null, x=>x.Type == (int) condition.Type)
                .WhereIF(!string.IsNullOrEmpty(condition.FullPinying), x=>x.FullPinying.Contains(condition.FullPinying))
                .WhereIF(!string.IsNullOrEmpty(condition.ShortPinying), x=>x.ShortPinying.Contains(condition.ShortPinying))
                .WhereIF(condition.IsUsual!=null, x=>x.IsUsual == (byte)(condition.IsUsual.GetValueOrDefault()?1:0)).ToList();
            return list;
        }

        public PageModel<Areas> GetAreasByPage(int page, int size, string sort, List<DbCondition<Areas>> condition)
        {
            var result = new PageModel<Areas>();
            var count = 0;
            var query = Db.Queryable<Areas>();
            condition.ForEach(item => { query = query.WhereIF(item.IsWhere, item.Expression); });
            query = query
                .OrderByIF(!string.IsNullOrEmpty(sort), sort)
                .OrderByIF(string.IsNullOrEmpty(sort), o => o.Id, OrderByType.Desc);
            var list = query.ToPageList(page, size, ref count);
            //var list = query.ToPageList(page, size, ref count);

            result.Data = list;
            result.Total = count;
            return result;
        }
     }
}
