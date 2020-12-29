using System;
using System.Globalization;

namespace Retangulo {
    class Retangulo {
        public double altura;
        public double largura;

        public double Area() {
            return altura * largura;
        }

        public double Perimetro() {
            return (2 * altura) + (2 * largura);
        }

        public double Diagonal() {
            return Math.Sqrt(Math.Pow(altura, 2) + Math.Pow(largura, 2));
        }

        public override string ToString()
        {
            return "Retângulo: " + largura + " x " + altura + "\nÁrea: " + Area().ToString("F2", CultureInfo.InvariantCulture) 
                                                            + "\nPerímetro: " + Perimetro().ToString("F2", CultureInfo.InvariantCulture)
                                                            + "\nDiagonal: " + Diagonal().ToString("F2", CultureInfo.InvariantCulture); 
        }
    }
}