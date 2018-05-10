using System.Collections.Generic;

namespace PECAN.Random
{
    public interface IRandom
    {
        double Next();
        int NextInRange(int start, int end);
        bool EventHappens(double probability);
        IEnumerable<TThing> Randomize<TThing>(IEnumerable<TThing> things);
    }
}