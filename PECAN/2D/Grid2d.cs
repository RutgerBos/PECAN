using PECAN.Base;
using PECAN.Random;
using System;
using System.Collections.Generic;
using System.Text;

namespace PECAN._2D
{
    public class Grid2D : GridBase<Position2D>
    {
        protected readonly ICell[,] TheGrid;
        protected readonly int XSize;
        protected readonly int YSize;

        public Grid2D(int xSize, int ySize) : this(new ICell[xSize, ySize], xSize, ySize)
        {
        }
        protected Grid2D(ICell[,] grid, int xSize, int ySize)
        {
            TheGrid = grid;
            XSize = xSize;
            YSize = ySize;
        }

        public override IEnumerable<ICell> GetCells()
        {
            foreach (var cell in TheGrid)
            {
                yield return cell;
            }
        }

        protected override ICell GetCell(Position2D pos)
        {
            return TheGrid[pos.X, pos.Y];
        }

        protected override void SetCell(Position2D pos, ICell cell)
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

        public override IGrid CleanCopy()
        {
            return new Grid2D(XSize, YSize);
        }
    }
}
