using PECAN.Random;
using System;
using System.Collections.Generic;

namespace PECAN.Base
{
    public abstract class UpdateHandler<TGrid, TPos>
        where TGrid : IGrid<TPos>
        where TPos : IPosition
    {
        public abstract TGrid PerformUpdate(TGrid theGrid, IRandom rng);
        public event EventHandler<UpdateStartEventArgs<TGrid, TPos>> UpdateStart;
        public event EventHandler<UpdateEndEventArgs<TGrid, TPos>> UpdateEnd;


        protected void OnUpdateStart(UpdateStartEventArgs<TGrid, TPos> updateStartEventArgs)
        {
            UpdateStart?.Invoke(this, updateStartEventArgs);
        }
        
        protected void OnUpdateEnd(UpdateEndEventArgs<TGrid, TPos> updateEndEventArgs)
        {
            UpdateEnd?.Invoke(this, updateEndEventArgs);
        }
    }

    public class UpdateStartEventArgs<TGrid, TPos> : EventArgs
        where TGrid : IGrid<TPos>
        where TPos : IPosition
    {
        public readonly TGrid TheGrid;
        public UpdateStartEventArgs(TGrid grid)
        {
            TheGrid = grid;
        }
    }

    public class UpdateEndEventArgs<TGrid, TPos>
        where TGrid : IGrid<TPos>
        where TPos : IPosition
    {
        public readonly TGrid GridBefore;
        public readonly TGrid GridAfter;
        public UpdateEndEventArgs(TGrid gridBefore, TGrid gridAfter)
        {
            GridBefore = gridBefore;
            GridAfter = gridAfter;
        }
    }
}