using System;
using System.Collections.Generic;
using System.Text;
using PECAN.Random;

namespace PECAN.Base
{
    public class SynchronousUpdateHandler<TGrid> : UpdateHandler<TGrid>
        where TGrid : IGrid
    {
        public override TGrid PerformUpdate(TGrid theGrid, IRandom rng)
        {
            var newGrid = (TGrid)theGrid.CleanCopy();

            foreach (var cell in theGrid.GetCells())
            {
                cell.DoUpdate(theGrid.)
            }
        }
    }
}
