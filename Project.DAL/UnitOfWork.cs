//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由T4模板自动生成
//     生成时间 05/21/2018 09:42:17 By 朱峰
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using Project.IDAL;

namespace Project.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        public IProductManage ProductManage { set; get; }

        public IFuelConsumptionsManage FuelConsumptionsManage { get; set; }

        public IAreasManage AreasManage { get; set; }

        public IMenusManage MenusManage { get; set; }
    }
}