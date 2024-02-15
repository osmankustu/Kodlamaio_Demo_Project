using KodlamaIo.Core.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Entities.Concrete
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
