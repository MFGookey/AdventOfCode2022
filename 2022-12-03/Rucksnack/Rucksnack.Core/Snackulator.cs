using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Rucksnack.Core
{
  public static class Snackulator
  {
    public static char FindMispack(string bagData)
    {
      // Split the stirng in half
      var compartments = SplitInHalf(bagData);
      // Convert it to a char array (or even an int array?)

      // Find the same value in both sides
      var mispacks = compartments.Item1.ToCharArray().Join(compartments.Item2.ToCharArray(), (c) => c, (c) => c, (c1, c2) => c1).Distinct();
      if (mispacks.Count() > 1)
      {
        throw new ArgumentException("Found more than one character in both compartments");
      }

      return mispacks.First();
    }

    private static Tuple<string, string> SplitInHalf(string toSplit)
    {
      if (toSplit.Length % 2 != 0)
      {
        throw new ArgumentException(nameof(toSplit));
      }

      return Tuple.Create(toSplit.Substring(0, toSplit.Length / 2), toSplit.Substring(toSplit.Length / 2));
    }
    public static int Score(char toScore)
    {
      var rawScore = toScore - 'a' + 1;
      if (rawScore < 0)
      {
        rawScore += 58;
      }
      return rawScore;
    }
  }
}
