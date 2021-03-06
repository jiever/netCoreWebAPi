//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//     生成时间 05/03/2018 18:58:49 By 朱峰
//     对此文件的更改可能会导致不正确的行为，并且如果
//     文件已存在，不会覆盖。
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using AutoMapper;
using Project.Common;
using Project.IBLL;
using Project.IDAL;
using Project.Model;
using Project.Model.Conditions;
using Project.Model.Dtos;

namespace Project.BLL
{
    public class AreasService : IAreasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AreasService(IAreasManage areasManage, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        ///// <summary>
        /////     新增Areas
        ///// </summary>
        ///// <param name="entity"></param>
        ///// <returns></returns>
        //public int Insert(Areas entity)
        //{
        //    return _unitOfWork.AreasManage.Insert(entity);
        //}

        ///// <summary>
        /////     批量新增Areas
        ///// </summary>
        ///// <param name="entitys"></param>
        ///// <returns></returns>
        //public bool Insert(List<Areas> entitys)
        //{
        //    return _unitOfWork.AreasManage.InsertWithNoTran(entitys);
        //}

        /// <summary>
        ///     更新Areas
        /// </summary>
        /// <returns></returns>
        public bool Update(Areas entity)
        {
            return _unitOfWork.AreasManage.Update(entity);
        }

        ///// <summary>
        /////     批量更新(不使用事务)
        ///// </summary>
        ///// <param name="entitys"></param>
        ///// <returns></returns>
        //public bool Update(List<Areas> entitys)
        //{
        //    return _unitOfWork.AreasManage.UpdateWithNoTran(entitys);
        //}

        ///// <summary>
        /////     逻辑删除Areas
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public bool SoftDelete(int id)
        //{
        //    return _unitOfWork.AreasManage.SoftDelete(id);
        //}

        ///// <summary>
        /////     批量逻辑删除Areas(不使用事务)
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <returns></returns>
        //public bool SoftDelete(List<int> ids)
        //{
        //    return _unitOfWork.AreasManage.SoftDeleteWithNoTran(ids);
        //}

        ///// <summary>
        /////     判断Areas是否存在
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public bool Exists(int id)
        //{
        //    return _unitOfWork.AreasManage.Exists(id);
        //}

        /// <summary>
        ///     根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Areas GetByPk(int id)
        {
            return _unitOfWork.AreasManage.GetByPk(id);
        }

        ///// <summary>
        /////     根据主键获取实体集合
        ///// </summary>
        ///// <param name="ids"></param>
        ///// <returns></returns>
        //public List<Areas> GetList(List<int> ids)
        //{
        //    return _unitOfWork.AreasManage.GetList(ids);
        //}

        /// <summary>
        ///     分页方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sort"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public PageModel<Areas> GetByPage(int page, int size, string sort, AreasCondition condition)
        {
            var dbCondition = new List<DbCondition<Areas>>();
            dbCondition.Add(new DbCondition<Areas>() { IsWhere = !string.IsNullOrEmpty(condition.Name), Expression = x => x.Name.Contains(condition.Name) });
            dbCondition.Add(new DbCondition<Areas>() { IsWhere = condition.ParentID!=null, Expression = x => x.ParentID == condition.ParentID });
            dbCondition.Add(new DbCondition<Areas>() { IsWhere = condition.Type!=null, Expression = x => x.Type == (int)condition.Type });
            dbCondition.Add(new DbCondition<Areas>() { IsWhere = !string.IsNullOrEmpty(condition.FullPinying), Expression = x => x.FullPinying.Contains(condition.FullPinying) });
            dbCondition.Add(new DbCondition<Areas>() { IsWhere = !string.IsNullOrEmpty(condition.ShortPinying), Expression = x => x.ShortPinying.Contains(condition.ShortPinying) });
            dbCondition.Add(new DbCondition<Areas>() { IsWhere = condition.IsUsual!=null, Expression = x => x.IsUsual == (byte)(condition.IsUsual.GetValueOrDefault() ? 1 : 0) });
            return _unitOfWork.AreasManage.GetAreasByPage(page, size, sort, dbCondition);
        }

        public List<Areas> GetByParameters(AreasCondition condition)
        {
            return _unitOfWork.AreasManage.GetByParameters(condition);
        }

        public FullAreaDto GetFullByAreaID(int id)
        {
            FullAreaDto fullArea = new FullAreaDto();
            var area = _unitOfWork.AreasManage.GetByPk(id);
            int areaID = area.Id;
            for(int i=(int)area.Type; i > 1; i--)
            {
                var minArea = _unitOfWork.AreasManage.GetByPk(areaID);
                areaID = minArea.ParentID.Value;
                if (i == (int)AreaType.Province)
                {
                    fullArea.ProvinceCode = minArea.Id;
                    fullArea.ProvinceName = minArea.Name;
                }else if (i == (int)AreaType.City)
                {
                    fullArea.ProvinceCode = minArea.Id;
                    fullArea.ProvinceName = minArea.Name;
                }else if (i == (int)AreaType.District)
                {
                    fullArea.ProvinceCode = minArea.Id;
                    fullArea.ProvinceName = minArea.Name;
                }
            }
            return fullArea;
        }

        public List<Areas> GetAreasByParentAreaID(int parentAreaID, bool isContainParent)
        {
            List<Areas> lstAreas = new List<Areas>();
            if (isContainParent)
            {
                var parent = _unitOfWork.AreasManage.GetByPk(parentAreaID);
                lstAreas.Add(Mapper.Map<Areas>(parent));
            }
            var childrens = _unitOfWork.AreasManage.GetAreasByParentAreaID(parentAreaID);
            foreach(var child in childrens)
            {
                var lst = GetAreasByParentAreaID(child.Id, false);
                lstAreas.AddRange(lst);
            }
            lstAreas.AddRange(childrens);
            return lstAreas;
        }

        public int Insert(Areas entity)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(List<Areas> entitys)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(List<Areas> entitys)
        {
            throw new System.NotImplementedException();
        }

        public bool SoftDelete(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool SoftDelete(List<int> ids)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Areas> GetList(List<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
