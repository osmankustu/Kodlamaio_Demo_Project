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
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;

        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }

        public async Task<IResult> AddAsync(Course course)
        {
           await _courseDal.add(course);
            
            return  new SuccessResult(Messages.Added);
        }

        public async Task<IResult> DeleteAsync(Course course)
        {
            await _courseDal.delete(course);

            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<Course>>> GetAllAsync()
        {
            
            return new SuccessDataResult<List<Course>>(await _courseDal.GetAll(null,null ,i=>i.Instructor,i=>i.CourseCategory),Messages.Listed);
        }

        public async Task<IDataResult<Course>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Course>(await _courseDal.GetById(i=>i.Id ==id,i=>i.Instructor ,i=> i.CourseCategory));
        }

        public async Task<IResult> UpdateAsync(Course course)
        {
           await _courseDal.update(course);

            return new SuccessResult(Messages.Updated);
        }
    }
}
