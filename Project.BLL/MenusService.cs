//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//     生成时间 05/21/2018 09:42:17 By 朱峰
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
using Project.DAL;
using Project.Common;
using System.Linq;

namespace Project.BLL
{
    public class MenusService : IMenusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserContext _userContext;

        public MenusService(IMenusManage menusManage, IUnitOfWork unitOfWork, IUserContext userContext)
        {
            _userContext = userContext;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        ///     新增Menus
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Insert(Menus entity)
        {
            return _unitOfWork.MenusManage.Insert(entity);
        }

        /// <summary>
        ///     批量新增Menus
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Insert(List<Menus> entitys)
        {
            return _unitOfWork.MenusManage.InsertWithNoTran(entitys);
        }

        /// <summary>
        ///     更新Menus
        /// </summary>
        /// <returns></returns>
        public bool Update(Menus entity)
        {
            return _unitOfWork.MenusManage.Update(entity);
        }

        /// <summary>
        ///     批量更新(不使用事务)
        /// </summary>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public bool Update(List<Menus> entitys)
        {
            return _unitOfWork.MenusManage.UpdateWithNoTran(entitys);
        }

        /// <summary>
        ///     逻辑删除Menus
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool SoftDelete(int id)
        {
            return _unitOfWork.MenusManage.SoftDelete(id);
        }

        /// <summary>
        ///     批量逻辑删除Menus(不使用事务)
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool SoftDelete(List<int> ids)
        {
            return _unitOfWork.MenusManage.SoftDeleteWithNoTran(ids);
        }

        /// <summary>
        ///     判断Menus是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return _unitOfWork.MenusManage.Exists(id);
        }

        /// <summary>
        ///     根据主键获取实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Menus GetByPk(int id)
        {
            return _unitOfWork.MenusManage.GetByPk(id);
        }

        /// <summary>
        ///     根据主键获取实体集合
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public List<Menus> GetList(List<int> ids)
        {
            return _unitOfWork.MenusManage.GetList(ids);
        }

        /// <summary>
        ///     分页方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sort"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public PageModel<Menus> GetByPage(int page, int size, string sort, MenusCondition condition)
        {
            var dbCondition = new List<DbCondition<Menus>>();
            return _unitOfWork.MenusManage.GetByPage(page, size, sort, dbCondition);
        }
        /// <summary>
        /// 菜单查询（树形展示）
        /// </summary>
        /// <param name="appcode"></param>
        /// <returns></returns>
        public List<MenusTreeDto> GetMenus(int? appcode)
        {
            appcode = appcode ?? _userContext.AppCode;
            return _unitOfWork.MenusManage.GetMenus(appcode);
        }

        public MenusTreeDto InitMenuTree(MenusTreeDto menu, List<MenusTreeDto> menus)
        {

            if (menu == null)
            {
                menu = new MenusTreeDto();
            }

            List<MenusTreeDto> list = menus.Where(x => x.ParentID == menu.Id).OrderBy(x => x.Sort).ToList();
            if (list != null && list.Count > 0)
            {
                foreach (var item in list)
                {
                    InitMenuTree(item, menus);
                }
            }
            menu.Children = list;
            return menu;
        }
    }
}