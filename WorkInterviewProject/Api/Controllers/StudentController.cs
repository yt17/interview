using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DTO.DTO;
using Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudentService studentService;
        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpPost("CreateStudent")]
        public Result<StudentResultDTO> CreateStudent(StudentAddModel model)
        {
            try
            {
                return studentService.CreateStudent(model);
            }
            catch (Exception e)
            {
                return new Result<StudentResultDTO>(true, e.Message, null);
            }

        }
        [HttpPost("GetStudents")]
        public Result<List<StudentResultDTO>> GetStudents(StudentSearchDTO model)
        {
            try
            {
               return studentService.GetStudents(model);
            }
            catch (Exception e)
            {
                return new Result<List<StudentResultDTO>>(true, e.Message, null);
            }
         
        }
    }
}
