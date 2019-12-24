using System.Collections.Generic;
using System.Linq;

using RestKami.Core.Interfaces;

namespace RestKami.Core
{
    public sealed class PermutationHelper : IPermutationHelper
    {
        public List<List<string>> Permutate(IEnumerable<string[]> sequences)
        {
            var result =  CartesianProduct(sequences);

            return result.Select(a => a.ToList()).ToList();
        }

        private IEnumerable<IEnumerable<T>> CartesianProduct<T>(IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accumulatorItem in accumulator
                    from item in sequence
                    select accumulatorItem.Concat(new[] { item })
            );
        }
    }
}