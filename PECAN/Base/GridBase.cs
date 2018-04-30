using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PECAN.Random;

namespace PECAN.Base
{
    public abstract class GridBase<TPos> : IGrid
        where TPos : IPosition
    {

        public IEnumerable<ICell> GetNeighbours(ICell cell)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ICell> GetNeighbours(TPos position)
        {
            foreach (var pos in GetNeighbourPositions(position))
            {
                yield return GetCell(pos);
            }
        }

        protected abstract IEnumerable<TPos> GetNeighbourPositions(TPos position);
        public abstract IEnumerable<ICell> GetCells();


        public virtual ICell this[TPos pos]
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

        protected abstract ICell GetCell(TPos pos);
        protected abstract void SetCell(TPos pos, ICell cell);

        public abstract IGrid CleanCopy();
    }
}
