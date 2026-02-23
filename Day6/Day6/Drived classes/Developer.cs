using System;
using System.Collections.Generic;
using System.Text;

namespace Day6.Drived_classes
{
    internal class Developer : Employee
    {
        public int OverTimeHours { get; set; }
        public decimal OvertimeRate { get; set; }

        public Developer(int id, string name, decimal baseSalary, int hours,decimal rate):
            base(id, name, baseSalary)
        {
            OvertimeRate = rate;
            OverTimeHours = hours;
        }
        public sealed override decimal CalculateSalary()
        {
            return BaseSalary + (OverTimeHours * OvertimeRate);
        }
    }
}
