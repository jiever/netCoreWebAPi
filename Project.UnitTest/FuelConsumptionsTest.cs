using System.Collections.Generic;
using Project.DAL;
using Project.Model;
using SqlSugar;
using Xunit;

namespace Project.UnitTest
{
    public class FuelConsumptionsTest : BaseTest
    {
        /// <summary>
        ///     服务
        /// </summary>
        public ManageFuelConsumptions ManageFuelConsumptionsService = new ManageFuelConsumptions();

        public class ManageFuelConsumptions : ManageBase<FuelConsumptions>
        {
			public ManageFuelConsumptions() : base(DbType.SqlServer)
			{
				Db.CurrentConnectionConfig = new ConnectionConfig
				{
					ConnectionString = SqlConnectionString,
					DbType = DbType.SqlServer
				};
			}
		}

		[Fact(DisplayName = "新增FuelConsumptions")]
        public void Insert()
        {
            var result = ManageFuelConsumptionsService.Insert(new FuelConsumptions());
            Assert.True(result > 0);
        }

		[Fact(DisplayName = "批量新增FuelConsumptions")]
        public void BulkInsert()
        {
            var result = ManageFuelConsumptionsService.InsertWithNoTran(new List<FuelConsumptions>
            {
                new FuelConsumptions()
            });
            Assert.True(result);
        }

        [Fact(DisplayName = "批量删除FuelConsumptions")]
        public void BulkDelete()
        {
            var result = ManageFuelConsumptionsService.SoftDeleteWithNoTran(new List<int> {1, 2});
            Assert.True(result);
        }

        [Fact(DisplayName = "逻辑删除FuelConsumptions")]
        public void Delete()
        {
            var result = ManageFuelConsumptionsService.SoftDelete(1);
            Assert.True(result);
        }

        [Fact(DisplayName = "FuelConsumptions是否存在")]
        public void Exists()
        {
            var result = ManageFuelConsumptionsService.Exists(1);
            Assert.True(result);
        }

        [Fact(DisplayName = "分页查询FuelConsumptions")]
        public void GetByPage()
        {
            var result = ManageFuelConsumptionsService.GetByPage(1, 10, "addTime desc", new List<DbCondition<FuelConsumptions>>());
            Assert.True(result.Total > 0);
        }

        [Fact(DisplayName = "根据Id获取FuelConsumptions")]
        public void GetByPk()
        {
            var result = ManageFuelConsumptionsService.GetByPk(1);
            Assert.True(result.Id > 0);
        }

        [Fact(DisplayName = "根据Id集合获取FuelConsumptions列表")]
        public void GetList()
        {
            var result = ManageFuelConsumptionsService.GetList(new List<int> {1, 2});
            Assert.True(result.Count > 0);
        }
    }
}
