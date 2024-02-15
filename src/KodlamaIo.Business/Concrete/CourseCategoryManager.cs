using KodlamaIo.Business.Abstract;
using KodlamaIo.Business.Constants;
using KodlamaIo.Core.Util.Result;
using KodlamaIo.DataAccess.Abstract;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Concrete
{
    public class CourseCategoryManager : ICourseCategoryService
    {
        private readonly ICourseCategoryDal _courseCategoryDal;

        public CourseCategoryManager(ICourseCategoryDal courseCategoryDal)
        {
            _courseCategoryDal = courseCategoryDal;
        }

        public async Task<IResult> Add(CourseCategory category)
        {
            await _courseCategoryDal.add(category);
            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> Delete(CourseCategory category)
        {
            await _courseCategoryDal.delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<CourseCategory>>> GetAll()
        {
            return new SuccessDataResult<List<CourseCategory>>(await _courseCategoryDal.GetAll(null,null,i=>i.Courses),Messages.Listed);
        }

        public async Task<IDataResult<CourseCategory>> GetById(int id)
        {
            return new SuccessDataResult<CourseCategory>(await _courseCategoryDal.GetById(i=>i.Id == id,i=>i.Courses));
        }

        public async Task<IResult> Update(CourseCategory category)
        {
            await _courseCategoryDal.update(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
