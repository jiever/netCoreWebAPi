using Project.IBLL;
using Project.Model;
using Project.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL
{
    public class PictureService : IPictureService
    {
        public void DeleteNoValidPictures(DateTime? date)
        {
            throw new NotImplementedException();
        }

        public bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Picture GetByPk(int id)
        {
            throw new NotImplementedException();
        }

        public Picture GetPicture(int id, bool? isValid)
        {
            throw new NotImplementedException();
        }

        public List<Picture> GetPictures(string ids, bool? isValid)
        {
            throw new NotImplementedException();
        }

        public int Insert(Picture entity)
        {
            throw new NotImplementedException();
        }

        public bool Insert(List<Picture> entitys)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(int id)
        {
            throw new NotImplementedException();
        }

        public bool SoftDelete(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public bool Update(Picture entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(List<Picture> entitys)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePictureDescription(List<FileKeyDescriptionDto> fileKeyDescriptionDtos)
        {
            throw new NotImplementedException();
        }
    }
}
