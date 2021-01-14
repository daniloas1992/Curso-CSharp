using System;
using System.Globalization;
using Pedido.Entities.Enums;
using Pedido.Entities;

namespace Pedido
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            System.Console.Write("Name: ");
            string name = Console.ReadLine();
            System.Console.Write("Email: ");
            string email = Console.ReadLine();
            System.Console.Write("Birth Date (DD/MM/YYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter order data: ");
            System.Console.Write("Satus: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            System.Console.Write("How many items to this order? ");
            int quantityProducts = int.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order order = new Order(status, client);

            for(int i=0; i< quantityProducts; i++)
            {
                System.Console.Write("Product name: ");
                string productName = Console.ReadLine();
                System.Console.Write("Product Price: ");
                double productPrice = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);
                System.Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem item = new OrderItem(quantity, productPrice, product);
                order.AddItem(item);
            }

            System.Console.WriteLine(order);
            
        }
    }
}
