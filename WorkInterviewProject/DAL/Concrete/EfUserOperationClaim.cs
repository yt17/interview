using Core.Entity;
using DAL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class EfUserOperationClaim : RepositoryBase<ProjectContext, UserOperationClaims>, IUserOperationClaim
    {
     
    }
}
