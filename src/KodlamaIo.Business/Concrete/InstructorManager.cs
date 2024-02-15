using KodlamaIo.Business.Abstract;
using KodlamaIo.Business.Constants;
using KodlamaIo.Core.Util.Result;
using KodlamaIo.DataAccess.Abstract;
using KodlamaIo.Entities.Concrete;

namespace KodlamaIo.Business.Concrete
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorDal _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }

        public async Task<IResult> AddAsync(Instructor instructor)
        {
            await _instructorDal.add(instructor);

            return new SuccessResult(Messages.Added);
        }

        public async Task<IResult> DeleteAsync(Instructor instructor)
        {
            await _instructorDal.delete(instructor);
            return new SuccessResult(Messages.Deleted);
        }

        public async Task<IDataResult<List<Instructor>>> GetAllAsync()
        {
            
            return new SuccessDataResult<List<Instructor>>(await _instructorDal.GetAll(null, null, i => i.Courses),Messages.Listed);
        }

        public async Task<IDataResult<Instructor>> GetByIdAsync(int id)
        {
            return new SuccessDataResult<Instructor>(await _instructorDal.GetById(i=>i.Id == id,i=>i.Courses));
        }

        public async Task<IResult> UpdateAsync(Instructor instructor)
        {
            await _instructorDal.update(instructor);

            return new SuccessResult(Messages.Updated);
        }
    }
}
