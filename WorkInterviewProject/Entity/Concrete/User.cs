using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public UserType UserType { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Class_> Classes { get; set; }

    }
    //public enum Status: byte
    //{
    //    [Description("Active Student")]
    //    Student=0,
    //    [Description("Graduated Student")]
    //    Graduated =1,
    //    [Description("Expelled Student")]
    //    Expelled = 2,
    //    [Description("Parent of Active Student")]
    //    ParentAS = 3,
    //    [Description("Parent of Graduated Student")]
    //    ParentGS = 4,
    //    [Description("Parent of Expelled Student")]
    //    ParentES = 5,
    //    [Description("Teacher who works in school")]
    //    TeacherWS = 6,
    //    [Description("Teacher who doesn't work in chool")]
    //    ParentDWS = 7,
    //    [Description("Director who works in school")]
    //    DirectorWS = 8,
    //}

    public enum UserType : byte
    {
        [Description("Student")]
        Student=0,
        [Description("Parent")]
        Parent=1,
        [Description("Teacher")]
        Teacher =2,
        [Description("Director")]
        Director =3,

    }
}
