using Core.JWT;
using DTO.DTO;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        Result<UserDTO> Register(UserDTO userForRegisterDto);
        Result<UserDTO> Login(UserForLoginDTO userForLoginDto);
        Result<string> userExists(string mail);
        Result<AccessToken> CreateAccestoken(UserDTO user);
    }
}
