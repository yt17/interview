using DTO.DTO;
using Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IClassService
    {        
        Result<ClassDTO> CreateClass(ClassDTO model);
        
    }
}
