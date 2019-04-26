using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTime
{
    class Program
    {
        static void Main(string[] args)
        {

            // **** create a task (manages other tasks) ****
            Task task = new Task(CallMethod);

            // **** start the task ****
            task.Start();

            try
            {
                // **** wait for the task to complete ****
                task.Wait();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Main <<< EXCEPTION: " + ex.Message);
            }

            // **** press any key to continue ****
            Console.ReadKey();
        }

        static async void CallMethod()
        {

            const string fileName = "c:\\temp\\1255_store.txt";

            int length = -1;

            // **** create and start a task to read the file ****
            Task<int> task = ReadFile(fileName);

            // **** work on other tasks ****
            Console.WriteLine("CallMethod <<< before work 1");
            Console.WriteLine("CallMethod <<< before work 2");
            Console.WriteLine("CallMethod <<< before work 3");

            // **** wait on the read file task ****
            try
            {
                length = await task;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("CallMethod <<< EXCEPTION: " + ex.Message);
             }

            // **** display results of the read file task ****
            Console.WriteLine("CallMethod <<< length: " + length);

            // **** continue with other tasks ****
            Console.WriteLine("CallMethod <<< after work 4");
            Console.WriteLine("CallMethod <<< after work 5");
        }

        static async Task<int> ReadFile(string fileName)
        {

            // **** number of bytes ****
            int length = -1;

            // **** inform the user what is going on ****
            Console.WriteLine("ReadFile <<< reading file...");

            // **** read the file and count the number of bytes ****
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {

                    // **** asynchronously read the entire file ****
                    string str = await reader.ReadToEndAsync();

                    // **** get the number of bytes read ****
                    length = str.Length;
                }

            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("ReadFile <<< EXCEPTION: " + ex.Message);
                throw;
            }

            // **** inform the user what is going on ****
            Console.WriteLine("ReadFile <<< done reading file!!!");

            // **** return the number of bytes read ****
            return length;
        }
    }
}
