using Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Users.Events
{
    public class OnPayslipAddedDomainEvent : BaseDomainEvent
    {
        public Payslip Payslip { get; set; }
    }
}
