using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// REF: https://www.cnblogs.com/Jasmine-K/p/7659908.html

namespace Endian
{
    class Program
    {
        static void Main(string[] args)
        {
            direct();
            Console.WriteLine("==========");
            Is();
            Console.ReadKey();
        }

        public static void direct()  // reverse method
        {
            int x = 439041118; // HEX  1A2B3C5E

            string s = null;

            byte[] b = BitConverter.GetBytes(x);

            s = BitConverter.ToString(b); // Little Endian
            Console.WriteLine("Little Endian:");
            Console.WriteLine(s);

            Array.Reverse(b);

            s = BitConverter.ToString(b); // Big Endian
            Console.WriteLine("Big Endian:");
            Console.WriteLine(s);
        }

        public static void Is()   // judge method
        {
            int data = 439041118; // HEX 1A2B3C5E
            byte[] bData = BitConverter.GetBytes(data);

            string ed = "BigEndian0";

            if(BitConverter.IsLittleEndian)
            {
                Array.Reverse(bData);  // To Big Endian
                ed = "BigEndian1";
            }

            string s = BitConverter.ToString(bData);
            Console.WriteLine(ed);
            Console.WriteLine(s);
        }
    }
}
