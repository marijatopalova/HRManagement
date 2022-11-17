using Domain.Base;
using Domain.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public partial class User : BaseEntity<int>
    {
        public User()
        {
            Payslips = new HashSet<Payslip>();
        }

        public string UserName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public int? DepartmentId { get; private set; }
        public float CoefficientsSalary { get; private set; }

        public virtual Department Department { get; private set; }
        public virtual ICollection<Payslip> Payslips { get; private set; }
    }
}
