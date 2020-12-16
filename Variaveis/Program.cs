// https://docs.microsoft.com/pt-br/dotnet/core/tutorials/debugging-with-visual-studio-code

using System;
using System.Globalization;

namespace Variaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            string produto1 = "Computador";
            string produto2 = "Mesa de escritório";

            byte idade = 30;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100.0;
            double preco2 = 650.50;
            double media = 53.234567;

            System.Console.WriteLine("Produtos:");
            System.Console.WriteLine("{0}, cujo preço é $ {1:F2}", produto1, preco1);
            System.Console.WriteLine("{0}, cujo preço é $ {1:F2}", produto2, preco2);

            System.Console.WriteLine($"\nRegistro: {idade} anos de idade, código {codigo} e gênero: {genero}");

            System.Console.WriteLine("\nMedida com oito casas decimais: " + media.ToString("F8"));
            System.Console.WriteLine("Arredondado (três casas decimais): " + media.ToString("F3"));
            System.Console.WriteLine("Separador decimal invariant culture: " + media.ToString("F3", CultureInfo.InvariantCulture));

            double valor = 5.999;

            System.Console.WriteLine((int)valor);

            double a = 1.0, b = -3.0, c = -4.0;
            double delta = Math.Pow(b, 2.0) - 4 * a * c;

            double x1 = (-b + Math.Sqrt(delta)) / (2.0 * a);
            double x2 = (-b - Math.Sqrt(delta)) / (2.0 * a);

            System.Console.WriteLine("X1: {0:F2} \nX2: {1:F2}", x1, x2);
        }
    }
}
