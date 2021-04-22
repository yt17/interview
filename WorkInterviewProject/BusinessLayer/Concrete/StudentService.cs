using BusinessLayer.Abstract;
using DAL.Abstract;
using DTO.DTO;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;
using Helper.Collection;
using System.Linq;
using Entity.Concrete;

namespace BusinessLayer.Concrete
{
    public class StudentService : IStudentService
    {
        private IStudentDAL studentDAL;
        private IUserDAL userDAL;
        public StudentService(IStudentDAL studentDAL, IUserDAL userDAL)
        {
            this.studentDAL = studentDAL;
            this.userDAL = userDAL;
        }
        public Result<StudentResultDTO> CreateStudent(StudentAddModel model)
        {
            var check = studentDAL.Get(w => w.UserID == model.UserID && w.Class_ID == model.ClassID);
            if (check!=null)
            {
                var checkuser = userDAL.Get(w => w.ID == model.UserID && w.UserType == Entity.Concrete.UserType.Student);
                if (checkuser==null)
                {
                    return new Result<StudentResultDTO>(true, "boyle bir kullanici yok", null);
                }
                Student student = new Student()
                {
                    UserID=model.UserID,
                    Class_ID=model.ClassID
                };

                studentDAL.Add(student);
                return new Result<StudentResultDTO>(false, "isleminizi basari ile gerceklemistir", null);
            }
            else
            {
                return new Result<StudentResultDTO>(true, "boyle bir kayit mevcuttur", null);
            }
        }

        public Result<List<StudentResultDTO>> GetStudents(StudentSearchDTO filter)
        {
            IQueryable<Student> students =(IQueryable <Student>)studentDAL.GetList(null);
            var result = students.WhereIf(filter.ClassID != 0, s => s.Class_ID == filter.ClassID)
                .WhereIf(filter.Name != null, s => s.User.Name == filter.Name)
                .WhereIf(filter.Surname != null, s => s.User.Surname == filter.Surname)
                .WhereIf(filter.Classname != null, s => s.Class_.Name == filter.Classname)
                .WhereIf(filter.UserID != null, s => s.UserID == filter.UserID)
                .Select(x=> new StudentResultDTO { 
                  Name=x.User.Name,
                  Surname=x.User.Surname,
                  ClassID=x.Class_ID,
                  UserID=x.UserID,
                  Classname=x.Class_.Name                  
                }).ToList();
            return new Result<List<StudentResultDTO>>(false, "islem basarili", result);
            
        }
    }
}
