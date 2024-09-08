using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEducationService
    {
        Task<IEnumerable<EducationDto>> GetAll();
        Task<EducationDto?> Get(int id);
        Task Edit(EditEducationDto model);
        Task Create(CreateEducationDto model);
        Task Delete(int id);
        Task Archive(int id);
        Task Restore(int id);
    }
}
