using System;
using System.Globalization; 

namespace AreaTrianguloOO
{
    class Program
    {
        static void Main(string[] args)
        {
           
            System.Console.WriteLine("Informe as medidas do triângulo 1:");
            
            Triangulo t1 = new Triangulo();
            
            t1.ladoA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t1.ladoB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t1.ladoC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            System.Console.WriteLine("Informe as medidas do triângulo 2:");
            Triangulo t2 = new Triangulo();
            
            t2.ladoA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t2.ladoB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t2.ladoC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);



            System.Console.WriteLine("Triâgulo 1: {0:F2}", t1.getAreaTrinagulo());
            System.Console.WriteLine("Triâgulo 2: {0:F2}", t2.getAreaTrinagulo());

            if(t1.getAreaTrinagulo() > t2.getAreaTrinagulo())
            {
                System.Console.WriteLine("Maior área é do Triângulo 1!");
            } else if (t2.getAreaTrinagulo() > t1.getAreaTrinagulo()) 
            {
                System.Console.WriteLine("Maior área é do Triângulo 2!");
            } else 
            {
                System.Console.WriteLine("Os triângulos possuem áreas iguais!");
            }
        }
    }
}
