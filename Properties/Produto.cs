using System;
using System.Globalization;

namespace Properties {
    class Produto {

        private string _nome;
        public double Preco { get; private set; } // Uso de propriedade autoimplementada. O método set não vai ficar disponível
        public int Quantidade { get; private set; } // Uso de propriedade autoimplementada. O método set não vai ficar disponível

        public Produto() {
            // Construtor vazio
        }

        public Produto(string nome, double preco, int quantidade){
            _nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public string Nome {
            get { return _nome; }

            set {
                if( value != null && value.Length > 1 ) {
                    _nome = value;
                }
            }
        }

        public double ValorTotalEmEstoque(){
            return Quantidade * Preco;
        }

        public void adicionarProdutos(int quantity){
            Quantidade += quantity;
        }

        public void RemoverProdutos(int quantity){
            Quantidade -= quantity;
        }

        public override string ToString()
        {
            return "\nProduto: " + _nome + "\nQuantidade: " + Quantidade + "\nValor R$ " + Preco.ToString("F2", CultureInfo.InvariantCulture) + "\nTotal em estoque: R$ " + this.ValorTotalEmEstoque().ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}