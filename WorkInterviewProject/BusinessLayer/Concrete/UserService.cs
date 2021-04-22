using BusinessLayer.Abstract;
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
    public class UserService : IUserService
    {
        private IUserDAL userDAL;
        public UserService(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        public Result<UserDTO> AddUser(UserDTO user)
        {       
            try
            {
                byte[] passworHash, passwordSalt;
                User us = user.Adapt<User>();
                HashingHelper.CreatePasswordHash(user.Password, out passworHash, out passwordSalt);
                us.PasswordHash = passworHash;
                us.PasswordSalt = passwordSalt;                
                userDAL.Add(us);
                return new Result<UserDTO>(false, "Islem Basarili", null);
            }
            catch (Exception ex)
            {
                return new Result<UserDTO>(true, ex.Message, user);               
            }           
        }

        public Result<List<OperationClaims>> GetClaims(UserDTO user)
        {
            User res = userDAL.Get(w => w.Email == user.Email && w.Name == user.Name && w.Surname == user.Surname);
            var re= userDAL.GetOperationClaims(res);
            return new Result<List<OperationClaims>>(false, "", re);            
        }

        public Result<UserDTO> GetUserByMail(string mail)
        {
            var Record = userDAL.Get(w => w.Email == mail);
            if (Record==null)
            {
                return new Result<UserDTO>(true, "boyle bir kullanici yok", null);
            }
            UserDTO Result_ = Record.Adapt<UserDTO>();
            return new Result<UserDTO>(false, "islem basarili", Result_);
        }

  
    }
}
