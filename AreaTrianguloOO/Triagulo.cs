using System;

namespace AreaTrianguloOO{
    class Triangulo {

        public double ladoA;
        public double ladoB;
        public double ladoC;

        public Triangulo(){
            this.ladoA = 0.0;
            this.ladoB = 0.0;
            this.ladoC = 0.0;
        }

        public Triangulo(double ladoA, double ladoB, double ladoC){
            this.ladoA = ladoA;
            this.ladoB = ladoB;
            this.ladoC = ladoC;
        }

        public double getAreaTrinagulo(){

            double p = (ladoA + ladoB + ladoC) / 2.0;

            double area = Math.Sqrt(p*(p-ladoA)*(p-ladoB)*(p-ladoC));

            return area;
        }
    }
}
