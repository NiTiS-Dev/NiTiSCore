using System;
using System.Collections;

namespace NiTiS.Core.Additions
{
    public class Randominator : IEnumerable
    {
        private int maxNum;
        private int repeat;
        public Randominator(int maxNum, int repeat)
        {
            this.maxNum = maxNum;
            this.repeat = repeat;
        }
        public IEnumerator GetEnumerator()
        {
            return new RandominatorEnum(maxNum, repeat);
        }
    }
    public class RandominatorEnum : IEnumerator
    {
        private int[] seeds = { 1, 53, 542, 6525532, 43, 5445, 54233, 72, 3, 2, 56, 430243 };
        private int seedIndex = 0;
        private int randomInt = 0;
        private int maxValue = 1;
        private int maxCount;
        private int count;
        public object Current => randomInt;

        public RandominatorEnum(int maxNum, int repeat)
        {
            this.maxValue = maxNum;
            this.maxCount = repeat;
            randomInt = new Random().Next(0, maxValue + 1);
        }
        public bool MoveNext()
        {
            if (maxCount > count)
            {

                randomInt = Math.Max(0, new Random(DateTime.Now.Millisecond + seeds[seedIndex]).Next(0, maxValue + 1 + count) - count);
                count++;
                seedIndex++;
                if (seedIndex >= seeds.Length)
                {
                    seedIndex = 0;
                }
                return true;
            }
            return false;
        }

        public void Reset()
        {
            randomInt = new Random().Next(0, maxValue + 1);
        }
    }
}
