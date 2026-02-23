using System;
using System.Collections.Generic;
using System.Text;

namespace Day3
{
    internal struct employee
    {
        public int id;
        public string name;
        public double salary;
        public employee(int empId, string empName, double empSalary)
        {
            id = empId;
            name = empName;
            salary = empSalary;
        }
        public void display()
        {
            
            Console.WriteLine("Employee details : ");
            Console.WriteLine("ID : " + id);
            Console.WriteLine("Name : " + name);
            Console.WriteLine("Salary : " + salary);
        }
        
    }
}
