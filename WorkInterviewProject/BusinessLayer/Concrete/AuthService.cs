using BusinessLayer.Abstract;
using Core.JWT;
using DAL.Abstract;
using DTO.DTO;
using Entity.Concrete;
using Helper;
using Helper.HashingHelper;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserDAL userDAL;

        public AuthService(IUserService userService, ITokenHelper tokenHelper, IUserDAL userDAL)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            this.userDAL = userDAL;
        }
        public Result<AccessToken> CreateAccestoken(UserDTO user)
        {
            var userch = userDAL.Get(w => w.Email==user.Email);
            var claims = userDAL.GetOperationClaims(userch);
            var accessToken = _tokenHelper.CreateAccessToken(userch, claims);
            return new Result<AccessToken>(true, "basarili", accessToken);
        }

        public Result<UserDTO> Login(UserForLoginDTO userForLoginDto)
        {
            var usertocheck = GetUserByMail(userForLoginDto.Email);            
            if (usertocheck == null)
            {
                return new Result<UserDTO>(false, "hata var", null);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, usertocheck.Data.PasswordHash, usertocheck.Data.PasswordSalt))
            {
                return new Result<UserDTO>(false, "hata var", null);
            }
            UserDTO userDTO = usertocheck.Adapt<UserDTO>();
            return new Result<UserDTO>(true, "basarili", userDTO);
        }
        private Result<User> GetUserByMail(string mail)
        {
            var Record = userDAL.Get(w => w.Email == mail);
            if (Record == null)
            {
                return new Result<User>(true, "boyle bir kullanici yok", null);
            }           
            return new Result<User>(false, "islem basarili", Record);
        }
        
        public Result<UserDTO> Register(UserDTO userForRegister)
        {          
            var res=_userService.AddUser(userForRegister);
            if (res.HasError==false)
            {
                return new Result<UserDTO>(false, "basarili", res.Data);
            }
            else
            {
                return new Result<UserDTO>(true, "basarisiz", null);
            }
           

        }

        public Result<string> userExists(string mail)
        {
            var usertocheck = _userService.GetUserByMail(mail);
            if (usertocheck.Data!=null)
            {
                return new Result<string>(false, "hata var", "");
            }

            return new Result<string>(true, "tamam", "");
        }
    }
}
