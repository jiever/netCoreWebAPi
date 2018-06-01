using Project.Model;
using Project.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.IBLL
{
    public interface IPictureService : IServiceBase<Picture>
    {
        /// <summary>
        /// 根据Id查询图片
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="isValid">是否有效  默认为不筛选</param>
        /// <returns></returns>
        Picture GetPicture(int id, bool? isValid);
        /// <summary>
        /// 根据Id字符串查询图片
        /// </summary>
        /// <param name="ids">主键</param>
        /// <param name="isValid">是否有效  默认为不筛选 </param>
        /// <returns></returns>
        List<Picture> GetPictures(string ids, bool? isValid);

        /// <summary>
        /// 修改图片说明 并把图片置为有效
        /// </summary>
        /// <param name="fileKeyDescriptionDtos"></param>
        /// <returns></returns>
        bool UpdatePictureDescription(List<FileKeyDescriptionDto> fileKeyDescriptionDtos);
        /// <summary>
        /// 批量删除指定日期的无效图片 不传时间则删除所有无效图片
        /// </summary>
        /// <param name="date"></param>
        void DeleteNoValidPictures(DateTime? date);
    }
}
