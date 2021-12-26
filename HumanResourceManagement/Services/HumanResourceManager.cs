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

        public HumanResourceManager()
        {
            _departments = new Department[0];
        }

        public void AddDepartment(Employee[] employees, string name, int workerLimit, double salaryLimit)
        {
            Department department = new Department(employees, name, workerLimit, salaryLimit);
            Array.Resize(ref _departments, _departments.Length + 1);
            _departments[_departments.Length - 1] = department;
        }

        public void AddEmployee(string fullname, string position, double salary, string departmentName)
        {
            foreach (Department item in _departments)
            {

                if (item.Name == departmentName)
                {
                    var employees = item.Employees;
                    Employee employee = new Employee(fullname, position, salary, departmentName);
                    Array.Resize(ref employees, employees.Length + 1);
                    employees[employees.Length - 1] = employee;
                }
            }
        }

        public void EditDepartaments(string name, string newName)
        {
            foreach (Department item in _departments)
            {

                if (item.Name == name)
                {
                    item.Name = newName;
                    break;
                }
            }
        }
        public void EditEmployee(string no, string fullname, string position, double salary, string departmentName)
        {
            foreach (Department item in _departments)
            {

                if (item.Name == departmentName)
                {
                    var employees = item.Employees;
                    for (int i = 0; i < employees.Length; i++)
                    {
                        if (employees[i].No == no)
                        {
                            employees[i].Fullname = fullname;
                            employees[i].Position = position;
                            employees[i].Salary = salary;
                            return;
                        }
                    }
                }
            }
        }

        public Department[] GetDepartments()
        {
            return _departments;
        }

        public void RemoveEmployee(string no, string name)
        {
                foreach (Department item in _departments)
                {

                    if (item.Name == name)
                    {
                        for (int i = 0; i<item.Employees.Length; i++)
                        {
                            if (item.Employees[i].No == no)
                            {
                                item.Employees[i] = null;
                                return;
                            }
                        }
                    }
                }
        }
    }
}
