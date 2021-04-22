using DTO.DTO;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IStudentService
    {
        Result<List<StudentResultDTO>> GetStudents(StudentSearchDTO model);
        Result<StudentResultDTO> CreateStudent(StudentAddModel model);
    }
}
