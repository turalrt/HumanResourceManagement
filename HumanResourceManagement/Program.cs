using System;
using HumanResourceManagement.Services;
using HumanResourceManagement.Models;

namespace HumanResourceManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee employee1 = new Employee("Tural Tagiyev", "Processor", 15000, "Engineering");
            //Employee employee2 = new Employee("Zaur Ibrahimov", "Po", 555, "fsdff");
            //Console.WriteLine(employee1);
            //Console.WriteLine(employee2);

            HumanResourceManager humanResourceManager = new HumanResourceManager();
            do
            {
                Console.WriteLine("********************Human Resource Management********************");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1.1 - Departamentlerin siyahisini gostermek");
                Console.WriteLine("1.2 - Departament yaratmaq");
                Console.WriteLine("1.3 - Departamentde deyisiklik etmek ");
                Console.WriteLine("2.1 - Iscilerin siyahisini gostermek ");
                Console.WriteLine("2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 - Isci elave etmek");
                Console.WriteLine("2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 - Departamentden isci silinmesi");

                string choose = Console.ReadLine();
                double chooseNum;
                double.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1.1:
                        Console.Clear();
                        GetDepartments(ref humanResourceManager);
                        break;
                    case 1.2:
                        Console.Clear();
                        AddDepartment(ref humanResourceManager);
                        break;
                    case 1.3:
                        Console.Clear();
                        EditDepartment(ref humanResourceManager);
                        break;
                    case 2.1:
                        Console.Clear();
                        AllEmployeesList(ref humanResourceManager);
                        break;
                    case 2.2:
                        Console.Clear();
                        DepEmployessList(ref humanResourceManager);
                        break;
                    case 2.3:
                        Console.Clear();
                        AddEmployee(ref humanResourceManager);
                        break;
                    case 2.4:
                        Console.Clear();
                        EditEmployee(ref humanResourceManager);
                        break;
                    case 2.5:
                        Console.Clear();
                        RemoveEmployee(ref humanResourceManager);
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun daxil et!");
                        break;
                }
            } while (true);

            static void GetDepartments(ref HumanResourceManager humanResourceManager)
            {

                if (humanResourceManager.Departments.Length > 0)
                {
                    foreach (Department item in humanResourceManager.Departments)
                    {
                        Console.WriteLine($"{item} - Ad: {item.Name}\n");
                        Console.WriteLine($"{item} - Isci Sayi: {item.Employees.Length}\n");
                        Console.WriteLine($"{item} - Maas Ortalamasi: {item.CalcSalaryAverage()}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Departament Movcud Deyil!\n");
                }
            }

            static void AddDepartment(ref HumanResourceManager humanResourceManager)
            {

                Console.WriteLine("Departamentin Adini Daxil Et:");
                string name = Console.ReadLine();
                Console.WriteLine("Isci Limitini Daxil Et:");
                string WorkerLimit = Console.ReadLine();
                int WorkerLimitNum;
                while (!int.TryParse(WorkerLimit, out WorkerLimitNum) || WorkerLimitNum < 1)
                {
                    Console.WriteLine("Duzgun Daxil Et:");
                    WorkerLimit = Console.ReadLine();
                }

                Console.WriteLine("Maas Limitini Daxil Et:");
                string salaryLimit = Console.ReadLine();
                double salaryLimitNum;
                while (!double.TryParse(salaryLimit, out salaryLimitNum) || salaryLimitNum < 250)
                {
                    Console.WriteLine("Duzgun Daxil Et:");
                    salaryLimit = Console.ReadLine();
                }
                //Employee[] array = new Employee[] { };
                humanResourceManager.AddDepartment(/*array,*/ name, WorkerLimitNum, salaryLimitNum);
            }

            static void EditDepartment(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("Deyisiklik Edilecek Departamentin Adini Daxil Et:");
                string name = Console.ReadLine();

                bool departmentFound = false;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name == name)
                    {
                        departmentFound = true;
                        Console.WriteLine("Deyisiklik Edilecek Departamentin Yeni Adini Daxil Et:");
                        string newName = Console.ReadLine();
                        humanResourceManager.EditDepartaments(name, newName);
                    }
                }
                if (!departmentFound)
                {
                    Console.WriteLine("Daxil Edilen Departament Duzgun Deyil!");
                    return;
                }
            }

            static void AllEmployeesList(ref HumanResourceManager humanResourceManager)
            {
                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee employee in item.Employees)
                    {
                        Console.WriteLine($"{employee} - Nomre: {employee.No}\n");
                        Console.WriteLine($"{employee} - Ad: {employee.Fullname}\n");
                        Console.WriteLine($"{employee} - Departament Adi: {employee.DepartmentName}\n");
                        Console.WriteLine($"{employee} - Maas: {employee.Salary}\n");
                    }
                }

            }

            static void DepEmployessList(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("Iscilerinin Infosunu Almaq Istediyiniz Departamentin Adini Daxil Et:");
                string name = Console.ReadLine();
                bool departmentFound = false;

                if (name.Length < 2)
                {
                    Console.WriteLine("Duzgun Daxil Et:");
                    return;
                }

                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name == name)
                    {
                        departmentFound = true;
                        foreach (Employee employee in item.Employees)
                        {
                            Console.WriteLine($"{employee} - Nomre: {employee.No}\n");
                            Console.WriteLine($"{employee} - Ad: {employee.Fullname}\n");
                            Console.WriteLine($"{employee} - Vezife: {employee.Position}\n");
                            Console.WriteLine($"{employee} - Maas: {employee.Salary}\n");
                        }
                    }
                }
                if (!departmentFound)
                {
                    Console.WriteLine("Daxil Edilen Departament Duzgun Deyil!");
                    return;
                }
            }

            static void AddEmployee(ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("Departamentin Adini Daxil Et:");
                string departmentName = Console.ReadLine();
                while (departmentName.Length < 2)
                {
                    Console.WriteLine("Duzgun Daxil Et:");
                    departmentName = Console.ReadLine();
                }

                Console.WriteLine("Iscinin Adini Daxil Et:");
                string fullname = Console.ReadLine();
                while (fullname.Length < 1)
                {
                    Console.WriteLine("Duzgun Daxil Et:");
                    fullname = Console.ReadLine();
                }

                Console.WriteLine("Iscinin Vezifesini Daxil Et:");
                string position = Console.ReadLine();
                while (position.Length < 2)
                {
                    Console.WriteLine("Duzgun Daxil Et:");
                    position = Console.ReadLine();
                }

                Console.WriteLine("Iscinin Maasini Daxil Et:");
                string salary = Console.ReadLine();
                double salaryNum;
                while (!double.TryParse(salary, out salaryNum) || salaryNum < 250)
                {
                    Console.WriteLine("Duzgun Daxil Et:");
                    salary = Console.ReadLine();
                }

                humanResourceManager.AddEmployee(fullname, position, salaryNum, departmentName);
            }

            static void EditEmployee (ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("Deyisiklik Edilecek Iscinin Nomresini Daxil Et:");
                string no = Console.ReadLine();
                bool employeeFound = false;

                foreach (Department item in humanResourceManager.Departments)
                {
                    foreach (Employee employee in item.Employees)
                    {
                        if (employee.No == no)
                        {
                            employeeFound = true;
                            Console.WriteLine($"{employee} - Ad: {employee.Fullname}\n");
                            Console.WriteLine($"{employee} - Vezife: {employee.Position}\n");
                            Console.WriteLine($"{employee} - Maas: {employee.Salary}\n");

                            Console.WriteLine("Iscinin Yeni Vezifesini Daxil Et:");
                            string position = Console.ReadLine();
                            while (position.Length < 2)
                            {
                                Console.WriteLine("Duzgun Daxil Et:");
                                position = Console.ReadLine();
                            }

                            Console.WriteLine("Iscinin Yeni Maasini Daxil Et:");
                            string salary = Console.ReadLine();
                            double salaryNum;
                            while (!double.TryParse(salary, out salaryNum) || salaryNum < 250)
                            {
                                Console.WriteLine("Duzgun Daxil Et:");
                                salary = Console.ReadLine();
                            }

                            humanResourceManager.EditEmployee(employee.No, employee.Fullname, position, salaryNum, employee.DepartmentName);
                        }
                    }

                }
                if (!employeeFound)
                {
                    Console.WriteLine("Daxil Edilen Isci Nomresi Duzgun Deyil!");
                    return;
                }

            }

            static void RemoveEmployee (ref HumanResourceManager humanResourceManager)
            {
                Console.WriteLine("Silinecek Iscinin Departamentini Daxil Et:");
                string departmentName = Console.ReadLine();
                bool departmentFound = false;
                bool employeeFound = false;
                foreach (Department item in humanResourceManager.Departments)
                {
                    if (item.Name == departmentName)
                    {
                        Console.WriteLine("Silinecek Iscinin Nomresini Daxil Et:");
                        string no = Console.ReadLine();
                        foreach (Employee employee in item.Employees)
                        {
                            if (employee.No == no)
                            {
                                humanResourceManager.RemoveEmployee(no, departmentName);
                            }
                        }
                    }

                }

                if (!departmentFound)
                {
                    Console.WriteLine("Daxil Edilen Departament Duzgun Deyil!");
                    return;
                }

                if (!employeeFound)
                {
                    Console.WriteLine("Daxil Edilen Isci Nomresi Duzgun Deyil!");
                    return;
                }
            }

        }
    }
}