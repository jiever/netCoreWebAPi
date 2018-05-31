using SqlSugar;

namespace Project.Model
{
    [SugarTable("products_copy")]
    public class Product : BaseField
    {
        /// <summary>
        ///     自增主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "ID")]
        public int Id { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public string Name { get; set; }
    }
}