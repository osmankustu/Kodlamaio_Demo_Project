using KodlamaIo.Core.Util.Result;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Abstract
{
    public interface IInstructorService
    {
        Task<IResult> AddAsync(Instructor instructor);

        Task<IResult> DeleteAsync(Instructor instructor);

        Task<IResult> UpdateAsync(Instructor instructor);

        Task<IDataResult<List<Instructor>>> GetAllAsync();

        Task<IDataResult<Instructor>> GetByIdAsync(int id);
    }
}
