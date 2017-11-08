using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace get_set
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach(var name in names)
            foreach (var name in Names)
            {
                Console.WriteLine(name.Key.ToString() + name.Value);
            }

            Console.WriteLine("按回车键退出");
            Console.ReadLine();
        }

        static Dictionary<uint, string> names;
        public static Dictionary<uint, string> Names
        {
            get
            {
                if (names != null)
                    return names;

                names = new Dictionary<uint, string>();

                foreach(var info in msg_info)
                {
                    names[info.msgid] = info.name;
                }

                return names;
            }
        }


        public static message_info[] msg_info = new message_info[]
        {
            new message_info(0, "HEARTBEAT"),
            new message_info(1, "SYSTEM_STATUS")
        };

        public struct message_info
        {
            public uint msgid;
            public string name;

            public message_info(uint msgid, string name)
            {
                this.msgid = msgid;
                this.name = name;
            }
        }

    }
}
