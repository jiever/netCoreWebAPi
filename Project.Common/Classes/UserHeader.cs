
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Project.Common.Classes
{
    public class UserHeader
    {
        /// <summary>
        /// 账号
        /// </summary>
        public string UserNo { get; set; }

        /// <summary>
        /// 账号id
        /// </summary>
        public int UserID { get; set; }

        public int AppCode { get; set; }

        /// <summary>
        /// 公司id
        /// </summary>
        public int CompanyID { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司组织机构代码
        /// </summary>
        public string CompanyOrganizationCode { get; set; }

        /// <summary>
        /// 平台id
        /// </summary>
        public int PlatformID { get; set; }

        /// <summary>
        /// 省份区划代码
        /// </summary>
        public int ProvinceCode { get; set; }

        /// <summary>
        /// 城市区划代码
        /// </summary>
        public int CityCode { get; set; }

        /// <summary>
        /// 区县区划代码
        /// </summary>
        public int DistrictCode { get; set; }

        /// <summary>
        /// 是否是项目部
        /// </summary>
        public bool IsProjectDepart { get; set; }

        /// <summary>
        /// 是否是代理商
        /// </summary>
        public bool IsAgent { get; set; }

        /// <summary>
        /// 请求用户的操作系统
        /// </summary>
        public string UserOS { get; set; }

        /// <summary>
        /// 请求用户的ip
        /// </summary>
        public string UserIP { get; set; }

        /// <summary>
        /// 请求用户的浏览器
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 公司类型
        /// </summary>
        public List<CompanyTypeHeader> CompanyTypes { get; set; }

        /// <summary>
        /// 公司管辖区域
        /// </summary>
        public List<JurisdictionsHeader> Jurisdictions { get; set; }

        /// <summary>
        /// 公司及子公司信息
        /// </summary>
        public List<CompanyHeader> Companys { get; set; }

        [JsonIgnore]
        public string CompanyIdsCondition
        {
            get
            {
                var list = new List<int>();
                if (Companys == null) return null;
                for (var i = 0; i < Companys.Count; i++)
                {
                    list.Add(Companys[i].CompanyID);
                }
                if (list.Count == 0) return null;
                return $" in ({string.Join(",", list)}) ";
            }
        }

        [JsonIgnore]
        public string CompanyIdsWithoutSelfCondition
        {
            get
            {
                var list = new List<int>();
                if (Companys == null) return null;
                for (var i = 0; i < Companys.Count; i++)
                {
                    if (Companys[i].CompanyID != CompanyID)
                    {
                        list.Add(Companys[i].CompanyID);
                    }
                }
                if (list.Count == 0) return null;
                return $" in ({string.Join(",", list)}) ";
            }
        }
    }
    public class CompanyTypeHeader
    {
        public int Type { get; set; }

        public string TypeName { get; set; }
    }
    public class JurisdictionsHeader
    {
        public int ProvinceCode { get; set; }

        public string ProvinceName { get; set; }

        public int CityCode { get; set; }

        public string CityName { get; set; }

        public int DistrictCode { get; set; }

        public string DistrictName { get; set; }
    }

    public class CompanyHeader
    {
        public int CompanyID { get; set; }

        public string CompanyName { get; set; }

        public string CompanyTypes { get; set; }
    }
}