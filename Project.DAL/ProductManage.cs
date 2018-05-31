using Project.IDAL;
using Project.Model;
using SqlSugar;

namespace Project.DAL
{
    public class ProductManage : ManageBase<Product>, IProductManage
    {
        public ProductManage() : base(DbType.SqlServer)
        {
        }
    }
}