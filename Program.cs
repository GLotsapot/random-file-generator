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
        static String folderPath = @".\";
        static Int16 fileSize = 20;

        static void Main(string[] args)
        {
            var files2generate = 20;
            if (args[0] != null)
            {
                String newPath = @args[0];
                Console.WriteLine("Path {0} was passed as an argument, overwriting default.", newPath);
                if (Directory.Exists(newPath))
                {
                    folderPath = newPath;
                }
                else
                {
                    Console.WriteLine("Passed path doesn't exist. Keeping default {0}", folderPath);
                }

            }

            Console.WriteLine("Starting file generation");
            for (int i = 0; i < files2generate; i++)
            {
                Console.WriteLine("Starting Thread to generate file #{0}", i);
                // GenerateFile(20, folderPath);
                Thread thread = new Thread(GenerateFile);
                thread.Start();
            }
            Console.WriteLine("Finished Creating Threads");
            Console.ReadKey();
        }

        static void GenerateFile()
        {
            string filename = String.Format("{0}generated_{1}.txt", folderPath, Guid.NewGuid().ToString());
            var newFile = File.CreateText(filename);
            //TODO: Write code to put data in the file
            Thread.Sleep(1000);

            newFile.Close();
        }
    }
}
