using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;  // StructLayout 

// REF: http://www.cnblogs.com/cnxkey/articles/3852591.html

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Converter Convert = new Converter();

            my_message m;

            m = new my_message("yanlina");
            m.cmd_type = 1633837924;
            m.srcID = 1633837924;
            m.dstID = 1633837924;

            Byte[] message = Convert.StructToBytes(m);

            my_message n = (my_message)Convert.BytesToStruct(message, m.GetType());

            Console.WriteLine(Encoding.ASCII.GetString(message));
            Console.WriteLine(n.username);
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct my_message
        {
            public UInt32 cmd_type;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string username;
            public UInt32 dstID;
            public UInt32 srcID;
            public my_message(string s)
            {
                cmd_type = 0;
                username = s;
                dstID = 0;
                srcID = 0;
            }
        }
    }
}
