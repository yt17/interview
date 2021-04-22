using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DTO
{
    public class StudentSearchDTO
    {
        public int? UserID { get; set; }
        public int? ClassID { get; set; }
        public string Classname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
