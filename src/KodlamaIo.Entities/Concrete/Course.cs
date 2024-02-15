using KodlamaIo.Core.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Entities.Concrete
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseCategoryId { get; set; }

        public int InstructorId { get; set; }     

        public virtual Instructor Instructor { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }
    }
}
