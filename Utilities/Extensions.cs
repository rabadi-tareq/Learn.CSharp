using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class Extensions
    {
        public static void LogToConsole(this string str)
        {
            Console.WriteLine(str);
        }

        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
