using PECAN.Base;
using PECAN.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PECAN._2D
{
    public class Grid2D<TCell> : GridBase<Position2D, TCell>
        where TCell:ICell<TCell>
    {
        protected readonly TCell[,] TheGrid;
        protected readonly int XSize;
        protected readonly int YSize;

        public Grid2D(int xSize, int ySize) : this(new TCell[xSize, ySize], xSize, ySize)
        {
        }
        protected Grid2D(TCell[,] grid, int xSize, int ySize)
        {
            TheGrid = grid;
            XSize = xSize;
            YSize = ySize;
        }

        protected override TCell GetCell(Position2D pos)
        {
            return TheGrid[pos.X, pos.Y];
        }

        protected override void SetCell(Position2D pos, TCell cell)
        {
            TheGrid[pos.X, pos.Y] = cell;
        }

        /// <summary>
        /// TODO: We should make this easier. 
        /// Perhaps refactor the entire thing so that IPositions enforces implementations of it to have an array of X length with the coordinates.
        /// GridBase can then infer the array required from the length of the IPosition implemented given via the generic.
        /// 
        /// 
        /// TODO: Refactor boundaries
        /// Toroidal boundary conditions are currently hardcoded. 
        /// We should find a way to make this easily switchable to any boundary condition supplier by the user.\
        /// 
        /// TODO: Refactor neighbourhood.
        /// Currently Moore neighbourhood is hardcoded. Etc etc etc
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        protected override IEnumerable<Position2D> GetNeighbourPositions(Position2D position)
        {
            for (var deltaX = -1; deltaX <= 1; deltaX++)
            {
                for (var deltaY = -1; deltaY <= 1; deltaY++)
                {
                    if (!(deltaX == 0 && deltaY == 0))
                    {
                        var newX = (position.X + deltaX + XSize) % XSize;
                        var newY = (position.Y + deltaY + YSize) % YSize;
                        yield return new Position2D(newX, newY);
                    }
                }
            }
        }

        public override IGrid<Position2D,TCell> CleanCopy()
        {
            return new Grid2D<TCell>(XSize, YSize);
        }

        public override IEnumerable<Position2D> GetPositions()
        {
            foreach (var x in Enumerable.Range(0, XSize))
            {
                foreach (var y in Enumerable.Range(0, YSize))
                {
                    yield return new Position2D(x, y);
                }
            }
        }
    }
}
