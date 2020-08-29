using System;

namespace Shared.Utils.Lib.Utils
{
    public static class Log
    {
        public static void Error(string message, Exception ex)
        {
            Console.WriteLine($"[{DateTime.UtcNow}] {message}:{Environment.NewLine}{ex}");
        }

        public static void Error(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}] {message}");
        }

        public static void Info(string message)
        {
            Console.WriteLine($"[{DateTime.UtcNow}] {message}");
        }
    }
}