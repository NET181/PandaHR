using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PandaHR.Api.Services.MatchingAlgorithm
{
    public static class MatchingExtension
    {
        public static int GetMatching<T>(this IEnumerable<T> source, IEnumerable<T> enumerable)
        {
            return source.Intersect(enumerable).Count() / source.Count();
        }
    }
}
