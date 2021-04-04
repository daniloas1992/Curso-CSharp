using System;
using System.IO;
using System.Collections.Generic;
using MapasHash.Entities;

namespace MapasHash
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"./temp/in.txt";

            HashSet<LogRecord> set = new HashSet<LogRecord>();

            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(' ');
                        string name = line[0];
                        DateTime instant = DateTime.Parse(line[1]);
                        set.Add(new LogRecord{UserName = name, Instant = instant});
                    }

                    System.Console.WriteLine("Total users: " + set.Count);
                }
            }
            catch (IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
