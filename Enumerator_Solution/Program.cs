using System;
using System.Collections.Generic;

namespace Enumerator_Solution
{
    static class Program
    {
        static void Main(string[] args)
        {
            foreach (var l in System.IO.File.ReadLines(@"..\..\..\Program.cs").MyTake(5).Every2nd())
            {
                Console.WriteLine(l);
            }
        }

        public static IEnumerable<string> Every2nd(this IEnumerable<string> pEnumerable)
        {
            bool second = false;

            foreach (var l in pEnumerable)
            {
                if (second)
                {
                    yield return l;
                }
                second = !second;
            }
        }

        public static IEnumerable<string> MyTake(this IEnumerable<string> pEnumerable, int pX)
        {
            int count = 0;

            foreach (var l in pEnumerable)
            {
                if (count >= pX)
                {
                    yield break;
                }
                yield return l;
                ++count;
            }
        }

        //public static IEnumerable<string> Every2nd(this IEnumerable<string> pEnumerable) 
        //{
        //    IEnumerable<string> mEnumerable = new MyEnumerable(pEnumerable);
        //    return mEnumerable;
        //}

        //public static IEnumerable<string> MyTake(this IEnumerable<string> pEnumerable, int pX)
        //{
        //    IEnumerable<string> mEnumerable = new MyTakeEnumerable(pEnumerable, pX);
        //    return mEnumerable;
        //}


    }
}
