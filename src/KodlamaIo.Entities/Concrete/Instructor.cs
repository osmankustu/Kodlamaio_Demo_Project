using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Entities.Concrete
{
    public class Instructor : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
 

        public virtual ICollection<Course> Courses { get; set; }
    }
}
