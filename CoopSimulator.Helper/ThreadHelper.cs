using System;
using System.Threading;

namespace CoopSimulator.Helper
{
    public class ThreadHelper
    {
        public static Thread ExecuteThread(Action action, bool join = false)
        {
            Thread result = null; 
            try
            {
                result = new Thread(() => action(), 1024 * 1024);
                result.Start();

                if (join)
                {
                    result.Join();
                }
            }
            catch
            {
                // ignored
            }

            return result;
        }
    }
}