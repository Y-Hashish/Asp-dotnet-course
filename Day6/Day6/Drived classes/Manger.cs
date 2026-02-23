using System;
using System.Collections.Generic;
using System.Text;

namespace Day6.Drived_classes
{
    internal class Manger: Employee
    {
        public decimal Bouns { get; set; }
        public Manger(int id ,string name , decimal salry, decimal bouns  ):
            base(id, name, salry)
        {
            Bouns = bouns;
        }
        public override decimal CalculateSalary()
        {
            return BaseSalary + Bouns;
        }
    }
}
