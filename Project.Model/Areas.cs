using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Project.Model
{
    ///<summary>
    ///全球地区
    ///</summary>
    [SugarTable("cm_areas")]
    public class Areas
    {
    
           /// <summary>
           /// Desc_New:
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ID")]
           public int Id {get;set;}


           /// <summary>
           /// Desc_New:名称
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public string Name {get;set;}


           /// <summary>
           /// Desc_New:父级id
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public int? ParentID {get;set;}


           /// <summary>
           /// Desc_New:地区类型
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public int Type {get;set;}


           /// <summary>
           /// Desc_New:完整拼音
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string FullPinying {get;set;}


           /// <summary>
           /// Desc_New:拼音缩写
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string ShortPinying {get;set;}


           /// <summary>
           /// Desc_New:是否常用地区
           /// Default_New:0
           /// Nullable_New:False
           /// </summary>           
           public byte IsUsual {get;set;}

    }
}