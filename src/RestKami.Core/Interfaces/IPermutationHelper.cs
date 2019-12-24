using System.Collections.Generic;

namespace RestKami.Core.Interfaces
{
    public interface IPermutationHelper
    {
        List<List<string>> Permutate(IEnumerable<string[]> source);
    }
}