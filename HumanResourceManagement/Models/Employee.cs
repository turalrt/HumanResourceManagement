using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Models
{
    class Employee
    {
        private static int Count = 1000; /*yaddasda qalsin deye static*/
        public string No { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public string DepartmentName { get; set; }

        public Employee(string fullname, string position, double salary, string departmentName) /*user terefinden daxil olunanlar*/
        {
            Count++;
            No += departmentName.Substring(0, 2) + Count;
            DepartmentName = departmentName;
            Fullname = fullname;
            if (position.Length<2 )
            {
                Console.WriteLine("Department Name must be at least two letters!");
                return;
            }
            Position = position;
            if (salary <250)
            {
                Console.WriteLine("Salary cannot be less than 250!");
                return;
            }
            Salary = salary;
            
        }
        //public override string ToString()
        //{
        //    return $"Nomresi: {No}\nName: {Fullname}\nVezife: {Position}\nMaas: {Salary}\nDepartament: {DepartmentName}";
        //}
    }
}
