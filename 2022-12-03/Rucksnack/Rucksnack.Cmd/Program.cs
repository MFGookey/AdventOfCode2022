using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utilities.IO;
using Rucksnack.Core;

namespace Rucksnack.Cmd
{
  /// <summary>
  /// The entrypoint for Rucksnack.Cmd
  /// </summary>
  public class Program
  {
    /// <summary>
    /// Rucksnack.Cmd entry point
    /// </summary>
    /// <param name="args">Command line arguments (not used)</param>
    static void Main(string[] args)
    {
      var filePath = "./input";
      var reader = new FileReader();
      var rucksacks = reader.ReadFile(filePath).Split('\n', StringSplitOptions.RemoveEmptyEntries);
      int sum = 0;
      foreach (var sack in rucksacks)
      {
        var mispack = Snackulator.FindMispack(sack);
        sum += Snackulator.Score(mispack);
      }

      Console.WriteLine(sum);

      var groups = MakeGroups(rucksacks, 3);

      sum = 0;

      foreach (var group in groups)
      {
        var badge = Snackulator.FindCommonItem(group);
        sum += Snackulator.Score(badge);
      }

      Console.WriteLine(sum);

      _ = Console.ReadLine();
    }

    private static IEnumerable<IEnumerable<string>> MakeGroups(IEnumerable<string> toGroup, uint groupSize)
    {
      return toGroup.Select((v, i) => new { value = v, group = (int)i / groupSize }).GroupBy(d => d.group, o => o.value, (k, g) => g);
    }
  }
}
