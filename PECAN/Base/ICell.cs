using PECAN.Random;
using System;
using System.Collections.Generic;
using System.Text;

namespace PECAN.Base
{
    /// <summary>
    /// Curiously returning template pattern is horrible and I hate myself for having to use it, but it makes a few bits of code slightly more clean.
    /// Don't know if we really want to do this though. It's pretty bad and there are some real downsides to it.
    /// TODO: Figure out if there is a cleaner way to do this.
    ///       AT THE VERY LEAST: Encapsulate all calls to ICell so that users do not need to see it.
    /// </summary>
    /// <typeparam name="TCell"></typeparam>
    public interface ICell
    {
        ICell DoUpdate(IEnumerable<ICell> neighbours, IRandom theRNG);

        /// <summary>
        /// Should return a Deep Clone of the cell
        /// </summary>
        /// <returns></returns>
        ICell Clone();
    }
}
