using System;
using System.Collections.Generic;
using Produtos.Entities;
using System.Globalization;

namespace Produtos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i=1; i<=n; i++)
            {
                System.Console.WriteLine($"Product #{i} data: ");
                System.Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());

                System.Console.Write("Name: ");
                string name = Console.ReadLine();

                System.Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine());

                if(type == 'i')
                {
                    System.Console.Write("Customs Fee: ");
                    double customsFee = double.Parse(Console.ReadLine());
                    list.Add(new ImportedProduct(name, price, customsFee));
                } else if( type == 'u')
                {
                    System.Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, manufactureDate));
                } else {
                    list.Add(new Product(name, price));
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine("PRICE TAGS:");
            foreach(Product prod in list)
            {
                System.Console.WriteLine(prod.priceTag());
            }

        }
    }
}
