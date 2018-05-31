using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Project.Model
{
    ///<summary>
    ///油耗消费
    ///</summary>
    [SugarTable("FuelConsumptions")]
    public class FuelConsumptions:BaseField
    {
    
           /// <summary>
           /// Desc_New:自增主键
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true,ColumnName="ID")]
           public int Id {get;set;}


           /// <summary>
           /// Desc_New:车辆id
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public int? VehicleID {get;set;}


           /// <summary>
           /// Desc_New:车牌号
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string VehicleLicenseNo {get;set;}


           /// <summary>
           /// Desc_New:加油日期
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public long Date {get;set;}


           /// <summary>
           /// Desc_New:车队
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string VehicleTeam {get;set;}


           /// <summary>
           /// Desc_New:油品
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string FuelType {get;set;}


           /// <summary>
           /// Desc_New:加油量（升）
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public double Amount {get;set;}


           /// <summary>
           /// Desc_New:单价
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public double Price {get;set;}


           /// <summary>
           /// Desc_New:加油地点
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Site {get;set;}


           /// <summary>
           /// Desc_New:备注1
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Notes1 {get;set;}


           /// <summary>
           /// Desc_New:备注2
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Notes2 {get;set;}


           /// <summary>
           /// Desc_New:备注3
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Notes3 {get;set;}


           /// <summary>
           /// Desc_New:卡号
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string CardNumber {get;set;}


           /// <summary>
           /// Desc_New:标识
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string Sign {get;set;}


           /// <summary>
           /// Desc_New:
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public int DriverID {get;set;}


           /// <summary>
           /// Desc_New:
           /// Default_New:
           /// Nullable_New:False
           /// </summary>           
           public string DriverName {get;set;}


           /// <summary>
           /// Desc_New:
           /// Default_New:
           /// Nullable_New:True
           /// </summary>           
           public string VehicleNumber {get;set;}

    }
}