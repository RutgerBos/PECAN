using PECAN.Base;
using PECAN.Random;
using System;
using System.Collections.Generic;
using System.Text;

namespace PECAN.Parameters
{
    public class Mutatable<T> : ValueContainingClass<T>, IMutatable<Mutatable<T>> 
    {
        public Mutatable(T val, double mutationProbability, Func<T, IRandom, T> mutationFunction) : base(val)
        {
            MutationProbability = mutationProbability;
            MutationFunction = mutationFunction;
        }

        protected double MutationProbability;
        protected Func<T, IRandom, T> MutationFunction;

        public Mutatable<T> GetMutant(IRandom rng)
        {
            return new Mutatable<T>(MutationFunction(Value, rng), MutationProbability, MutationFunction);
        }

        public Mutatable<T> GetChild(IRandom rng)
        {
            if (rng.EventHappens(MutationProbability))
            {
                return GetMutant(rng);
            }
            return GetClone();
        }

        public Mutatable<T> GetClone()
        {
            return new Mutatable<T>(Value, MutationProbability, MutationFunction);
        }
    }
}
