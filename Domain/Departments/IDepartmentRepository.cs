using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Departments
{
    public interface IDepartmentRepository : IAsyncRepository<Department>
    {
    }
}
