using System;
using System.Collections.Generic;
using System.Text;

namespace Day7._2
{
    internal static class VisitorCustomer
    {
        public static int Totla { get; set; }
        static VisitorCustomer()
        {
            Totla = 0;
        }
        public static void Increase()
        {
            Totla++;
        }
        public static void Display()
        {
            Console.WriteLine(Totla);
        }

    }
}
