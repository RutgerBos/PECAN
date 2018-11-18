using System;
using System.Collections.Generic;
using System.Text;
using PECAN.Random;

namespace PECAN.Base
{
    public class SynchronousUpdateHandler<TGrid, TPos> : UpdateHandler<TGrid, TPos>
        where TGrid : IGrid<TPos>
        where TPos : IPosition
    {
        public override TGrid PerformUpdate(TGrid theGrid, IRandom rng)
        {
            OnUpdateStart(new UpdateStartEventArgs<TGrid, TPos>(theGrid));
            var newGrid = (TGrid)theGrid.CleanCopy();
            foreach (TPos pos in theGrid.GetPositions())
            {
                newGrid[pos] = theGrid[pos].DoUpdate(theGrid.GetNeighbours(pos), rng);
            }
            OnUpdateEnd(new UpdateEndEventArgs<TGrid, TPos>(theGrid, newGrid));
            return newGrid;
        }
    }
}
