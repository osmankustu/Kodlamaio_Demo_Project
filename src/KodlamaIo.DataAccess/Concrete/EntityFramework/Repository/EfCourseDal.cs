using KodlamaIo.Core.DataAccess.EntityFramework;
using KodlamaIo.DataAccess.Abstract;
using KodlamaIo.DataAccess.Concrete.EntityFramework.Context;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.DataAccess.Concrete.EntityFramework.Repository
{
    public class EfCourseDal : EfRepositoryBase<Course,KodlamaioContext>,ICourseDal
    {
    }
}
