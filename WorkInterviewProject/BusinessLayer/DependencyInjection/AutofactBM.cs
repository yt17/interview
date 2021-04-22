using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Core.JWT;
using DAL.Abstract;
using DAL.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DependencyInjection
{
    public class AutofactBM: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           builder.RegisterType<AuthService>().As<IAuthService>();
           builder.RegisterType<ClassService>().As<IClassService>();
           builder.RegisterType<StudentService>().As<IStudentService>();
           builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EfClass>().As<IClassDAL>();
            builder.RegisterType<EfOperationClaim>().As<IOperationClaimDAL>();
            builder.RegisterType<EfStudent>().As<IStudentDAL>();
            builder.RegisterType<EfUser>().As<IUserDAL>();
            builder.RegisterType<EfUserOperationClaim>().As<IUserOperationClaim>();
            builder.RegisterType<JWTHELPER>().As<ITokenHelper>();


        }
    }
}
