using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PECAN.Random;

namespace PECAN.Base
{
    public abstract class GridBase<TPos, TCell> : IGrid<TPos, TCell>
        where TPos : IPosition
        where TCell : ICell<TCell>
    {
        public IEnumerable<TCell> GetNeighbours(TPos position)
        {
            foreach (var pos in GetNeighbourPositions(position))
            {
                yield return GetCell(pos);
            }
        }

        protected abstract IEnumerable<TPos> GetNeighbourPositions(TPos position);

        public virtual TCell this[TPos pos]
        {
            get
            {
                return GetCell(pos);
            }
            set
            {
                SetCell(pos, value);
            }
        }

        protected abstract TCell GetCell(TPos pos);
        protected abstract void SetCell(TPos pos, TCell cell);
        public abstract IGrid<TPos, TCell> CleanCopy();
        public abstract IEnumerable<TPos> GetPositions();
    }
}
