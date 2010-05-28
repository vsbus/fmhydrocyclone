using System;
using System.Collections.Generic;
using System.Text;

namespace Hydrocyclone1
{
    public class Pair<T1, T2>
    {
        public T1 First;
        public T2 Second;

        public Pair(T1 f, T2 s)
        {
            First = f;
            Second = s;
        } 
    }
}
