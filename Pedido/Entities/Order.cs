using System;
using System.Collections.Generic;
using Pedido.Entities.Enums;
using System.Text;
using System.Globalization;

namespace Pedido.Entities
{
    class Order
    {
        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {
        }

        public Order(OrderStatus status, Client client)
        {
            Moment = DateTime.Now;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }

        public double Total()
        {
            double sum = 0.0;

            foreach(OrderItem order in Items)
            {
                sum += order.SubTotal();
            }

            return sum;
        }

        public override string ToString()
        {   
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");

            double sum = 0.0;

            foreach(OrderItem item in Items)
            {
                sb.Append(item.Product.Name);
                sb.Append(", ");
                sb.Append("$");
                sb.Append(item.Product.Price.ToString("F2", CultureInfo.InvariantCulture));
                sb.Append(", Quantity: ");
                sb.Append(item.Quantity.ToString());
                sb.Append(", SubTotal: ");
                sb.AppendLine((item.SubTotal()).ToString("F2", CultureInfo.InvariantCulture));

                sum += item.SubTotal();
            }

            sb.Append("Total price: $");
            sb.Append(sum.ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}