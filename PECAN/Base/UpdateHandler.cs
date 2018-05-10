using PECAN.Random;
using System;
using System.Collections.Generic;

namespace PECAN.Base
{
    public abstract class UpdateHandler<TGrid, TCell, TPos>
        where TGrid : IGrid<TPos,TCell>
        where TCell : ICell<TCell>
        where TPos : IPosition
    {
        public abstract TGrid PerformUpdate(TGrid theGrid, IRandom rng);
        public event EventHandler UpdateStart;
        public event EventHandler UpdateEnd;
    }
}