using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStore.Core.Entites;

namespace TestStore.DAL.Entites.EntityBase
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<PersonRole> PersonRole { get; set; }
    }
}
