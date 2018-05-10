using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PECAN.Random
{
    public class RNG : IRandom
    {
        private readonly System.Random _Random;
        public RNG(int seed)
        {
            _Random = new System.Random(seed);
        }

        public virtual bool EventHappens(double probability)
        {
            return Next() <= probability ;
        }

        public virtual double Next()
        {
            return _Random.NextDouble();
        }

        public virtual int NextInRange(int startInclusive, int endInclusive)
        {
            var interval = startInclusive - endInclusive;
            int offset = (int)Math.Round(((double)interval) * Next());
            return startInclusive + offset;
        }

        public IEnumerable<TThing> Randomize<TThing>(IEnumerable<TThing> things)
        {
            var thingArray = things.ToArray();
            var count = thingArray.Length;
            foreach (var curr in Enumerable.Range(0, count))
            {
                var swap = NextInRange(curr, count - 1);
                var temp = thingArray[swap];
                thingArray[swap] = thingArray[curr];
                thingArray[curr] = thingArray[swap];
            }
            return thingArray;
        }
    }
}
