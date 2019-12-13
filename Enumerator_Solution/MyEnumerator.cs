using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Enumerator_Solution
{
    class MyEnumerator : IEnumerator<string>
    {
        public string Current => enumerator.Current;

        object IEnumerator.Current => enumerator.Current;

        private IEnumerator<string> enumerator;

        public MyEnumerator(IEnumerator<string> pEnumerator) 
        {
            enumerator = pEnumerator;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        { 
            return enumerator.MoveNext() && enumerator.MoveNext();
        }

        public void Reset()
        {
            enumerator.Reset();
        }
    }

    class MyTakeEnumerator : IEnumerator<string>
    {
        public string Current => enumerator.Current;

        object IEnumerator.Current => enumerator.Current;

        private IEnumerator<string> enumerator;

        private int x;

        private int count;

        public MyTakeEnumerator(IEnumerator<string> pEnumerator, int pX)
        {
            enumerator = pEnumerator;
            x = pX;
        }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (count < x)
            {
                ++count;
                return enumerator.MoveNext();
            }
            else 
            {
                return false;
            }
        }

        public void Reset()
        {
            enumerator.Reset();
        }
    }
}
