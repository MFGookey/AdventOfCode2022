using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SantasRangers.Core
{
  public static class RangeCalculator
  {
    public static bool RangesOverlap(string ranges)
    {
      var pair = ranges.Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
      
      if (pair.Length != 2)
      {
        throw new ArgumentException($"Range {ranges} must be two comma separated values");
      }

      var first = SplitRange(pair[0]);
      var second = SplitRange(pair[1]);

      return (first.Item1 >= second.Item1 && first.Item2 <= second.Item2) || (second.Item1 >= first.Item1 && second.Item2 <= first.Item2);
    }

    private static Tuple<int, int> SplitRange(string range)
    {
      var values = range.Split('-', StringSplitOptions.RemoveEmptyEntries).Where(v => int.TryParse(v, out _)).Select(v => int.Parse(v)).ToArray();

      if (values.Count() != 2)
      {
        throw new ArgumentException($"Range {range} must be two integers separated by a \"-\"");
      }

      return Tuple.Create(values[0], values[1]);
    }
  }
}
