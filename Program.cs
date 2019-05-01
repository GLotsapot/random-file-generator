using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace random_file_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            var folderPath = @"C:\TestFolder\";
            var files2generate = 20;

            for (int i = 0; i < files2generate; i++)
            {
                Console.WriteLine("Generating File #{0}", i);
                GenerateFile(20, folderPath);
            }
            Console.WriteLine("Finished Creating Threads");
            Console.ReadKey();
        }

        static void GenerateFile(int size, string location)
        {
            string filename = String.Format("{0}generated_{1}.txt", location, Guid.NewGuid().ToString());
            var newFile = File.CreateText(filename);
            //TODO: Write code to put data in the file
            Thread.Sleep(1000);

            newFile.Close();
        }
    }
}
