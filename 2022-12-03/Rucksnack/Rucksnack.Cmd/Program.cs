using System;
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

      _ = Console.ReadLine();
    }
  }
}
