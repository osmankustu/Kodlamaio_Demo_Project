using KodlamaIo.Core.Util.Result;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Abstract
{
    public interface ICourseCategoryService
    {
        Task<IResult> Add(CourseCategory category);

        Task<IResult> Update(CourseCategory category);

        Task<IResult> Delete(CourseCategory category);

        Task<IDataResult<List<CourseCategory>>> GetAll();

        Task<IDataResult<CourseCategory>> GetById(int id);
    }
}
