using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;


namespace Escola {
    class Aluno {
        
        public string Nome;
        public double Nota1;
        public double Nota2;
        public double Nota3;

        public double NotaFinal() {
            return Nota1 + Nota2 + Nota3;
        }

        public string Resultado() {
            if (NotaFinal() >= 60) {
                return "Aprovado!";
            } else {
                return "Reprovado!" + "\nFaltaram " + PontosFaltantes() + " pontos!";
            }
        }

        public double PontosFaltantes() {
            return 60 - NotaFinal();
        }

        public override string ToString() {
            return "Aluno: " + Nome + "\nMédia: " + NotaFinal().ToString("F2", CultureInfo.InvariantCulture) + "\n" +Resultado();
        }
    }
}