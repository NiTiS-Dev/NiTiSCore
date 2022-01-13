using NiTiS.Core.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NiTiS.Core.Collections.Pseudo
{
    [NiTiSCoreTypeInfo("1.3.0.0", "2.0.0.0")]
    public class RangeInt : IEnumerable , IEnumerable<Int32>
    {
        private int start;
        private int end;
        public RangeInt(int start = 0, int end = 5)
        {
            this.start = start;
            this.end = end;
        }

        public IEnumerator GetEnumerator()
        {
            int it = 1;
            if(start > end)
            {
                it = -1;
            }
            if(start == end)
            {
                yield break;
            }
            for (int num = start; num != end + it; num += it)
            {
                yield return num;
            }
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            int it = 1;
            if (start > end)
            {
                it = -1;
            }
            if (start == end)
            {
                yield break;
            }
            for (int num = start; num != end; num += it)
            {
                yield return num;
            }
        }
    }
}
