using System;
using System.Globalization;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do produto: \n");

            Console.WriteLine("\nInforme o nome do produto:");
            string nome = Console.ReadLine();

            Console.WriteLine("\nInforme a quantidade do produto {0}:", nome);
            int quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o preço do produto {0}:", nome);
            double preco = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

            Produto produto = new Produto(nome, preco, quantidade);

            Console.WriteLine(produto.ToString());

            Console.WriteLine("\nInforme a quantidade a ser adicionada ao estoque do produto {0}: ", produto.Nome);
            produto.adicionarProdutos(int.Parse(Console.ReadLine()));

            Console.WriteLine(produto.ToString());

            Console.WriteLine("\nInforme a quantidade a ser removida ao estoque do produto {0}: ", produto.Nome);
            produto.RemoverProdutos(int.Parse(Console.ReadLine()));

            Console.WriteLine(produto.ToString());
        }
    }
}
