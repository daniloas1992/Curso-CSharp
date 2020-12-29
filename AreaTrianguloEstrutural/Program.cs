using System;
using System.Globalization;

namespace AreaTrianguloEstrutural
{
    class Program
    {
        static void Main(string[] args)
        {
            double t1_ladoA, t1_ladoB, t1_ladoC;
            double t2_ladoA, t2_ladoB, t2_ladoC;

            System.Console.WriteLine("Informe as medidas do triângulo 1:");
            t1_ladoA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t1_ladoB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t1_ladoC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            System.Console.WriteLine("Informe as medidas do triângulo 2:");
            t2_ladoA = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t2_ladoB = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            t2_ladoC = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double p1 = (t1_ladoA + t1_ladoB + t1_ladoC) / 2.0;
            double p2 = (t2_ladoA + t2_ladoB + t2_ladoC) / 2.0;

            double area1 = Math.Sqrt(p1*(p1-t1_ladoA)*(p1-t1_ladoB)*(p1-t1_ladoC));
            double area2 = Math.Sqrt(p2*(p2-t2_ladoA)*(p2-t2_ladoB)*(p2-t2_ladoC));

            System.Console.WriteLine("Triâgulo 1: {0:F2}", area1);
            System.Console.WriteLine("Triâgulo 2: {0:F2}", area2);

            if(area1 > area2)
            {
                System.Console.WriteLine("Maior área é do Triângulo 1!");
            } else if (area2 > area1) 
            {
                System.Console.WriteLine("Maior área é do Triângulo 2!");
            } else 
            {
                System.Console.WriteLine("Os triângulos possuem áreas iguais!");
            }
        }
    }
}
