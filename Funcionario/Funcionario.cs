using System;
using System.Globalization;

namespace Funcionario {
    class Funcionario {

        public string Nome;
        public double SalarioBruto;
        public double Imposto;

        public double SalarioLiquido() {
            return SalarioBruto - Imposto;
        }

        public void AumentarSalario(double porcentagem) {
            SalarioBruto = SalarioBruto * ( 1 + (porcentagem / 100.0));
        }

        public override string ToString()
        {
            return "\nFuncionário: " + Nome + "\nSalário: R$ " + SalarioLiquido().ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}