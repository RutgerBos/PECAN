using PECAN.Random;
using System;
using System.Collections.Generic;
using System.Text;

namespace PECAN.Base
{
    public interface IMutatable<T>
    {
        T GetChild(IRandom rng);
        T GetMutant(IRandom rng);
    }
}
