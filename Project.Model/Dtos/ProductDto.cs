using System;

namespace Project.Model.Dtos
{
    public class ProductDto
    {
        /// <summary>
        ///     自增主键
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     添加人
        /// </summary>
        public int AddUser { get; set; }

        /// <summary>
        ///     添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        ///     修改人
        /// </summary>
        public int UpdateUser { get; set; }

        /// <summary>
        ///     修改时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        ///     逻辑删除
        /// </summary>
        public bool Marks { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        public string Name { get; set; }
    }
}