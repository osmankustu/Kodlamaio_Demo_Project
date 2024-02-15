using KodlamaIo.Core.Util.Result;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Abstract
{
    public interface ICourseService 
    {

        Task<IResult> AddAsync(Course course);

        Task<IResult> DeleteAsync(Course course);

        Task<IResult> UpdateAsync(Course course);

        Task<IDataResult<List<Course>>> GetAllAsync();

        Task<IDataResult<Course>> GetByIdAsync(int id);
    }
}
