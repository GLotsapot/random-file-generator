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
        static Int16 fileSize = 20000;

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

            DateTime startTime = DateTime.Now;
            Console.WriteLine("Starting file generation at {0}", startTime);
            Task[] tasks = new Task[files2generate];
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine("Starting Thread to generate file #{0}", i);
                // GenerateFile(20, folderPath);

                // Thread thread = new Thread(GenerateFile);
                // thread.Start();

                tasks[i] = Task.Run(() => GenerateFile()); 
            }
            Console.WriteLine("Waiting for Tasks to complete");
            Task.WaitAll(tasks);

            DateTime finishTime = DateTime.Now;
            Console.WriteLine("All tasks completed at {0}", finishTime);

            TimeSpan timeTaken = finishTime.Subtract(startTime);
            Console.WriteLine("Process took {0}", timeTaken);

            Console.ReadKey();
        }

        static void GenerateFile()
        {
            string filename = String.Format("{0}generated_{1}.txt", folderPath, Guid.NewGuid().ToString());
            var newFile = File.CreateText(filename);
            newFile.AutoFlush = true;

            //TODO: Write code to put data in the file
            // Thread.Sleep(1000);
            for (int i = 0; i < fileSize; i++)
            {
                newFile.Write(RandomString(1024));
            }

            newFile.Close();
        }

        static string RandomString(int size, bool lowerCase = false)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
    }
}
