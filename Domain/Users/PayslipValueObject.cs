using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users
{
    public class PayslipValueObject
    {
        public PayslipValueObject(float workingDays, float coefficientsSalary, decimal bonus)
        {
            TotalSalary = (decimal)(workingDays * coefficientsSalary) + bonus;
        }

        public decimal TotalSalary { get; init; }
    }
}
