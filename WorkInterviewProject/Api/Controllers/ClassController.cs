using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DTO.DTO;
using Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private IClassService classService;
        public ClassController(IClassService classService)
        {
            this.classService = classService;
        }
        
        [HttpPost("CreateClass")]
        [Authorize]
        public Result<ClassDTO> CreateClass(ClassDTO model)
        {
            try
            {
                return classService.CreateClass(model);
            }
            catch (Exception ex)
            {
                return new Result<ClassDTO>(true, ex.Message, null);                
            }
        }
    }
}
