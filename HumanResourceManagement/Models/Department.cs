using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public Employee[] Employees { get; set; }

        public Department(Employee[] employees, string name, int workerLimit, double salaryLimit)
        {
            if (employees.Length <= 0)
            {
                Console.WriteLine("Employees can not be empty!");
                return;
            }
            Employees = employees;
            
            if (name.Length < 2)
            {
                Console.WriteLine("Department Name must be at least two letters!");
                return;
            }
            Name = name;

            if (workerLimit < 1)
            {
                Console.WriteLine("Worker limit must be more than 0!");
                return;
            }
            WorkerLimit = workerLimit;

            if (salaryLimit < 250)
            {
                Console.WriteLine("Salary cannot be less than 250!");
                return;
            }
            SalaryLimit = salaryLimit;
        }

        public double CalcSalaryAverage()
        {
            int count = 0;
            double SalarySum = 0;
            foreach (Employee item in Employees)
            {
                SalarySum += item.Salary;
                count++;
            }
            return SalarySum / count;
        }
    }
}
