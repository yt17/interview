using DTO.DTO;
using Entity.Concrete;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        Result<List<OperationClaims>> GetClaims(UserDTO user);
        Result<UserDTO> AddUser(UserDTO user);
        Result<UserDTO> GetUserByMail(string mail);
    }
}
