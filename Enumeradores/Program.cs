using System;
using Enumeradores.Entities;
using Enumeradores.Entities.Enums;

namespace Enumeradores
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.PendingPayment

            };

            Console.WriteLine(order);

            string text = OrderStatus.PendingPayment.ToString();
            OrderStatus os = Enum.Parse<OrderStatus>("Delivered");

            Console.WriteLine(text);
            Console.WriteLine(os);
        }
    }
}
