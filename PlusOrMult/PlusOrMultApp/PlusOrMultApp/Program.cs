using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlusOrMultApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var count = 10000000;
            var arr = new double[count];
            var arr2 = new double[count];
            var arr3 = new double[count];

            var rnd = new Random();
            for (int i = 0; i < count; i++)
            {
                var v = rnd.NextDouble() * 100;
                arr[i] = v;
                arr2[i] = v;
                arr3[i] = v;
            }


            var dateStart1 = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                arr[i] = arr[i] + arr[i];
            }
            var time1 = (DateTime.Now - dateStart1).TotalMilliseconds;

            var dateStart2 = DateTime.Now;
            for (int i = 0; i < count; i++)
            {
                arr2[i] = arr2[i] * 2;
            }
            var time2 = (DateTime.Now - dateStart2).TotalMilliseconds;

            Console.WriteLine("time '+' = " + time1 + " ms");
            Console.WriteLine("time '*2' = " + time2 + " ms");
        }
    }
}
