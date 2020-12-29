using System;
using System.Globalization;

namespace Estoque
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do produto: \n");
            Produto produto = new Produto();

            Console.WriteLine("\nInforme o nome do produto:");
            produto.Nome = Console.ReadLine();

            Console.WriteLine("\nInforme a quantidade do produto {0}:",produto.Nome);
            produto.Quantidade = int.Parse(Console.ReadLine());

            Console.WriteLine("\nInforme o preço do produto {0}:",produto.Nome);
            produto.Preco = double.Parse(Console.ReadLine().Replace(',','.'), CultureInfo.InvariantCulture);

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
