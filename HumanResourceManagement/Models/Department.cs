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
            Employees = employees;
            
            if (name.Length < 2)
            {
                Console.WriteLine("Departament Adi En Az Iki Herf Olmalidir!");
                return;
            }
            Name = name;

            if (workerLimit < 1)
            {
                Console.WriteLine("Isci Limiti En Az 1 Olmalidir!");
                return;
            }
            WorkerLimit = workerLimit;

            if (salaryLimit < 250)
            {
                Console.WriteLine("Maas Limiti 250-den Asagi Ola Bilmez!");
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

            if (count == 0 || SalarySum == 0)
            {
                return 0;
            }
            return SalarySum / count;
        }
    }
}
