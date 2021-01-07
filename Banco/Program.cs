using System;
using System.Globalization;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Conta conta;

            Console.WriteLine("Informe o nome do títular: ");
            string Nome = Console.ReadLine();

            Console.WriteLine("\nInforme o número da conta: ");
            string NumeroConta = Console.ReadLine();

            Console.WriteLine("\nDeseja realizar um depósito inicial (s/n)?");
            string depositar = Console.ReadLine();


            if(depositar.ToUpper().Equals("S")){
                Console.WriteLine("\nInforme o valor do depósito inicial: ");
                double Deposito = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);
                conta = new Conta(Nome, NumeroConta, Deposito);
            } else {
                conta = new Conta(Nome, NumeroConta);
            }
            
            Console.WriteLine(conta);

            Console.WriteLine("\nInforme um valor para depósito: ");
            conta.Depositar(double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture));

            Console.WriteLine(conta);

            Console.WriteLine("\nInforme um valor para saque: ");
            conta.Sacar(double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture));

            Console.WriteLine(conta);


        }
    }
}
