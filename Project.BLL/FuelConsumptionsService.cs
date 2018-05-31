//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//     生成时间 05/03/2018 18:58:49 By 朱峰
//     对此文件的更改可能会导致不正确的行为，并且如果
//     文件已存在，不会覆盖。
// </auto-generated>
//------------------------------------------------------------------------------

using System.Collections.Generic;
using Project.IBLL;
using Project.IDAL;
using Project.Model;
using Project.Model.Conditions;
using Project.Model.Dtos;

namespace Project.BLL
{
    public class FuelConsumptionsService : IFuelConsumptionsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FuelConsumptionsService(IFuelConsumptionsManage fuelConsumptionsManage, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     新增FuelConsumptions
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(FuelConsumptions entity)
        {
            return _unitOfWork.FuelConsumptionsManage.Insert(entity);
        }

        /// <summary>
        ///     批量新增FuelConsumptions
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Insert(List<FuelConsumptions> entitys)
        {
            return _unitOfWork.FuelConsumptionsManage.InsertWithNoTran(entitys);
        }

        /// <summary>
        ///     更新FuelConsumptions
        /// </summary>
        /// <returns></returns>
        public bool Update(FuelConsumptions entity)
        {
            return _unitOfWork.FuelConsumptionsManage.Update(entity);
        }

        /// <summary>
        ///     批量更新(不使用事务)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Update(List<FuelConsumptions> entitys)
        {
            return _unitOfWork.FuelConsumptionsManage.UpdateWithNoTran(entitys);
        }

        /// <summary>
        ///     逻辑删除FuelConsumptions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SoftDelete(int id)
        {
            return _unitOfWork.FuelConsumptionsManage.SoftDelete(id);
        }

        /// <summary>
        ///     批量逻辑删除FuelConsumptions(不使用事务)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool SoftDelete(List<int> ids)
        {
            return _unitOfWork.FuelConsumptionsManage.SoftDeleteWithNoTran(ids);
        }

        /// <summary>
        ///     判断FuelConsumptions是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return _unitOfWork.FuelConsumptionsManage.Exists(id);
        }

        /// <summary>
        ///     根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FuelConsumptions GetByPk(int id)
        {
            return _unitOfWork.FuelConsumptionsManage.GetByPk(id);
        }

        /// <summary>
        ///     根据主键获取实体集合
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<FuelConsumptions> GetList(List<int> ids)
        {
            return _unitOfWork.FuelConsumptionsManage.GetList(ids);
        }

        /// <summary>
        ///     分页方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sort"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public PageModel<FuelConsumptions> GetByPage(int page, int size, string sort, FuelConsumptionsCondition condition)
        {
            var dbCondition = new List<DbCondition<FuelConsumptions>>();
            return _unitOfWork.FuelConsumptionsManage.GetByPage(page, size, sort, dbCondition);
        }
    }
}