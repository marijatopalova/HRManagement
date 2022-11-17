using Domain.Base;
using Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public partial class User : IAggregateRoot
    {
        public User(string userName, string fistName, string lastName, string address, int departmentId, DateTime? birthDate)
        {
            UserName = userName;
            Update(fistName, lastName, address, departmentId, birthDate);
        }

        public void Update(string fistName, string lastName, string address, int departmentId, DateTime? birthDate)
        {
            FirstName = fistName;
            LastName = lastName;
            Address = address;
            DepartmentId = departmentId;
            BirthDate = birthDate;
        }

        public void AddDepartments(int departmentId)
        {
            DepartmentId = departmentId;
        }

        public Payslip AddPayslip(DateTime date, float workingDays, decimal bonus, bool isPaid)
        {
            var exists = Payslips.Any(x => x.Date.Month == date.Month && x.Date.Year == date.Year);
            if (exists)
                throw new Exception("Payslip for this month already exists");

            var payslip = new Payslip(this.Id, date, workingDays, bonus);

            if (isPaid)
            {
                payslip.Pay(this.CoefficientsSalary);
            }

            Payslips.Add(payslip);

            var addEvent = new OnPayslipAddedDomainEvent()
            {
                Payslip = payslip,
            };

            AddEvent(addEvent);

            return payslip;
        }
    }
}
