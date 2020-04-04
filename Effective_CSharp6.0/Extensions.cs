using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsPractices
{
    public static class Extensions
    {
        public static void Log(this string str)
        {
            Console.WriteLine(str);
        }
    }
}
