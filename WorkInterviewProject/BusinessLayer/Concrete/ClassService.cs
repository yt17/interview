using BusinessLayer.Abstract;
using DAL.Abstract;
using DTO.DTO;
using Entity.Concrete;
using Helper;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ClassService : IClassService
    {
        private IClassDAL classDAL;
        private IUserDAL userDAL;
        public ClassService(IClassDAL classDAL, IUserDAL userDAL)
        {
            this.classDAL = classDAL;
            this.userDAL = userDAL;
        }
        public Result<ClassDTO> CreateClass(ClassDTO model)
        {
            try
            {
                var check = userDAL.Get(w => w.ID == model.UserID && w.UserType == Entity.Concrete.UserType.Teacher);
                if (check==null)
                {
                    return new Result<ClassDTO>(false, "boyle bir egitmen yok", null);
                }
                Class_ class_ = model.Adapt<Class_>();                
                classDAL.Add(class_);
                return new Result<ClassDTO>(false, "islem basarili sekilde tamamlanmistir", null);
            }
            catch (Exception ex)
            {
                return new Result<ClassDTO>(true, ex.Message, null);
                
            }
            

        }
    }
}
