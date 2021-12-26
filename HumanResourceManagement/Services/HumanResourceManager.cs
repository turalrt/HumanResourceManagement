using HumanResourceManagement.Interfaces;
using HumanResourceManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourceManagement.Services
{
    class HumanResourceManager : IHumanResourceManager
    {
        public Department[] Departments => _departments;
        private Department[] _departments;

        public void AddDepartment(Department[] Departments)
        {
           Department department = new Department()
        }

        public void AddEmployee()
        {
            throw new NotImplementedException();
        }

        public void EditDepartaments(Department[] Departments)
        {
            throw new NotImplementedException();
        }

        public void EditEmployee()
        {
            throw new NotImplementedException();
        }

        public void GetDepartments(Department[] Departments)
        {
            throw new NotImplementedException();
        }

        public void RemoveEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
