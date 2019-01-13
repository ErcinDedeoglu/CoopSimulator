using System;

namespace CoopSimulator.Helper
{
    public class FileHelper
    {
        public static string ReadFile(string path)
        {
            string result = null;

            try
            {
                result = System.IO.File.ReadAllText(path);
            }
            catch (Exception ex)
            {
                // ignored
            }

            return result;
        }
    }
}