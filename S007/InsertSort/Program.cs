using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// REF: https://www.cnblogs.com/WangJinYang/p/3553792.html

namespace InsertSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] iArray = new int[] { 1, 5, 3, 6, 10, 55, 9, 2, 87, 12, 34, 75, 33, 47, 1, 5, 3, 6, 10, 55, 9, 2, 87, 12, 34, 75, 33, 47 };

            Sort(iArray);

            // Console.WriteLine(iArray);

            //Console.WriteLine("%s",iArray);   // %s
            //Console.WriteLine("{1}", iArray);

            // Console.WriteLine(Convert.ToString(iArray));

            // https://zhidao.baidu.com/question/393425465.html
            foreach (var i in iArray)
                Console.WriteLine(i.ToString());

            Console.ReadKey();
        }

        public static void Sort(int[] list)
        {
            for (int i = 1; i < list.Length; ++i)
            {
                int t = list[i];
                int j = i;

                while((j>0) && (list[j-1]>t))
                {
                    list[j] = list[j - 1];
                    --j;
                }

                list[j] = t;
            }
        }
    }
}
