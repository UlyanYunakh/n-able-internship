using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace test_task_3
{
    class Program
    {
        static Stopwatch watch = new Stopwatch();

        static void ReadThread(ThreadSafeBigAssData<string> data, int i)
        {
            Thread.Sleep(3000);
            data.ReadData(i);
            Console.WriteLine($"{watch.Elapsed.ToString()} : Elem {i} : {data.ReadData(i)}");
        }

        static void WriteThread(ThreadSafeBigAssData<string> data, string newData)
        {
            Thread.Sleep(3000);
            data.WriteData(newData);
            Console.WriteLine($"{watch.Elapsed.ToString()} : Add elem {newData}");
        }

        static void Main(string[] args)
        {
            ThreadSafeBigAssData<string> data = new ThreadSafeBigAssData<string>();
            watch.Start();

            List<string> names = new List<string>() { "Asuka", "Akira", "Tesuo", "John", "Poul", "Ringo", "George" };

            foreach (var name in names)
                data.WriteData(name);

            foreach (int i in Enumerable.Range(0, 6))
            {
                new Thread(() => ReadThread(data, i)).Start();
                // ReadThread(data, i);
            }

            List<string> newNames = new List<string>() { "Ulyan", "Bob" };

            foreach (var name in newNames)
            {
                new Thread(() => WriteThread(data, name)).Start();
                // WriteThread(data, name);
            }
        }
    }
}
