using System;
using System.Collections.Generic;
using System.Text;

namespace Day6.Drived_classes
{
    internal class Intern :Employee
    {
        public decimal TrainingAllowance { get; set; }
        public Intern(int id , string name ,decimal allowance):
            base(id, name, 0)
        {
            TrainingAllowance = allowance;
        }
        public override decimal CalculateSalary()
        {
            return TrainingAllowance;
        }
    }
}
