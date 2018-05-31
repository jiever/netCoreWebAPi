using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Model
{
    public class FullAreaDto
    {
        /// <summary>
        /// 省份区划代码
        /// </summary>
        public int ProvinceCode { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string ProvinceName { get; set; }

        /// <summary>
        /// 城市区划代码
        /// </summary>
        public int CityCode { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// 区县区划代码
        /// </summary>
        public int DistrictCode { get; set; }

        /// <summary>
        /// 区县
        /// </summary>
        public string DistrictName { get; set; }
    }
}
