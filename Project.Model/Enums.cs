using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project.Model
{
    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum DatabaseType
    {
        /// <summary>
        /// MYSQL
        /// </summary>
        MySql = 0,
        /// <summary>
        /// ORACLE
        /// </summary>
        Oracle = 1,
    }

    /// <summary>
    /// 地区类型
    /// </summary>
    public enum AreaType
    {
        /// <summary>
        /// 国家  
        /// </summary>
        [Description("国家")]
        Country = 1,

        /// <summary>
        /// 州、省、直辖市、自治区
        /// </summary>
        [Description("州、省、直辖市、自治区")]
        Province,

        /// <summary>
        /// 市
        /// </summary>
        [Description("市")]
        City,

        /// <summary>
        /// 区
        /// </summary>
        [Description("区")]
        District

    }

    /// <summary>
    /// 公司类型 
    /// </summary>
    public enum CompanyType
    {
        /// <summary>
        /// 平台运营商
        /// </summary>
        [Description("平台运营商")]
        Platform = 1,
        /// <summary>
        /// 监控终端制造商
        /// </summary>
        [Description("监控终端制造商")]
        Terminal = 2,
        /// <summary>
        /// 设备租赁公司
        /// </summary>
        [Description("设备租赁公司")]
        EquipmentLease = 3,
        /// <summary>
        /// 建筑公司
        /// </summary>
        [Description("建筑公司")]
        BuildingConstruction = 4,
        /// <summary>
        /// 监管单位
        /// </summary>
        [Description("监管单位")]
        Regulator = 5
    }

    /// <summary>
    /// 权限类型
    /// </summary>
    public enum AuthorType
    {
        /// <summary>
        /// 菜单功能权限
        /// </summary>
        [Description("菜单功能权限")]
        ButtonAuthor = 1,
        /// <summary>
        /// 数据权限
        /// </summary>
        [Description("数据权限")]
        DataAuthor = 2,
        /// <summary>
        /// 菜单权限
        /// </summary>
        [Description("菜单权限")]
        MenuAuthor = 3


    }

    /// <summary>
    /// 权限状态
    /// </summary>
    public enum AuthState
    {
        /// <summary>
        /// 启用
        /// </summary>
        [Description("启用")]
        Enable = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        [Description("禁用")]
        Disable = 2
    }

    /// <summary>
    /// 页面打开方式
    /// </summary>
    public enum OpenType
    {
        /// <summary>
        /// 标签页打开
        /// </summary>
        [Description("tab打开")]
        Tab = 1,
        /// <summary>
        /// 新窗口打开
        /// </summary>
        [Description("blank打开")]
        Blank = 2
    }

    /// <summary>
    /// 文件状态
    /// </summary>
    public enum FileState
    {
        /// <summary>
        /// 文件未下载
        /// </summary>
        [Description("文件未下载")]
        None,

        /// <summary>
        /// 文件下载成功
        /// </summary>
        [Description("文件下载成功")]
        Ok,

        /// <summary>
        /// 文件下载失败
        /// </summary>
        [Description("文件下载失败")]
        Failed
    }

    /// <summary>
    /// 系统代码
    /// </summary>
    public enum AppCode
    {
        /// <summary>
        /// 力航Node前端项目
        /// </summary>
        [Description("力航Node前端项目")]
        None = 1
    }

    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 图片 
        /// </summary>
        [Description("图片")]
        Picture = 0,
        /// <summary>
        /// 附件 
        /// </summary>
        [Description("附件")]
        Attachment = 1
    }

    /// <summary>
    /// 数据字典类型
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 基础模块
        /// </summary>
        [Description("基础模块")]
        BaseModule = 1,

        /// <summary>
        /// 身份识别模块
        /// </summary>
        [Description("身份识别模块")]
        IdentiDistingModule = 2

    }

    /// <summary>
    /// ios andrion 版本更新
    /// </summary>
    public enum VersionState
    {
        /// <summary>
        /// 无需更新
        /// </summary>
        [Description("无需更新")]
        NoUpdate = 1,
        /// <summary>
        /// 建议更新
        /// </summary>
        [Description("建议更新")]
        NeedUpdate = 2,
        /// <summary>
        /// 必须更新
        /// </summary>
        [Description("必须更新")]
        MustUpdate = 3,
    }

    /// <summary>
    /// 操作类型
    /// </summary>
    public enum OperationLogType
    {
        /// <summary>
        /// 数据字典
        /// </summary>
        [Description("数据字典")]
        DataDictionary = 1,
        /// <summary>
        /// 角色
        /// </summary>
        [Description("角色")]
        Role = 2,
        /// <summary>
        /// 角色用户
        /// </summary>
        [Description("角色用户")]
        RoleAccount = 3,
        /// <summary>
        /// 角色功能权限
        /// </summary>
        [Description("角色功能权限")]
        RoleButtonAuthor = 4,
        /// <summary>
        /// 角色菜单权限
        /// </summary>
        [Description("角色菜单权限")]
        RoleMenuAuthor = 5,
    }

    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 注册审批
        /// </summary>
        [Description("注册审批")]
        Register,

        /// <summary>
        /// 到期提醒
        /// </summary>
        [Description("到期提醒")]
        ExpireRemind,
    }

    /// <summary>
    /// 消息阅读类型
    /// </summary>
    public enum MessageReadType
    {
        /// <summary>
        /// 只读
        /// </summary>
        [Description("只读")]
        Readonly = 1,

        /// <summary>
        /// Sign
        /// </summary>
        [Description("签阅")]
        Sign = 2
    }

    /// <summary>
    /// 消息级别
    /// </summary>
    public enum MessageLevel
    {
        /// <summary>
        /// 高
        /// </summary>
        [Description("高")]
        High = 1,

        /// <summary>
        /// 中
        /// </summary>
        [Description("中")]
        Middle,

        /// <summary>
        /// 低
        /// </summary>
        [Description("低")]
        Low
    }

    /// <summary>
    /// 全局消息类型 
    /// </summary>
    public enum MessageGlobalType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")]
        Unknown = 0,

        /// <summary>
        /// 审批
        /// </summary>
        [Description("审批")]

        Audit,
        /// <summary>
        /// 通知
        /// </summary>
        [Description("通知")]

        Notice,
        /// <summary>
        /// 消息
        /// </summary>
        [Description("消息")]
        Message
    }

}
