using PECAN.Random;
using System;
using System.Collections.Generic;
using System.Text;

namespace PECAN.Base
{
    public interface ICell
    {
        ICell DoUpdate(IEnumerable<ICell> neighbours, IRandom theRNG);
        IPosition Position { get; }

        /// <summary>
        /// Should return a Deep Clone of the cell
        /// </summary>
        /// <returns></returns>
        ICell Clone();
    }
}
