using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entity.Concrete
{
    public class Class_
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        //Teacher
        public virtual int UserID { get; set; }
        public virtual User User { get; set; }
        public bool Status { get; set; }
        public string Year { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        //public virtual int studentID { get; set; }
        //public virtual Student Student { get; set; }

    }
}
