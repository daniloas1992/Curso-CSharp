using System;
using Trabalhador.Entities;
using Trabalhador.Entities.Enums;
using System.Globalization;

namespace Trabalhador
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter department's name: ");
            string deptName = Console.ReadLine();

            System.Console.WriteLine("Enter worker data: ");
            System.Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            System.Console.WriteLine("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            System.Console.WriteLine("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            System.Console.WriteLine("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                System.Console.WriteLine($"Enter #{i} contract data: ");
                System.Console.WriteLine("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                System.Console.WriteLine("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);
                System.Console.WriteLine("Duration(hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);

                worker.AddConttract(contract);
            }

            System.Console.WriteLine();

            System.Console.WriteLine("Enter month and yer to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            System.Console.WriteLine("Name: " + worker.Name);
            System.Console.WriteLine("Department: " + worker.Department.Name);
            System.Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
