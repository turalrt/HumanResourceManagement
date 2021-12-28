using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment(/*Employee[] employees,*/ string name, int workerLimit, double salaryLimit);
        Department[] GetDepartments();
        void EditDepartaments(string name, string newName);

        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void RemoveEmployee(string no, string name);
        void EditEmployee(string no, string fullname, string position, double salary, string departmentName);
    }
}
