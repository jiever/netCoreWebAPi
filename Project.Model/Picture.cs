using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model
{
    /// <summary>
    /// 图片
    /// </summary>
    [SugarTable("cm_pictures")]
    public class Picture :BaseField
    {
        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }

        /// <summary>
        /// 标题
        /// </summary>		
        public string Title { get; set; }

        /// <summary>
        /// 文件名(相对位置，去除host)
        /// </summary>		
        public string Filename { get; set; }

        /// <summary>
        /// 文件描述
        /// </summary>		
        public string Description { get; set; }

        /// <summary>
        /// 文件状态 0 文件未下载 -1 文件下载失败 1 文件下载成功
        /// </summary>		
        public FileState State { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 备注
        /// </summary>		
        public string Notes { get; set; }

        /// <summary>
        /// 系统枚举
        /// </summary>
        public AppCode AppCode { get; set; }

        /// <summary>
        /// 是否有效 0：无效 1：有效
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Host
        /// </summary>
        [SugarColumn(IsIgnore =true)]
        public string Host { get; set; }
    }
}
