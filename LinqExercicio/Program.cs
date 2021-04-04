using System.IO;
using System;
using System.Collections.Generic;
using LinqExercicio.Entities;
using System.Globalization;
using System.Linq;
namespace LinqExercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"./temp/in.txt";

            List<Product> list = new List<Product>();

            using(StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] fields = sr.ReadLine().Split(',');
                    string name = fields[0];
                    double price = double.Parse(fields[1], CultureInfo.InvariantCulture);

                    list.Add(new Product(name, price));
                }
            }

            var avg = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            System.Console.WriteLine("Average price = " + avg.ToString("F2", CultureInfo.InvariantCulture));

            var names = list.Where(p => p.Price < avg).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach(string name in names)
            {
                System.Console.WriteLine(name);
            }

        }
    }
}
