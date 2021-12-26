using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Interfaces
{
    interface IHumanResourceManager
    {
        Department[] Departments { get; }
        void AddDepartment();
        void GetDepartments();
        void EditDepartaments();

        void AddEmployee();
        void RemoveEmployee();
        void EditEmployee();
    }
}
