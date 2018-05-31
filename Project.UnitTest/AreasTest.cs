using System.Collections.Generic;
using Project.DAL;
using Project.Model;
using SqlSugar;
using Xunit;

namespace Project.UnitTest
{
    public class AreasTest : BaseTest
    {
        /// <summary>
        ///     服务
        /// </summary>
        public ManageAreas ManageAreasService = new ManageAreas();

        public class ManageAreas : ManageBase<Areas>
        {
			public ManageAreas()
			{
				Db.CurrentConnectionConfig = new ConnectionConfig
				{
					ConnectionString = MySqlConnectionString,
				};
			}
		}

		[Fact(DisplayName = "新增Areas")]
        public void Insert()
        {
            var result = ManageAreasService.Insert(new Areas());
            Assert.True(result > 0);
        }

		[Fact(DisplayName = "批量新增Areas")]
        public void BulkInsert()
        {
            var result = ManageAreasService.InsertWithNoTran(new List<Areas>
            {
                new Areas()
            });
            Assert.True(result);
        }

        [Fact(DisplayName = "批量删除Areas")]
        public void BulkDelete()
        {
            var result = ManageAreasService.SoftDeleteWithNoTran(new List<int> {1, 2});
            Assert.True(result);
        }

        [Fact(DisplayName = "逻辑删除Areas")]
        public void Delete()
        {
            var result = ManageAreasService.SoftDelete(1);
            Assert.True(result);
        }

        [Fact(DisplayName = "Areas是否存在")]
        public void Exists()
        {
            var result = ManageAreasService.Exists(1);
            Assert.True(result);
        }

        [Fact(DisplayName = "分页查询Areas")]
        public void GetByPage()
        {
            var result = ManageAreasService.GetByPage(1, 10, "addTime desc", new List<DbCondition<Areas>>());
            Assert.True(result.Total > 0);
        }

        [Fact(DisplayName = "根据Id获取Areas")]
        public void GetByPk()
        {
            var result = ManageAreasService.GetByPk(1);
            Assert.True(result.Id > 0);
        }

        [Fact(DisplayName = "根据Id集合获取Areas列表")]
        public void GetList()
        {
            var result = ManageAreasService.GetList(new List<int> {1, 2});
            Assert.True(result.Count > 0);
        }
    }
}
