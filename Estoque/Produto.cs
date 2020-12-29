using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Estoque {
    class Produto {
        public string Nome;
        public double Preco;
        public int Quantidade;

        public double ValorTotalEmEstoque(){
            return this.Quantidade * this.Preco;
        }

        public void adicionarProdutos(int quantity){
            this.Quantidade += quantity;
        }

        public void RemoverProdutos(int quantity){
            this.Quantidade -= quantity;
        }

        public void setNome(string nome){
            this.Nome = nome;
        }

        public override string ToString()
        {
            return "\nProduto: " + this.Nome + "\nQuantidade: " + this.Quantidade + "\nValor R$ " + this.Preco.ToString("F2", CultureInfo.InvariantCulture) + "\nTotal em estoque: R$ " + this.ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}