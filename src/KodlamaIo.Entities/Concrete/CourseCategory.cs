using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Entities.Concrete
{
    public class CourseCategory : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
