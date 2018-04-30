using PECAN.Random;
using System.Collections;
using System.Collections.Generic;

namespace PECAN.Base
{
    public interface IGrid
    {
        IEnumerable<ICell> GetCells();
        IEnumerable<ICell> GetNeighbours(ICell cell);
        IGrid CleanCopy();
    }
}