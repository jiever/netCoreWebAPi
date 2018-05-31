using System.Collections.Generic;
using Project.DAL;
using Project.Model;
using SqlSugar;
using Xunit;

namespace Project.UnitTest
{
    public class MenusTest : BaseTest
    {
        /// <summary>
        ///     服务
        /// </summary>
        public ManageMenus ManageMenusService = new ManageMenus();

        public class ManageMenus : ManageBase<Menus>
        {
			public ManageMenus()
			{
				Db.CurrentConnectionConfig = new ConnectionConfig
				{
					ConnectionString = MySqlConnectionString,
				};
			}
		}

		[Fact(DisplayName = "新增Menus")]
        public void Insert()
        {
            var result = ManageMenusService.Insert(new Menus());
            Assert.True(result > 0);
        }

		[Fact(DisplayName = "批量新增Menus")]
        public void BulkInsert()
        {
            var result = ManageMenusService.InsertWithNoTran(new List<Menus>
            {
                new Menus()
            });
            Assert.True(result);
        }

        [Fact(DisplayName = "批量删除Menus")]
        public void BulkDelete()
        {
            var result = ManageMenusService.SoftDeleteWithNoTran(new List<int> {1, 2});
            Assert.True(result);
        }

        [Fact(DisplayName = "逻辑删除Menus")]
        public void Delete()
        {
            var result = ManageMenusService.SoftDelete(1);
            Assert.True(result);
        }

        [Fact(DisplayName = "Menus是否存在")]
        public void Exists()
        {
            var result = ManageMenusService.Exists(1);
            Assert.True(result);
        }

        [Fact(DisplayName = "分页查询Menus")]
        public void GetByPage()
        {
            var result = ManageMenusService.GetByPage(1, 10, "addTime desc", new List<DbCondition<Menus>>());
            Assert.True(result.Total > 0);
        }

        [Fact(DisplayName = "根据Id获取Menus")]
        public void GetByPk()
        {
            var result = ManageMenusService.GetByPk(1);
            Assert.True(result.Id > 0);
        }

        [Fact(DisplayName = "根据Id集合获取Menus列表")]
        public void GetList()
        {
            var result = ManageMenusService.GetList(new List<int> {1, 2});
            Assert.True(result.Count > 0);
        }
    }
}
