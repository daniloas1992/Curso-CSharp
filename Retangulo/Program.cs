using System;
using System.Globalization;

namespace Retangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            Retangulo ret = new Retangulo();
            Console.WriteLine("Informe a altura do retângulo");
            ret.altura = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Console.WriteLine("Informe a largura do retângulo");
            ret.largura = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Console.WriteLine(ret.ToString());
        }
    }
}
