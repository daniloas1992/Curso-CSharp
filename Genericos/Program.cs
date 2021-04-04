using System;
using System.Globalization;
using System.Collections.Generic;
using Genericos.Services;
using Genericos.Entities;

namespace Genericos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            System.Console.WriteLine("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] vect = Console.ReadLine().Split(',');
                string name = vect[0];
                double price = double.Parse(vect[1], CultureInfo.InvariantCulture);
                list.Add(new Product(name, price));
            }

            CalculationService calculationService = new CalculationService();

            Product max = calculationService.Max(list);

            System.Console.WriteLine("Max:");
            System.Console.WriteLine(max);
        }
    }
}
