using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePoker
{
    public static class RandomExtensions
    {
        private static double nextGaussian = double.NaN;

        public static double NextGaussian(this Random rand, double mean, double stdDev)
        {
            double v = 0;
            if (!double.IsNaN(nextGaussian))
            {
                v = mean + (nextGaussian * stdDev);
                nextGaussian = double.NaN;
            }
            else
            {
                // box-muller
                double u1 = rand.NextDouble();
                double u2 = rand.NextDouble();
                double a = Math.Sqrt(-2.0 * Math.Log(u1));
                double b = 2.0 * Math.PI * u2;
                double normal = a * Math.Sin(b);
                v = mean + (stdDev * normal);
                nextGaussian = a * Math.Cos(b);
            }
            return v;
        }

        public static long LongRandom(this Random rand, long min, long max)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(longRand % (max - min)) + min);
        }

        public static int GetRandomElementIndex(this Random rand, IList<double> probabilitiesList)
        {
            // get universal probability 
            double u = probabilitiesList.Sum(p => p);

            // pick a random number between 0 and u
            double r = rand.NextDouble() * u;

            double sum = 0;
            for (int i = 0; i < probabilitiesList.Count; i++)
            {
                // loop until the random number is less than our cumulative probability
                if (r <= (sum = sum + probabilitiesList[i]))
                {
                    return i;
                }
            }

            throw new InvalidOperationException("Should not get there.");
        }
    }
}
