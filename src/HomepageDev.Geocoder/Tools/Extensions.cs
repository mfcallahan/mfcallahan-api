using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomepageDev.Geocoder.Tools
{
    public static class Extensions
    {
        public static List<List<T>> SplitList<T>(this IList<T> source, int chunkSize)
        {
            return source
                .Select((i, j) => new { Index = j, Value = i })
                .GroupBy(k => k.Index / chunkSize)
                .Select(l => l.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
