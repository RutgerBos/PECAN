using PECAN.Random;
using System;
using System.Collections.Generic;

namespace PECAN.Base
{
    public abstract class UpdateHandler<TGrid>
        where TGrid : IGrid
    {
        public abstract TGrid PerformUpdate(TGrid theGrid, IRandom rng);
        public event EventHandler UpdateStart;
        public event EventHandler UpdateEnd;
    }
}