using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public string FullName { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee(int id, string fullName , decimal baseSalary)
        {
            EmpId = id;
            FullName = fullName;
            BaseSalary = baseSalary;
        }
        public virtual decimal CalculateSalary()
        {
            return BaseSalary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Employee ID: {EmpId}, Name: {FullName}, Salary: {CalculateSalary():C}");
        }
    }
    
}
