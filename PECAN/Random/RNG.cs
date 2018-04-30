using System;
using System.Collections.Generic;
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
    }
}
