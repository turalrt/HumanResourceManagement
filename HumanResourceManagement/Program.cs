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
                Console.WriteLine("-------------------------Human Resource Management---------------------------");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine(" 1.1 - Departamentlerin siyahisini gostermek");
                Console.WriteLine(" 1.2 - Departament yaratmaq");
                Console.WriteLine(" 1.3 - Departamentde deyisiklik etmek ");
                Console.WriteLine(" 2.1 - Iscilerin siyahisini gostermek ");
                Console.WriteLine(" 2.2 - Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine(" 2.3 - Isci elave etmek");
                Console.WriteLine(" 2.4 - Isci uzerinde deyisiklik etmek");
                Console.WriteLine(" 2.5 - Departamentden isci silinmesi");

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
                        break;
                    case 2.2:
                        Console.Clear();
                        break;
                    case 2.3:
                        Console.Clear();
                        break;
                    case 2.4:
                        Console.Clear();
                        break;
                    case 2.5:
                        Console.Clear();
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
                    Console.WriteLine("Duzgun Daxil Et!");
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
                Employee[] array = new Employee[] { };
                humanResourceManager.AddDepartment(array, name, WorkerLimitNum, salaryLimitNum);
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
        }
    }
}