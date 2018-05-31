using System.Collections.Generic;
using Project.DAL;
using Project.Model;
using SqlSugar;
using Xunit;

namespace Project.UnitTest
{
    public class UnitTest : BaseTest
    {
        /// <summary>
        ///     服务
        /// </summary>
        public ManageProduct ManageProductService = new ManageProduct();

        public class ManageProduct : ManageBase<Product>
        {
            public ManageProduct() : base(DbType.SqlServer)
            {
                Db.CurrentConnectionConfig = new ConnectionConfig
                {
                    ConnectionString = SqlConnectionString,
                    DbType = DbType.SqlServer
                };
            }
        }

        [Fact(DisplayName = "批量删除产品")]
        public void BulkDelete()
        {
            var result = ManageProductService.SoftDeleteWithNoTran(new List<int> {1003, 1004});
            Assert.True(result);
        }

        [Fact(DisplayName = "批量新增产品")]
        public void BulkInsert()
        {
            var result = ManageProductService.InsertWithNoTran(new List<Product>
            {
                new Product {Name = "test1"},
                new Product {Name = "test2"},
                new Product {Name = "test3"}
            });
            Assert.True(result);
        }

        [Fact(DisplayName = "逻辑删除产品")]
        public void Delete()
        {
            var result = ManageProductService.SoftDelete(1003);
            Assert.True(result);
        }

        [Fact(DisplayName = "产品是否存在")]
        public void Exists()
        {
            var result = ManageProductService.Exists(1003);
            Assert.True(result);
        }

        [Fact(DisplayName = "分页查询产品")]
        public void GetByPage()
        {
            var result = ManageProductService.GetByPage(1, 10, "addTime desc", new List<DbCondition<Product>>());
            Assert.True(result.Total > 0);
        }

        [Fact(DisplayName = "根据Id获取产品")]
        public void GetByPk()
        {
            var result = ManageProductService.GetByPk(1003);
            Assert.True(result.Id > 0);
        }

        [Fact(DisplayName = "根据Id集合获取产品列表")]
        public void GetList()
        {
            var result = ManageProductService.GetList(new List<int> {1003, 1004});
            Assert.True(result.Count > 0);
        }

        [Fact(DisplayName = "新增产品产品")]
        public void Insert()
        {
            var result = ManageProductService.Insert(new Product
            {
                Name = "test"
            });
            Assert.True(result > 0);
        }
    }
}