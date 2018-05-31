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
        ///     ����
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

        [Fact(DisplayName = "����ɾ����Ʒ")]
        public void BulkDelete()
        {
            var result = ManageProductService.SoftDeleteWithNoTran(new List<int> {1003, 1004});
            Assert.True(result);
        }

        [Fact(DisplayName = "����������Ʒ")]
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

        [Fact(DisplayName = "�߼�ɾ����Ʒ")]
        public void Delete()
        {
            var result = ManageProductService.SoftDelete(1003);
            Assert.True(result);
        }

        [Fact(DisplayName = "��Ʒ�Ƿ����")]
        public void Exists()
        {
            var result = ManageProductService.Exists(1003);
            Assert.True(result);
        }

        [Fact(DisplayName = "��ҳ��ѯ��Ʒ")]
        public void GetByPage()
        {
            var result = ManageProductService.GetByPage(1, 10, "addTime desc", new List<DbCondition<Product>>());
            Assert.True(result.Total > 0);
        }

        [Fact(DisplayName = "����Id��ȡ��Ʒ")]
        public void GetByPk()
        {
            var result = ManageProductService.GetByPk(1003);
            Assert.True(result.Id > 0);
        }

        [Fact(DisplayName = "����Id���ϻ�ȡ��Ʒ�б�")]
        public void GetList()
        {
            var result = ManageProductService.GetList(new List<int> {1003, 1004});
            Assert.True(result.Count > 0);
        }

        [Fact(DisplayName = "������Ʒ��Ʒ")]
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