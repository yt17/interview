using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public virtual int Class_ID { get; set; }
        public virtual Class_ Class_ { get; set; }       
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }        

    }
}
