using Core.Entity;
using DAL.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DAL.Concrete
{
    public class EfUser : RepositoryBase<ProjectContext, User>, IUserDAL
    {

        public List<OperationClaims> GetOperationClaims(User user)
        {

            using (var context = new ProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.ID
                             select new OperationClaims
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };

                return result.ToList();
            }
        }


    }
}
