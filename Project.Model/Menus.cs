using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Project.Model
{
    ///<summary>
    ///系统菜单
    ///</summary>
    [SugarTable("t_menus")]
    public class Menus:BaseField
    {
    
           /// <summary>
           /// Desc_New:主键
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ID")]
           public int Id {get;set;}


           /// <summary>
           /// Desc_New:系统代码
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public int AppCode {get;set;}


           /// <summary>
           /// Desc_New:父级菜单id
           /// Default_New:0
           /// Nullable_New:False
           /// </summary>           
           public int ParentID {get;set;}


           /// <summary>
           /// Desc_New:名称
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Name {get;set;}


           /// <summary>
           /// Desc_New:路由
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Route {get;set;}


           /// <summary>
           /// Desc_New:排序
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public int? Sort {get;set;}


           /// <summary>
           /// Desc_New:说明
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Notes {get;set;}


           /// <summary>
           /// Desc_New:模块需求
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Modules {get;set;}


           /// <summary>
           /// Desc_New:图标类
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string IconClass {get;set;}


           /// <summary>
           /// Desc_New:链接打开方式
           /// Default_New:1
           /// Nullable_New:False
           /// </summary>           
           public int Blank {get;set;}


           /// <summary>
           /// Desc_New:相关菜单集
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Relative {get;set;}


           /// <summary>
           /// Desc_New:controller
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Controller {get;set;}

    }
}