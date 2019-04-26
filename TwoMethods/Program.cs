using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoMethods
{
    class Program
    {
        // **** constants for methods ****
        public const int Loops1 = 100;
        public const int Loops2 = 25;
     
         static void Main(string[] args)
        {

            // **** start task ****
            Method1();

            // **** start second task (in parallel) ****
            Method2();

            // **** press any key to continue ****
            Console.ReadKey();
        }

        public static async Task Method1()
        {
            await Task.Run(() =>
            {

                // **** loop displaying a message ****
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Method1 <<< i: {0}", i);
                }
            });
        }

        public static void Method2()
        {

            // **** loop displaying a message ****
            for (int i = 0; i < Loops2; i++)
            {
                Console.WriteLine("Method2 <<< i: {0}", i);
            }
        }

    }
}
