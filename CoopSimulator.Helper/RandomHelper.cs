using System;

namespace CoopSimulator.Helper
{
    public class RandomHelper
    {
        private static readonly object SyncLock = new object();
        private static readonly Random Random = new Random();

        public static int Number(int min, int max)
        {
            lock (SyncLock)
            {
                return Random.Next(min, ++max);
            }
        }
    }
}