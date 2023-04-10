/*
 * Aaron Alden
 * CSCI 352
 * March 2, 2023
 * Program.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Threading;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of throws each thread should make:");
            int numThrows = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of threads:");
            int numThreads = int.Parse(Console.ReadLine());

            List<Thread> threadList = new List<Thread>();
            List<FindPiThread> piThreadList = new List<FindPiThread>();

            for (int i = 0; i < numThreads; i++)
            {
                FindPiThread piThread = new FindPiThread(numThrows);
                piThreadList.Add(piThread);
                Thread thread = new Thread(new ThreadStart(piThread.throwDarts));

                threadList.Add(thread);
                thread.Start();

                Thread.Sleep(16);
            }

            foreach (Thread thread in threadList)
            {
                thread.Join();
            }

            int totalInside = 0;

            foreach (FindPiThread piThread in piThreadList)
            {
                totalInside += piThread.GetNumInside();
            }

            double piEstimate = 4.0 * totalInside / (numThrows * numThreads);

            Console.WriteLine("Pi estimation with given parameters: " + piEstimate);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}