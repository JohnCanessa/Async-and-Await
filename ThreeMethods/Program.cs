using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeMethods
{
    class Program
    {
        static void Main(string[] args)
        {

            // **** calls methods ****
            callMethod();

            // **** press any key to continue ****
            Console.ReadKey();
        }

        public static async void callMethod()
        {

            // **** start first task ****
            Task<int> task = Method1();

            // **** start second task (in parallel) ****
            Method2();

            // **** wait for first task to complete ****
            int count = await task;

            // **** start a third task ****
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() => {

                // **** loop displaying a message ****
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine("Method1 <<< i: {0}", i);
                    count++;
                }
            });
            return count;
        }

        public static void Method2()
        {

            // **** loop displaying a message ****
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine("Method2 <<< i: {0}", i);
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Method3 <<< count: {0}", count);
        }
    }
}
