using PECAN.Parameters;
using PECAN.Random;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PECANTest.Base
{
    public class MutatableTest
    {
        [Fact]
        public void Mutatable_Int_Equals()
        {
            var mutInt = new Mutatable<int>(1, 1.0, (int i, IRandom rand) => 0 - i);
            Assert.Equal(1, mutInt);
            Assert.True(1 == mutInt);
            Assert.True(mutInt.Equals(1));
        }

        [Fact]
        public void Mutatable_Int_Mutation()
        {
            var mutInt = new Mutatable<int>(1, 1.0, (int i, IRandom rng) => 0 - i);
            var rand = new RNG(1);
            var mutated = mutInt.GetMutant(rand);
            Assert.Equal(-1, mutated);
        }

        [Fact]
        public void Mutatable_Int_GetNew_Always()
        {
            var mutInt = new Mutatable<int>(1, 1.0, (int i, IRandom rng) => 0 - i);
            var rand = new RNG(1);
            var mutated = mutInt.GetChild(rand);
            Assert.Equal(-1, mutated);
        }

        [Fact]
        public void Mutatable_Int_GetNew_Never()
        {
            var mutInt = new Mutatable<int>(1, 0.0, (int i, IRandom rng) => 0 - i);
            var rand = new RNG(1);
            var mutated = mutInt.GetChild(rand);
            Assert.Equal(1, mutated);
        }
    }
}
