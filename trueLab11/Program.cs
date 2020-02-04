using System;
using System.IO;
using System.Threading;

namespace trueLab2
{
    class Program
    {
        static int id = GetLastId();
        static void Main(string[] args)
        {
            Thread myThread = new Thread(new ThreadStart(Count));
            myThread.Start();

            while (true)
            {
                AddMessage("Message: ");
            }
        }

        static void Count()
        {
            while (true)
            {
                int id1 = GetLastId();

                if (id1 > id)
                {
                    OutputLines(id);
                }

                id = id1;

                Thread.Sleep(500);
            }
        }

        static void AddMessage(string login)
        {
            string message = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter(@"E:\\test\\test.txt", true))
            {
                sw.WriteLine(message);
            }
        }

        static int GetLastId()
        {
            int line = 0;

            try
            {
                line = File.ReadAllLines(@"E:\\test\\test.txt").Length;
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Нет такого файла.");
                Console.ResetColor();
            }
            finally
            {
                //очистка ресурсов
            }

            return line;
        }

        static void OutputLines(int count)
        {
            string[] arr = File.ReadAllLines(@"E:\\test\\test.txt");

            for (int i = count; i < arr.Length; i++)
            {
                Console.WriteLine("Message: " + arr[i]);
            }
        }
    }
}
