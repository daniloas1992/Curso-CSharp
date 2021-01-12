using System;
using System.Globalization;

namespace DataHora
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime d1 = DateTime.Now;
            Console.WriteLine(d1);
            Console.WriteLine(d1.Ticks);

            DateTime d2 = new DateTime(2020, 01, 25); // aaaa/mm/dd
            DateTime d3 = new DateTime(2020, 01, 25, 20, 45, 3); // aaaa/mm/dd hh:MM:ss
            DateTime d4 = new DateTime(2020, 01, 25, 20, 45, 3, 500); // aaaa/mm/dd hh:MM:ss:mils

            Console.WriteLine(d2);
            Console.WriteLine(d3);
            Console.WriteLine(d4);

            DateTime d5 = DateTime.Today; // aaaa/mm/dd 00:00:00

            Console.WriteLine(d5);

            DateTime d6 = DateTime.UtcNow; // Horário UTC

            Console.WriteLine(d6);

            DateTime d7 = DateTime.Parse("2021-01-20");
            DateTime d8 = DateTime.Parse("2021-01-20 19:47:25");

            Console.WriteLine(d7);
            Console.WriteLine(d8);

            DateTime d9  = DateTime.Parse("21/01/2021");
            DateTime d10 = DateTime.Parse("21/01/2021 19:47:25");
            DateTime d11 = DateTime.Parse("04/04/2021 19:47:25");

            Console.WriteLine(d9);
            Console.WriteLine(d10);
            Console.WriteLine(d11);

            DateTime d12 = DateTime.ParseExact("2021-01-25", "yyyy-MM-dd", CultureInfo.InvariantCulture); //Máscara de data

            Console.WriteLine(d12);

            DateTime d13 = DateTime.ParseExact("25/01/2021 19:47:18", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); //Máscara de data

            Console.WriteLine(d13);

        }
    }
}

