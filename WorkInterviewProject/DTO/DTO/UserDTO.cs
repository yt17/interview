using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DTO.DTO
{
    public class UserDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
    public enum UserType : byte
    {
        [Description("Student")]
        Student = 0,
        [Description("Parent")]
        Parent = 1,
        [Description("Teacher")]
        Teacher = 2,
        [Description("Director")]
        Director = 3,

    }
}
