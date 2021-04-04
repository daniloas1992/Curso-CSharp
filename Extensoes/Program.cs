using System;

namespace Extensoes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2021, 04, 04, 8, 10, 45);
            System.Console.WriteLine(dt.ElapsedTime());

            string  s1 = "good morning dear students!";
            System.Console.WriteLine(s1.Cut(10));
        }
    }
}
