using PECAN.Random;
using System.Collections;
using System.Collections.Generic;

namespace PECAN.Base
{
    /// <summary>
    /// IGrid current assumes that there is only one cell type. Should be fine if we encapsulate ICell to some really generic but should be taken into account
    /// Furthermore: IGrid currently asummes a single-layered grid. Fine for now, but I know that for example bram has a few thing with multilayer grids, 
    /// IE: one layer with cells, and another layer with DNA fragments diffusing over the field.
    /// </summary>
    /// <typeparam name="TPos"></typeparam>
    /// <typeparam name="TCell"></typeparam>
    public interface IGrid<TPos>
        where TPos : IPosition
    {
        IGrid<TPos> CleanCopy();
        IEnumerable<TPos> GetPositions();
        IEnumerable<ICell> GetNeighbours(TPos pos);
        ICell this[TPos pos] { get; set; }
    }
}