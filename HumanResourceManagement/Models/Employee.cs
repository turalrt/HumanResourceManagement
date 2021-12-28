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
            Fullname = fullname;
            
            No += departmentName.Substring(0, 2) + Count;
            DepartmentName = departmentName;

            if (position.Length<2 )
            {
                Console.WriteLine("Iscinin Vezifesi En Az Iki Herf Olmalidir!");
                return;
            }
            Position = position;
            if (salary <250)
            {
                Console.WriteLine("Maas 250-den Asagi Ola Bilmez!");
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
