using System;
using System.Globalization;

namespace Escola
{
    class Program
    {
        static void Main(string[] args)
        {   
            Aluno aluno = new Aluno();
            Console.WriteLine("Informe o nome do aluno: ");
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Informe a Nota 1: ");
            aluno.Nota1 = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Console.WriteLine("Informe a Nota 2: ");
            aluno.Nota2 = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Console.WriteLine("Informe a Nota 3: ");
            aluno.Nota3 = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Console.WriteLine(aluno.ToString());
        }
    }
}
