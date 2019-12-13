using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Enumerator_Solution
{
    class MyEnumerable : IEnumerable<string>
    {
        private IEnumerable<string> enumerable;

        public MyEnumerable(IEnumerable<string> pEnumerable) 
        {
            enumerable = pEnumerable;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new MyEnumerator(enumerable.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyEnumerator(enumerable.GetEnumerator());
        }
    }

    class MyTakeEnumerable : IEnumerable<string>
    {
        private IEnumerable<string> enumerable;

        private int x;

        public MyTakeEnumerable(IEnumerable<string> pEnumerable, int pX)
        {
            enumerable = pEnumerable;
            x = pX;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new MyTakeEnumerator(enumerable.GetEnumerator(), x);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new MyTakeEnumerator(enumerable.GetEnumerator(), x);
        }
    }
}
