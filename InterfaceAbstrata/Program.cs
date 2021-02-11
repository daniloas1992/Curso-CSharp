using System;
using InterfaceAbstrata.Model.Entities;
using InterfaceAbstrata.Model.Enums;

namespace InterfaceAbstrata
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape circle = new Circle() {Radius = 2.0, Color = Color.White};
            IShape rectangle = new Rectangle() {Width = 3.5, Height = 4.2, Color = Color.Black};

            Console.WriteLine(circle);
            Console.WriteLine(rectangle);
        }
    }
}
