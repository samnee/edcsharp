using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace thread_sleep
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Thread(new ThreadStart(mainloop));
            t.Start();

            Thread.Sleep(5);  // Sleep 5 milli second

            t.Abort();
            t.Join();

            Console.WriteLine("mainloop Finished");
            Console.ReadLine();
        }


        //public void mainloop()
        private static void mainloop()
        {
            int i = 0;
            while(true)
            {
                i++;
                Console.WriteLine("Loop:" + i.ToString() );
            }
        }
    }
}
