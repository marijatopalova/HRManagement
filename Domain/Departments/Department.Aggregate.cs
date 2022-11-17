using Domain.Base;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Departments
{
    public partial class Department : IAggregateRoot
    {
        public Department()
        {
            Users = new HashSet<User>();
        }

        public Department(string name, string description) : this()
        {
            this.Update(name, description);
        }

        public void Update(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
