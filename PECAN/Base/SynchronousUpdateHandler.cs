using System;
using System.Collections.Generic;
using System.Text;
using PECAN.Random;

namespace PECAN.Base
{
    public class SynchronousUpdateHandler<TGrid, TCell, TPos> : UpdateHandler<TGrid, TCell, TPos>
        where TGrid : IGrid<TPos, TCell>
        where TCell : ICell<TCell>
        where TPos : IPosition
    {
        public override TGrid PerformUpdate(TGrid theGrid, IRandom rng)
        {
            var newGrid = (TGrid)theGrid.CleanCopy();

            foreach (TPos pos in theGrid.GetPositions())
            {
                newGrid[pos] = theGrid[pos].DoUpdate(theGrid.GetNeighbours(pos), rng);
            }
            return newGrid;
        }
    }
}
