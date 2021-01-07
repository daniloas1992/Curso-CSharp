using System;
using System.Globalization;

namespace Banco {
    
    class Conta {

        public double Saldo { get; private set; }
        public string Nome { get; set; }
        public string NumeroConta { get; private set; }
        public readonly double TaxaSaque = 5.00;

        public Conta (string nome, string numeroConta) {
            Nome = nome;
            NumeroConta = numeroConta;
            Saldo = 0.0;
        }

        public Conta (string nome, string numeroConta, double depositoInicial) : this(nome, numeroConta) {
            Depositar(depositoInicial);
        }

        public void Depositar(double valor) {
            if(valor > 0.00) {
                Saldo += valor;
            }
        }

        public void Sacar(double valor) {
            if(valor > 0.00) {
                Saldo -= (valor + TaxaSaque);
            }
        }

        public override string ToString()
        {
            return "\nTítular: " + Nome + "\nConta: " + NumeroConta + "\nSaldo: R$ " + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
        
    }
}