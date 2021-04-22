using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DTO
{
    public class UserForRegisterDTO
    {     

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }
    }
}
