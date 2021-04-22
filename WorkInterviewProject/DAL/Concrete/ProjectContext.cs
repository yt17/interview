using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class ProjectContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-120BN2A;Database=IVDB;Integrated Security=SSPI");
        }
        public DbSet<Class_> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaims> UserOperationClaims { get; set; }
        public DbSet<OperationClaims> OperationClaims { get; set; }
    }
}
