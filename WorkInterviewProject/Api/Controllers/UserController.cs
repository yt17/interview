using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DTO.DTO;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAuthService authService;
        private IUserService userService;
        public UserController(IAuthService authService, IUserService userService)
        {
            this.authService = authService;
            this.userService = userService;
        }
        [HttpPost("login")]
        public ActionResult Login(UserForLoginDTO userForLoginDto)
        {
            var Usetolog = authService.Login(userForLoginDto);
            if (!Usetolog.HasError == false)
            {
                return BadRequest(Usetolog.Message);
            }

            var result = authService.CreateAccestoken(Usetolog.Data);
            if (result.HasError == false)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("Register")]
        public ActionResult Register(UserForRegisterDTO userForRegisterDto)
        {
            var userexit = authService.userExists(userForRegisterDto.Email);
            if (userexit.HasError == false)
            {
                return BadRequest(userexit.Message);
            }
            var user = userService.GetUserByMail(userForRegisterDto.Email);
            var us = userForRegisterDto.Adapt<UserDTO>();
            var registerresult = authService.Register(us);
           
            var result = authService.CreateAccestoken(us);
            if (result.HasError == true)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
