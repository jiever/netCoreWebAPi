//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//     生成时间 05/21/2018 09:42:17 By 朱峰
//     对此文件的更改可能会导致不正确的行为，并且如果
//     文件已存在，不会覆盖。
// </auto-generated>
//------------------------------------------------------------------------------
using Project.Model;
using Project.Model.Dtos;
using System.Collections.Generic;

namespace Project.IDAL
{
    public interface IMenusManage : IManageBase<Menus>
    {
        /// <summary>
        /// 根据appcode获取菜单
        /// </summary>
        /// <param name="appcode"></param>
        /// <returns></returns>
        List<MenusTreeDto> GetMenus(int? appcode);
    }
}

