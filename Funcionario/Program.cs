using System;
using System.Globalization;

namespace Funcionario
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario func = new Funcionario();
            Console.WriteLine("Informe o nome do funcionário: ");
            func.Nome = Console.ReadLine();

            Console.WriteLine("Informe o salário bruto do funcionário {0}: ", func.Nome);
            func.SalarioBruto = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Console.WriteLine("Informe o valor do imposto do salário do funcionário {0}: ", func.Nome);
            func.Imposto = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Console.WriteLine(func.ToString());

            Console.WriteLine("\nInforme o percentual de acréscimo do salário do funcionário {0}: ", func.Nome);
            func.AumentarSalario(double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture));

            Console.WriteLine(func.ToString());

        }
    }
}
