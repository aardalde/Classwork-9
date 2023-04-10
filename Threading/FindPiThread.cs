/*
 * Aaron Alden
 * CSCI 352
 * March 2, 2023
 * FindPiThread.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class FindPiThread
    {
        private int numThrows;
        private int numInside;
        private Random rand;

        public FindPiThread(int numThrows)
        {
            this.numThrows = numThrows;
            this.numInside = 0;
            this.rand = new Random();
        }

        public int GetNumInside()
        {
            return this.numInside;
        }

        public void throwDarts()
        {
            for (int i = 0; i < this.numThrows; i++)
            {
                double x = this.rand.NextDouble();
                double y = this.rand.NextDouble();

                if (x * x + y * y <= 1.0)
                {
                    Interlocked.Increment(ref this.numInside);
                }
            }
        }
    }
}