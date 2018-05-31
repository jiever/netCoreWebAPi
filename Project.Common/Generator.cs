using Newtonsoft.Json;
using Project.Common.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;

namespace Project.Common
{
    public class Generator
    {
        /// <summary>
        /// 获取枚举的描述
        /// </summary>
        /// <param name="enum">枚举</param>
        /// <param name="name">枚举名</param>
        /// <returns>返回枚举的描述</returns>
        public static string GetDescription(Type @enum, string name)
        {
            var field = @enum.GetField(name);
            if (field == null) return string.Empty;
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute?.Description;
        }

    }
}
